using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bicycle_Empire
{
    static class Seeder
    {
        public static void FillData()
        {
            CustomersController cController = new CustomersController();
            BicyclesController bController = new BicyclesController();
            InvoiceInfoController iController = new InvoiceInfoController();
            RentalOrdersController oController = new RentalOrdersController();
            RentalPricesController pController = new RentalPricesController();

            string[] firstNames = { "Tobias", "Oliver", "Marcus", "Ninmar", "Robin", "Erik", "Johan", "Anders", "Johanna", "Sofia" };
            string[] lastNames = { "Nyholm", "Stenström", "Medina", "Karlsson", "Kamo", "Niklasson", "Johansson", "Svensson", "Enberg", "Svensson" };
            int[] phoneNumers = { 0768645167, 0763669581, 0758981235, 0752125886, 0735669852, 0752778412, 0769721001, 0705723698, 0768645112, 0758996521 };

            for(int i = 0; i < 10; i++)
            {
                cController.Add(new Customers { first_name = firstNames[i], last_name = lastNames[i], phone_number = phoneNumers[i] });
            }
        }

    }
}
