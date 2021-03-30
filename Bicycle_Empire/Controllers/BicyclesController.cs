using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Bicycle_Empire
{
    class BicyclesController
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);

        public List<Bicycles> GetAll()
        {
            List<Bicycles> bicycles = db.Query<Bicycles>("Select * From Bicycles").ToList();

            return bicycles;
        }

        public List<Bicycles> GetByString(string category, string input)
        {
            if (category == "bicycle_id")
            {
                List<Bicycles> bicycles = db.Query<Bicycles>($"SELECT * FROM Bicycles WHERE {category} = {int.Parse(input)} ORDER BY {category}").ToList();
                return bicycles;
            }
            else if (category == "price_category")
            {
                List<Bicycles> bicycles = db.Query<Bicycles>($"SELECT * FROM Bicycles WHERE {category} = {int.Parse(input)} ORDER BY {category}").ToList();
                return bicycles;
            }
            else
            {
                List<Bicycles> bicycles = db.Query<Bicycles>($"SELECT * FROM Bicycles WHERE {category} LIKE '%{input}%' ORDER BY {category}").ToList();
                return bicycles;
            }
        }

        public int Add(Bicycles b)
        {
            // Behöver inte lägga in rental_status eftersom den sätts som "Vacant" by default. 
            var affectedRows = db.Execute($"INSERT INTO Bicycles(price_category, model) VALUES (@price_category, @model)", b);

            return affectedRows;
        }

        public void Update(int id, string category, string input)
        {
            if (category == "price_category")
            {
                db.Execute("UPDATE Bicycles " +
                        $"SET {category} = {int.Parse(input)} " +
                        $"WHERE bicycle_id = {id}");
            }
            else
            {
                db.Execute("UPDATE Bicycles " +
                            $"SET {category} = '{input}' " +
                            $"WHERE bicycle_id = {id}");
            }
        }

    }
}
