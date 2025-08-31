using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using PdfSharpCore.Pdf.AcroForms;

namespace AlisverisLab.MVC.Services
{
    public class InvoiceService
    {
        public byte[] CreateInvoice(string orderId, string customerName, double totalAmount)
        {
            var ms = new MemoryStream();

            var pdf = new PdfDocument();

            var page = pdf.AddPage();

            var gfx = XGraphics.FromPdfPage(page);

            var font = new XFont("Arial", 12, XFontStyle.Regular);

            gfx.DrawString($"Invoice for Order Number: {orderId}", font, XBrushes.Black, new XPoint(20, 20));
            gfx.DrawString($"Customer Name: {customerName}", font, XBrushes.Black, new XPoint(20, 40));
            gfx.DrawString($"Total Amount: {totalAmount}", font, XBrushes.Black, new XPoint(20, 60));

            pdf.Save(ms);
            return ms.ToArray();
        }
    }
}
