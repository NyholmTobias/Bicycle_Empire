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
