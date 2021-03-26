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
    class InvoiceInfoController
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);

        public List<Invoice_Info> GetAll()
        {
            List<Invoice_Info> invoiceInfo = this.db.Query<Invoice_Info>("Select * From Invoice_Info").ToList();

            return invoiceInfo;
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
