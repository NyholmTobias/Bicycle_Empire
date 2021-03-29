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
    class CustomersController
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);

        public List<Customers> GetAll()
        {
            //Returnerar en lista med alla objekt från en tabell.
            List<Customers> customers = db.Query<Customers>("SELECT * FROM Customers").ToList();
            
            return customers;
        }

        public List<Customers> GetByString(string category, string input)
        {
            //Letar upp rätt objekt utifrån de inmatade sökkriterierna. 
            if (category == "customer_id")
            {
                List<Customers> customers = db.Query<Customers>($"SELECT * FROM Customers WHERE {category} = {int.Parse(input)} ORDER BY {category}").ToList();
                return customers;
            }
            else if (category == "phone_number")
            {
                List<Customers> customers = db.Query<Customers>($"SELECT * FROM Customers WHERE {category} LIKE '%{int.Parse(input)}%' ORDER BY {category}").ToList();
                return customers;
            }
            else
            {
                List<Customers> customers = db.Query<Customers>($"SELECT * FROM Customers WHERE {category} LIKE '%{input}%' ORDER BY {category}").ToList();
                return customers;
            }
        }

        public int Add(Customers c)
        {
            // lägger till det inmatade objektet i databasen.
            var affectedRows = db.Execute($"INSERT INTO Customers(first_name, last_name, phone_number) VALUES (@first_name, @last_name, @phone_number)", c);

            return affectedRows;
        }

        public void Update(int id, string category, string input)
        {
            // Uppdaterar det valda objektet med den valda inputen.
            if (category == "phone_number")
            {
                db.Execute("UPDATE Customers " +
                        $"SET {category} = {int.Parse(input)} " +
                        $"WHERE bicycle_id = {id}");
            }
            
            db.Execute("UPDATE Customers " +
                        $"SET {category} = '{input}' " +
                        $"WHERE customer_id = {id}");
        }

        //public string Delete(int id)
        //{

        //}
    }
}
