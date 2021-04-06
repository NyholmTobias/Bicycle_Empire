using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Bicycle_Empire
{
    class InvoiceInfoController : IController<Invoice_Info>
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);

        public List<Invoice_Info> GetAll()
        {
            List<Invoice_Info> invoiceInfo = db.Query<Invoice_Info>("Select * From Invoice_Info").ToList();

            return invoiceInfo;
        }

        public List<Invoice_Info> GetByString(string category, string input)
        {
            if (category == "invoice_number" || category == "order_number" || category == "customer_id")
            {
                List<Invoice_Info> invoiceInfo = db.Query<Invoice_Info>($"SELECT * FROM Invoice_Info WHERE {category} = {int.Parse(input)} ORDER BY {category}").ToList();
                return invoiceInfo;
            }
            else if (category == "postal_number")
            {
                List<Invoice_Info> invoiceInfo = db.Query<Invoice_Info>($"SELECT * FROM Invoice_Info WHERE {category} LIKE '%{int.Parse(input)}%' ORDER BY {category}").ToList();
                return invoiceInfo;
            }
            else
            {
                List<Invoice_Info> invoiceInfo = db.Query<Invoice_Info>($"SELECT * FROM Invoice_Info WHERE {category} LIKE '%{input}%' ORDER BY {category}").ToList();
                return invoiceInfo;
            }
        }

        public int Add(Invoice_Info i)
        {
            var affectedRows = db.Execute("INSERT INTO Invoice_Info(customer_id, order_number, first_name, last_name, invoice_adress, co_adress, postal_number, city) " +
                                          "VALUES (@customer_id, @order_number, @first_name, @last_name, @invoice_adress, @co_adress, @postal_number, @city)", i);

            return affectedRows;
        }

        public void Update(int id, string category, string input)
        { 
            if (category == "customer_id" || category == "order_number" || category == "postal_number")
            {
                db.Execute("UPDATE Rental_Orders " +
                        $"SET {category} = {int.Parse(input)} " +
                        $"WHERE order_number = {id}");
            }
            else
            {
                db.Execute("UPDATE Rental_Orders " +
                            $"SET {category} = '{input}' " +
                            $"WHERE order_number = {id}");
            }
        }

        public int Delete(int id)
        {
            var effectedRows = db.Execute("DELETE FROM Invoice_Info" +
                                          $"WHERE invoice_number = {id}");

            return effectedRows;
        }
    }
}
