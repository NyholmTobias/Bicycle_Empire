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
    class RentalOrdersController
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);

        public List<Rental_Orders> GetAll()
        {
            List<Rental_Orders> rentalOrders = this.db.Query<Rental_Orders>("Select * From Rental_Orders").ToList();

            return rentalOrders;
        }

        public List<Rental_Orders> GetByString(string category, string input)
        {
            if (category == "order_date" || category == "return_date")
            {
                List<Rental_Orders> rentalOrders = this.db.Query<Rental_Orders>($"SELECT * FROM Rental_Orders WHERE {category} LIKE '%{input}%' ORDER BY {category}").ToList();
                return rentalOrders;
            }
            else
            {
                List<Rental_Orders> rentalOrders = this.db.Query<Rental_Orders>($"SELECT * FROM Rental_Orders WHERE {category} LIKE '%{int.Parse(input)}%' ORDER BY {category}").ToList();
                return rentalOrders;
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
