using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Bicycle_Empire
{
    class RentalOrdersController : IController<Rental_Orders>
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);

        public List<Rental_Orders> GetAll()
        {
            List<Rental_Orders> rentalOrders = db.Query<Rental_Orders>("Select * From Rental_Orders").ToList();

            return rentalOrders;
        }

        public List<Rental_Orders> GetByString(string category, string input)
        {
            if (category == "order_date" || category == "return_date")
            {
                List<Rental_Orders> rentalOrders = db.Query<Rental_Orders>($"SELECT * FROM Rental_Orders WHERE {category} LIKE '%{input}%' ORDER BY {category}").ToList();
                return rentalOrders;
            }
            else
            {
                List<Rental_Orders> rentalOrders = db.Query<Rental_Orders>($"SELECT * FROM Rental_Orders WHERE {category} LIKE '%{int.Parse(input)}%' ORDER BY {category}").ToList();
                return rentalOrders;
            }
        }

        public int Add(Rental_Orders o)
        {
            try
            {
                // order_date sätts som dagens datum och tid automatiskt, därför måste return_date ha ett värde som är större än order_date.
                var affectedRows = db.Execute($"INSERT INTO Rental_Orders(customer_id, bicycle_id, return_date) VALUES (@customer_id, @bicycle_id, @return_date)", o);
                return affectedRows;
            }
            catch 
            {
                Console.WriteLine($"The return date needs to be later then the order date ({DateTimeOffset.Now}). No order has been added.");
                Console.ReadKey();
                var affectedRows = 0;
                return affectedRows;
            }
        }

        public void Update(int id, string category, string input)
        {
            if (category == "customer_id" || category == "bicycle_id")
            {
                db.Execute("UPDATE Rental_Orders " +
                        $"SET {category} = {int.Parse(input)} " +
                        $"WHERE order_number = {id}");
            }
            else
            {
                db.Execute("UPDATE Rental_Orders " +
                            $"SET {category} = '{input}' " +
                            $"WHERE order_number = {id}");
            }
        }

        public int Delete(int id)
        {
            var effectedRows = db.Execute("DELETE FROM Invoice_Info " +
                                         $"WHERE order_number = {id}");

            effectedRows += db.Execute("DELETE FROM Rental_Orders " +
                                      $"WHERE order_number = {id}");

            return effectedRows;
        }
    }
}
