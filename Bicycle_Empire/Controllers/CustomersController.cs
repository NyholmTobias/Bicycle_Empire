using Dapper;
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
            List<Customers> customers = db.Query<Customers>("SELECT * FROM Customers").ToList();
            
            return customers;
        }

        public List<Customers> GetByString(string category, string input)
        {
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

        public int Add(string firstName, string lastName, int phoneNumber)
        {
            var affectedRows = db.Execute($@"INSERT INTO Customers(first_name, last_name, phone_number) VALUES (@first_name, @last_name, @phone_number)", new Customers {first_name = firstName, last_name = lastName, phone_number = phoneNumber });

            return affectedRows;
        }

        //public Customers Update(int id)
        //{

        //}

        //public string Delete(int id)
        //{

        //}
    }
}
