namespace Bicycle_Empire
{
    static class Seeder
    {
        // Fyller databasen med data om den är tom.
        public static void FillData()
        {
            CustomersController cController = new CustomersController();
            BicyclesController bController = new BicyclesController();
            InvoiceInfoController iController = new InvoiceInfoController();
            RentalOrdersController oController = new RentalOrdersController();
            RentalPricesController pController = new RentalPricesController();

            string[] firstNames = { "Tobias", "Oliver", "Bilbo", "Ninmar", "Robin", "Erik", "Johan", "Anders", "Johanna", "Sofia" };
            string[] lastNames = { "Nyholm", "Stenström", "Baggins", "Karlsson", "Kamo", "Niklasson", "Johansson", "Svensson", "Enberg", "Svensson" };
            int[] phoneNumers = { 0768645167, 0763669581, 0758981235, 0752125886, 0735669852, 0752778412, 0769721001, 0705723698, 0768645112, 0758996521 };

            for (int i = 0; i < 10; i++)
            {
                cController.Add(new Customers { first_name = firstNames[i], last_name = lastNames[i], phone_number = phoneNumers[i] });
            }

            double[] hourPrices = { 150, 160, 170, 180, 190, 200, 210, 220, 230, 240 };
            double[] dayPrices = { 2000, 2200, 2300, 2400, 2500, 2600, 2700, 2800, 2900, 3000 };

            for (int i = 0; i < 10; i++)
            {
                pController.Add(new Rental_Prices { hour_price = hourPrices[i], day_price = dayPrices[i] });
            }

            string[] status = { "Rented", "Rented", "Rented", "Rented", "Rented", "Rented", "Rented", "Rented", "Rented", "Rented" };
            string[] models = { "Trek", "Colnago", "Raleigh", "BMC", "Cervelo", "Colnago", "Trek", "BMX", "BMC", "Cersent" };
            int[] priceCategories = { 1, 2, 3, 4, 5, 6, 7, 3, 5, 1 };

            for (int i = 0; i < 10; i++)
            {
                bController.Add(new Bicycles { model = models[i], price_category = priceCategories[i], rental_status = status[i] });
            }

            string[] returnDates = { "2021-04-26 07:00:00", "2021-04-26 07:00:00", "2021-04-26 07:00:00", "2021-04-26 07:00:00", "2021-04-26 07:00:00", "2021-04-26 07:00:00", "2021-04-26 07:00:00", "2021-04-26 07:00:00", "2021-04-26 07:00:00", "2021-04-26 07:00:00" };
            int[] customerID = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] bicycleID = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            for (int i = 0; i < 10; i++)
            {
                oController.Add(new Rental_Orders { return_date = returnDates[i], customer_id = customerID[i], bicycle_id = bicycleID[i] });
            }

            string[] invoiceAdresses = { "Lärdomsgatan 9", "Envägen 5", "Hobbit road 5", "Wallaby way 42", "Sjuntorpsgatan 7", "Hagen 82", "Dammhagen 228", "Inlandsvägen 2", "Klammergatan 8", "Vägen 1" };
            string[] coAdresses = { "LGH 1011", "Baksidan", "You shall not pass", "P. Sherman", "", "", "Lugnet", "", "Klammen", "Gatan" };
            int[] postalNumbers = { 41753, 46375, 44231, 47116, 41671, 44852, 48231, 47593, 44752, 42351 };
            string[] cities = { "Göteborg", "Enköping", "Fylke", "Sydney", "Sjuntorp", "Haga town", "Hjärtum", "Västerås", "Klammerville", "Uppfarten" };
            int[] orderNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            for (int i = 0; i < 10; i++)
            {
                iController.Add(new Invoice_Info { invoice_adress = invoiceAdresses[i], co_adress = coAdresses[i], postal_number = postalNumbers[i], city = cities[i], customer_id = customerID[i], order_number = orderNumbers[i], first_name = firstNames[i], last_name = lastNames[i] });
            }

        }

    }
}
