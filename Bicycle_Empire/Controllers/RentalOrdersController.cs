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

        //public List<Customers> GetByString(string input)
        //{

        //}

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
