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

        public List<Invoice_Info> GetByString(string category, string input)
        {
            if (category == "invoice_number" || category == "order_number" || category == "customer_id")
            {
                List<Invoice_Info> invoiceInfo = this.db.Query<Invoice_Info>($"SELECT * FROM Customers WHERE {category} = {int.Parse(input)} ORDER BY {category}").ToList();
                return invoiceInfo;
            }
            else if (category == "postal_number")
            {
                List<Invoice_Info> invoiceInfo = this.db.Query<Invoice_Info>($"SELECT * FROM Customers WHERE {category} LIKE '%{int.Parse(input)}%' ORDER BY {category}").ToList();
                return invoiceInfo;
            }
            else
            {
                List<Invoice_Info> invoiceInfo = this.db.Query<Invoice_Info>($"SELECT * FROM Customers WHERE {category} LIKE '%{input}%' ORDER BY {category}").ToList();
                return invoiceInfo;
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
