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
    class RentalPricesController
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);

        public List<Rental_Prices> GetAll()
        {
            List<Rental_Prices> rentalPrices = this.db.Query<Rental_Prices>("Select * From Rental_Prices").ToList();

            return rentalPrices;
        }

        public List<Rental_Prices> GetByString(string category, string input)
        {
            List<Rental_Prices> rentalPrices = this.db.Query<Rental_Prices>($"SELECT * FROM Rental_Prices WHERE {category} LIKE '%{int.Parse(input)}%' ORDER BY {category}").ToList();
            return rentalPrices;   
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
