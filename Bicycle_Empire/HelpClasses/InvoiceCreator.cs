using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Bicycle_Empire
{
    public static class InvoiceCreator
    {
        public static void CreateInvoice(string fileName, Invoice_Info invoiceData)
        {
            RentalOrderSearchResultController rCont = new RentalOrderSearchResultController();
            RentalOrderSearchResult order = rCont.GetReleventInfo("order_number", Convert.ToString(invoiceData.order_number)).Last();

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            string text = $"INVOICE { invoiceData.invoice_number}\n\n" +
            $"Customer: {invoiceData.customer_id}\n" +
            $"Order: {invoiceData.order_number}\n" +
            $"Bicycle: {order.bicycle_id}\n" +
            $"Price category: {order.price_category}\n" +
            $"Start date: {order.order_date}\n" +
            $"Return date: {order.return_date}\n" +
            $"Total hours rented: {order.rent_time}\n" +
            $"Total days rented: {order.days_rented}\n\n" +
            $"Total price: {order.total_price}";

            File.WriteAllText(Path.Combine(filePath, $"{fileName}.doc"), text);

            filePath = filePath + $@"\{fileName}";
            SeeInvoice(filePath);
        }

        internal static void SeeInvoice(string filePath)
        {

            Process.Start(filePath);

        }

        public static void PrintInvoiceCopy(Invoice_Info invoice)
        {
            try
            {
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + $@"\Invoice_{invoice.invoice_number}.doc";

                Process.Start(filePath);
            }
            catch
            {
                CreateInvoice($"Invoice_{invoice.invoice_number}", invoice);
            }
        }
    }
}
