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
            List<Customers> customers = this.db.Query<Customers>("SELECT * FROM Customers").ToList();
            
            return customers;
        }

        public List<Customers> GetByString(string category, string input)
        {
            if (category == "customer_id")
            {
                List<Customers> customers = this.db.Query<Customers>($"SELECT * FROM Customers WHERE {category} = {int.Parse(input)} ORDER BY {category}").ToList();
                return customers;
            }
            else if (category == "phone_number")
            {
                List<Customers> customers = this.db.Query<Customers>($"SELECT * FROM Customers WHERE {category} LIKE '%{int.Parse(input)}%' ORDER BY {category}").ToList();
                return customers;
            }
            else
            {
                List<Customers> customers = this.db.Query<Customers>($"SELECT * FROM Customers WHERE {category} LIKE '%{input}%' ORDER BY {category}").ToList();
                return customers;
            }
        }

        //public List<Customers> GetByInt(int input)
        //{

        //}

        //public Customers Add()
        //{

        //}

        //public Customers Update(int id)
        //{

        //}

        //public string Delete(int id)
        //{

        //}
    }
}
