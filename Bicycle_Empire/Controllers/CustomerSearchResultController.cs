using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Bicycle_Empire
{
    class CustomerSearchResultController
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
        /// <summary>
        /// Tar fram relevant data till customer sökningar i "real time simulationen"
        /// </summary>
        /// <param name="category">Vilken kategori som ska sökas på</param>
        /// <param name="input">Vilket värde som ska sökas efter</param>
        /// <returns></returns>
        public List<CustomerSearchResult> GetReleventInfo(string category, string input)
        {
            List<CustomerSearchResult> customers = db.Query<CustomerSearchResult>($"SELECT Customers.customer_id, " +
                                                                                $"Customers.first_name, " +
                                                                                $"Customers.last_name, " +
                                                                                $"Customers.phone_number, " +
                                                                                $"COUNT(DISTINCT Rental_orders.order_number) AS order_number, " +
                                                                                $"COUNT(DISTINCT Invoice_Info.invoice_number) AS invoice_number " +
                                                                                $"FROM Customers " +
                                                                                $"INNER JOIN Rental_Orders ON Customers.customer_id = Rental_Orders.customer_id " +
                                                                                $"INNER JOIN Invoice_Info ON Rental_Orders.customer_id = Invoice_Info.customer_id " +
                                                                                $"WHERE Customers.{category} LIKE '%{input}%' " +
                                                                                $"GROUP BY Rental_orders.order_number, " +
                                                                                $"Customers.customer_id, " +
                                                                                $"Customers.first_name, " +
                                                                                $"Customers.last_name, " +
                                                                                $"Customers.phone_number, " +
                                                                                $"Invoice_Info.invoice_number").ToList();
            return customers;
        }
    }
}
