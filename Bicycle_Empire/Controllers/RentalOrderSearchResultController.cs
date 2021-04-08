using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Bicycle_Empire
{
    class RentalOrderSearchResultController
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
        public List<RentalOrderSearchResult> GetReleventInfo(string category, string input)
        {
            List<RentalOrderSearchResult> orders = db.Query<RentalOrderSearchResult>($"SELECT Rental_Orders.order_number, " +
                                                                                    $"Rental_Orders.customer_id, " +
                                                                                    $"Rental_Orders.order_date, " +
                                                                                    $"Rental_Orders.return_date, " +
                                                                                    $"Rental_Orders.bicycle_id, " +
                                                                                    $"Rental_Orders.rent_time, " +
                                                                                    $"Rental_Orders.days_rented, " +
                                                                                    $"Bicycles.rental_status, " +
                                                                                    $"Bicycles.price_category, " +
                                                                                    $"Invoice_Info.invoice_number, " +
                                                                                    $"CASE " +
                                                                                    $"WHEN Rental_Orders.rent_time < 24 THEN SUM(Rental_Prices.hour_price * Rental_Orders.rent_time) " +
                                                                                    $"WHEN Rental_Orders.rent_time > 24 THEN SUM(Rental_Prices.day_price * Rental_Orders.days_rented) " +
                                                                                    $"END AS total_price " +
                                                                                    $"FROM Rental_Orders " +
                                                                                    $"INNER JOIN Bicycles ON Rental_Orders.bicycle_id = Bicycles.bicycle_id " +
                                                                                    $"INNER JOIN Invoice_Info ON Rental_Orders.order_number=Invoice_Info.order_number " +
                                                                                    $"INNER JOIN Rental_Prices ON Bicycles.price_category=Rental_Prices.price_category " +
                                                                                    $"WHERE Rental_Orders.{category} LIKE '%{input}%' " +
                                                                                    $"GROUP BY Rental_Orders.order_number, " +
                                                                                    $"Rental_Orders.customer_id, " +
                                                                                    $"Rental_Orders.order_date, " +
                                                                                    $"Rental_Orders.return_date, " +
                                                                                    $"Rental_Orders.bicycle_id, " +
                                                                                    $"Rental_Orders.rent_time, " +
                                                                                    $"Rental_Orders.days_rented, " +
                                                                                    $"Bicycles.rental_status, " +
                                                                                    $"Bicycles.price_category, " +
                                                                                    $"Invoice_Info.invoice_number").ToList();

            return orders;
        }
    }
}
