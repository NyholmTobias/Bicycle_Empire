﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bicycle_Empire
{
    class RentalOrdersController
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
            // order_date sätts som dagens datum och tid automatiskt, därför måste return_date ha ett värde som är större än order_date.
            var affectedRows = db.Execute($"INSERT INTO Rental_Orders(customer_id, bicycle_id, return_date) VALUES (@customer_id, @bicycle_id, @return_date)", o);

            return affectedRows;
        }

        public void Update(int id, string category, string input)
        {
            // OBS! kan inte uppdatera return_date eftersom det finns en CHECK på return_date i SQL som är felaktig. Man måste droppa den och lägga in följande kod: ALTER TABLE Rental_Orders
            // ADD CHECK(return_date > order_date); Då fungerar det. 

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

        //public string Delete(int id)
        //{

        //}
    }
}
