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
            List<Rental_Prices> rentalPrices = db.Query<Rental_Prices>("Select * From Rental_Prices").ToList();

            return rentalPrices;
        }

        public List<Rental_Prices> GetByString(string category, string input)
        {
            List<Rental_Prices> rentalPrices = db.Query<Rental_Prices>($"SELECT * FROM Rental_Prices WHERE {category} LIKE '%{int.Parse(input)}%' ORDER BY {category}").ToList();
            return rentalPrices;   
        }

        public int Add(Rental_Prices p)
        {
            var affectedRows = db.Execute($"INSERT INTO Rental_Prices(hour_price, day_price) VALUES (@hour_price, @day_price)", p);

            return affectedRows;
        }

        public void Update(int id, string category, string input)
        {
            db.Execute("UPDATE Rental_Prices " +
                    $"SET {category} = {double.Parse(input)} " +
                    $"WHERE price_category = {id}");
        }

        //public string Delete(int id)
        //{

        //}
    }
}
