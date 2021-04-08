using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Bicycle_Empire
{
    class InvoiceInfoSearchResultController
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
        public List<InvoiceSearchResult> GetReleventInfo(string category, string input)
        {
            List<InvoiceSearchResult> invoices = db.Query<InvoiceSearchResult>($"SELECT Invoice_Info.invoice_number, " +
                                                                                    $"Invoice_Info.order_number, " +
                                                                                    $"Invoice_Info.customer_id, " +
                                                                                    $"Invoice_Info.first_name, " +
                                                                                    $"Invoice_Info.last_name, " +
                                                                                    $"Invoice_Info.invoice_adress, " +
                                                                                    $"Invoice_Info.co_adress, " +
                                                                                    $"Invoice_Info.postal_number, " +
                                                                                    $"Invoice_Info.city, " +
                                                                                    $"Bicycles.price_category, " +
                                                                                    $"CASE " +
                                                                                    $"WHEN Rental_Orders.rent_time < 24 THEN SUM(Rental_Prices.hour_price * Rental_Orders.rent_time) " +
                                                                                    $"WHEN Rental_Orders.rent_time > 24 THEN SUM(Rental_Prices.day_price * Rental_Orders.days_rented) " +
                                                                                    $"END AS total_price " +
                                                                                    $"FROM Invoice_Info " +
                                                                                    $"INNER JOIN Rental_Orders ON Rental_Orders.order_number=Invoice_Info.order_number " +
                                                                                    $"INNER JOIN Bicycles ON Rental_Orders.bicycle_id = Bicycles.bicycle_id " +
                                                                                    $"INNER JOIN Rental_Prices ON Bicycles.price_category=Rental_Prices.price_category " +
                                                                                    $"WHERE Invoice_Info.{category} LIKE '%{input}%' " +
                                                                                    $"GROUP BY Invoice_Info.invoice_number, " +
                                                                                    $"Invoice_Info.order_number, " +
                                                                                    $"Invoice_Info.customer_id, " +
                                                                                    $"Invoice_Info.first_name, " +
                                                                                    $"Invoice_Info.last_name, " +
                                                                                    $"Invoice_Info.invoice_adress, " +
                                                                                    $"Invoice_Info.co_adress, " +
                                                                                    $"Invoice_Info.postal_number, " +
                                                                                    $"Invoice_Info.city, " +
                                                                                    $"Bicycles.price_category, " +
                                                                                    $"Rental_Orders.rent_time, " +
                                                                                    $"Rental_Orders.days_rented ").ToList();

            return invoices;
        }
    }
}
