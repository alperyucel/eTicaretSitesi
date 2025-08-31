namespace AlisverisLab.MVC.Models
{
    public class OrderInvoiceModel
    {
        public string OrderId { get; set; }
        public string CustomerName { get; set; }
        public double TotalAmount { get; set; }
        public string Email { get; set; }
    }
}
