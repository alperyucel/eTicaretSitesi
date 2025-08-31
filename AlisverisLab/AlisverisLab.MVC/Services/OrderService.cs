using AlisverisLab.Core.Utility;
using AlisverisLab.DataAccess.Abstract;
using AlisverisLab.MVC.Models;
using AutoMapper;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using AlisverisLab.Entity.DTO;
using System.Text;

namespace AlisverisLab.MVC.Services
{
    public class OrderService
    {
        IConnection connection;
        IChannel channel;
        InvoiceService invoiceService;
        ICartService cartService;
        IMapper mapper;
        IConfiguration configuration;

        public OrderService(InvoiceService invoiceService, ICartService cartService, IMapper mapper, IConfiguration configuration)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            connection = factory.CreateConnectionAsync().Result;

            this.channel = connection.CreateChannelAsync().Result;
            channel.QueueDeclareAsync(queue: "orders", durable: false,
                exclusive: false, autoDelete: false, arguments: null);
            this.invoiceService = invoiceService;
            this.cartService = cartService;
            this.mapper = mapper;
            this.configuration = configuration;
        }


        public void StartListening()
        {

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += async (model, ea) =>
            {

                var body = ea.Body.ToArray();
                string mesaj = Encoding.UTF8.GetString(body);

                await ProcessOrder(mesaj);

            };

            channel.BasicConsumeAsync("orders", true, consumer).Wait();

        }

        async Task ProcessOrder(string message)
        {
            OrderInvoiceModel data = JsonConvert.DeserializeObject<OrderInvoiceModel>(message);

            byte[] pdf = invoiceService.CreateInvoice(data.OrderId, data.CustomerName, data.TotalAmount);

            bool result = new EmailService(configuration).SendEmail("Faturanız OLuşturulmuştur. Faturanıza ekteki PDF'ten ulaşabilirsiniz. Bizi tercih ettiğiniz için teşekkür ederiz. ", "Fatura", pdf, false, data.Email);

        }
    }
}
