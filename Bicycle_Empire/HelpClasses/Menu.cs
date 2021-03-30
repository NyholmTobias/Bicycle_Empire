using System;
using System.Collections.Generic;
using System.Linq;

namespace Bicycle_Empire
{
    public static class Menu
    {
        public static void PrintMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--|| Bicycle Empire Database ||-- \nWhat do you want to do?\n");
                Console.WriteLine("1. See all the data in a table.\n2. Search for data by entering a specific value.\n3. Add a new instance to a table.\n4. Update data.\n5. Delete data.\n6. Exit\n");

                try
                {
                    HandleMainMenuInput(int.Parse(Console.ReadLine()));
                }
                catch
                {
                    Console.WriteLine("Wrong input, press any key and try again.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

        }

        internal static void HandleMainMenuInput(int input)
        {
            switch(input)
            {
                case 1:
                    PrintGetAllMenu();
                    break;
                case 2:
                    PrintGetSpecificMenu();
                    break;
                case 3:
                    PrintAddMenu();
                    break;
                case 4:
                    PrintUpdateMenu();
                    break;
                case 5:
                    PrintDeleteMenu();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Wrong input");
                    Console.ReadKey();
                    PrintMainMenu();
                    break;
            }
        }

        internal static void PrintGetAllMenu()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Pick a category to retrieve all data from it.\n1.Customers.\n2.Bicycles.\n3.Orders.\n4.Prices.\n5.Invoices.");

                try
                {
                    HandleGetAllMenuInput(int.Parse(Console.ReadLine()));
                    break;
                }
                catch
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Wrong input, press any key and try again!");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        internal static void HandleGetAllMenuInput(int input)
        {
            while (true)
            {
                try
                {
                    switch (input)
                    {
                        case 1:
                            CustomersController customerCont = new CustomersController();
                            Console.Clear();
                            Console.WriteLine("Below is all the information from the customers table.\n");
                            foreach (var c in customerCont.GetAll())
                            {
                                Console.WriteLine($"ID: {c.customer_id} \nFirst name: {c.first_name} \nLast name: {c.last_name} \nPhone number: +46{c.phone_number}\n");
                            }
                            Console.ReadLine();
                            break;
                        case 2:
                            BicyclesController bicycleCont = new BicyclesController();
                            Console.Clear();
                            Console.WriteLine("Below is all the information from the bicycles table.\n");
                            foreach (var b in bicycleCont.GetAll())
                            {
                                Console.WriteLine($"ID: {b.bicycle_id} \nModel: {b.model} \nPrice category: {b.price_category} \nRental status: {b.rental_status}\n");
                            }
                            Console.ReadLine();
                            break;
                        case 3:
                            RentalOrdersController orderCont = new RentalOrdersController();
                            Console.Clear();
                            Console.WriteLine("Below is all the information from the orders table.\n");
                            foreach (var o in orderCont.GetAll())
                            {
                                Console.WriteLine($"Order number: {o.order_number} \nCustomer id: {o.customer_id}\nBicycle id: {o.bicycle_id} \nOrder date: {o.order_date} \nReturn date: {o.return_date}\nRental hours: {o.rent_time}\nRental days: {o.days_rented}\n");
                            }
                            Console.ReadLine();
                            break;
                        case 4:
                            RentalPricesController priceCont = new RentalPricesController();
                            Console.Clear();
                            Console.WriteLine("Below is all the information from the price table.\n");
                            foreach (var p in priceCont.GetAll())
                            {
                                Console.WriteLine($"Price category: {p.price_category} \nHour price: {p.hour_price}\nDay price: {p.day_price} \n");
                            }
                            Console.ReadLine();
                            break;
                        case 5:
                            InvoiceInfoController invoiceCont = new InvoiceInfoController();
                            Console.Clear();
                            Console.WriteLine("Below is all the information from the invocie table.\n");
                            foreach (var i in invoiceCont.GetAll())
                            {
                                Console.WriteLine($"Invoice number: {i.invoice_number} \nCustomer id: {i.customer_id}\nOrder number: {i.order_number} \nName: {i.first_name} {i.last_name} \nAdress: {i.invoice_adress} \nC/O adress: {i.co_adress} \nPostal number: {i.postal_number} {i.city}\n");
                            }
                            Console.ReadLine();
                            break;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Wrong input, press any key and try again!");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        internal static void PrintGetSpecificMenu()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("What data do you want to search for?.\n1.Customer.\n2.Bicycle.\n3.Order.\n4.Price.\n5.Invoice.");
                try
                {
                    HandleGetSpecificMenuInput(int.Parse(Console.ReadLine()));
                    break;
                }
                catch
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Wrong input, press any key and try again!");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        internal static void HandleGetSpecificMenuInput(int input)
        {
            while (true)
            {
                try
                {
                    int category;
                    string sCategory;
                    string sInput;

                    switch (input)
                    {
                        case 1:
                            CustomersController customerCont = new CustomersController();

                            Console.Clear();
                            Console.WriteLine("What parameter do you want to filter your search by? Enter one of the numbers below.\n1 = Customer id\n2 = First name\n3 = Last name\n4 = Phone number");
                            category = int.Parse(Console.ReadLine());

                            if (category == 1)
                            {
                                sCategory = "customer_id";
                            }
                            else if (category == 2)
                            {
                                sCategory = "first_name";
                            }
                            else if (category == 3)
                            {
                                sCategory = "last_name";
                            }
                            else if (category == 4)
                            {
                                sCategory = "phone_number";
                            }
                            else
                            {
                                sCategory = null;
                            }
                            Console.Clear();

                            Console.Write("Now enter the search value. The input does not need to include the exact value just parts of it is ok. \nEnter the search value: \n");
                            sInput = Console.ReadLine();
                            Console.Clear();

                            Console.WriteLine("Result:\n");
                            foreach (var c in customerCont.GetByString(sCategory, sInput))
                            {
                                Console.WriteLine($"ID: {c.customer_id} \nFirst name: {c.first_name} \nLast name: {c.last_name} \nPhone number: +46{c.phone_number}\n");
                            }

                            Console.ReadKey();
                            break;
                        case 2:
                            BicyclesController bicycleCont = new BicyclesController();

                            Console.Clear();
                            Console.WriteLine("What parameter do you want to filter your search by? Enter one of the numbers below.\n1 = Bicycle id\n2 = Price category\n3 = Rental status\n4 = Model");
                            category = int.Parse(Console.ReadLine());

                            if (category == 1)
                            {
                                sCategory = "bicycle_id";
                            }
                            else if (category == 2)
                            {
                                sCategory = "price_category";
                            }
                            else if (category == 3)
                            {
                                sCategory = "rental_status";
                            }
                            else if (category == 4)
                            {
                                sCategory = "model";
                            }
                            else
                            {
                                sCategory = null;
                            }
                            Console.Clear();

                            Console.Write("Now enter the search value. The input does not need to include the exact value just parts of it is ok. \nEnter the search value: \n");
                            sInput = Console.ReadLine();
                            Console.Clear();

                            Console.WriteLine("Result:\n");
                            foreach (var b in bicycleCont.GetByString(sCategory, sInput))
                            {
                                Console.WriteLine($"ID: {b.bicycle_id} \nModel: {b.model} \nPrice category: {b.price_category} \nRental status: {b.rental_status}\n");
                            }

                            Console.ReadKey();
                            break;
                        case 3:
                            RentalOrdersController orderCont = new RentalOrdersController();

                            Console.Clear();
                            Console.WriteLine("What parameter do you want to filter your search by? Enter one of the numbers below.\n1 = Order number\n2 = Customer id\n3 = Bicycle id\n4 = Order date\n5 = Return date\n6 = Rental hours\n7 = Rental days");
                            category = int.Parse(Console.ReadLine());

                            if (category == 1)
                            {
                                sCategory = "order_number"; 
                            }
                            else if (category == 2)
                            {
                                sCategory = "customer_id";
                            }
                            else if (category == 3)
                            {
                                sCategory = "bicycle_id";
                            }
                            else if (category == 4)
                            {
                                sCategory = "order_date";
                            }
                            else if (category == 5)
                            {
                                sCategory = "return_date";
                            }
                            else if (category == 6)
                            {
                                sCategory = "rent_time";
                            }
                            else if (category == 7)
                            {
                                sCategory = "days_rented";
                            }
                            else
                            {
                                sCategory = null;
                            }
                            Console.Clear();

                            Console.Write("Now enter the search value. The input does not need to include the exact value just parts of it is ok. \nEnter the search value: \n");
                            sInput = Console.ReadLine();
                            Console.Clear();

                            Console.WriteLine("Result:\n");
                            foreach (var o in orderCont.GetByString(sCategory, sInput))
                            {
                                Console.WriteLine($"Order number: {o.order_number} \nCustomer id: {o.customer_id}\nBicycle id: {o.bicycle_id} \nOrder date: {o.order_date} \nReturn date: {o.return_date}\nRental hours: {o.rent_time}\nRental days: {o.days_rented}\n");
                            }

                            Console.ReadKey();
                            break;
                        case 4:
                            RentalPricesController priceCont = new RentalPricesController();

                            Console.Clear();
                            Console.WriteLine("What parameter do you want to filter your search by? Enter one of the numbers below.\n1 = Price category\n2 = Hour price\n3 = Day price");
                            category = int.Parse(Console.ReadLine());

                            if (category == 1)
                            {
                                sCategory = "price_category";
                            }
                            else if (category == 2)
                            {
                                sCategory = "hour_price";
                            }
                            else if (category == 3)
                            {
                                sCategory = "day_price";
                            }
                            else
                            {
                                sCategory = null;
                            }
                            Console.Clear();

                            Console.Write("Now enter the search value. The input does not need to include the exact value just parts of it is ok. \nEnter the search value: \n");
                            sInput = Console.ReadLine();
                            Console.Clear();

                            Console.WriteLine("Result:\n");
                            foreach (var p in priceCont.GetByString(sCategory, sInput))
                            {
                                Console.WriteLine($"Price category: { p.price_category} \nHour price: { p.hour_price}\nDay price: { p.day_price} \n");
                            }

                            Console.ReadKey();
                            break;
                        case 5:
                            InvoiceInfoController invoiceCont = new InvoiceInfoController();

                            Console.Clear();
                            Console.WriteLine("What parameter do you want to filter your search by? Enter one of the numbers below.\n1 = Invoice number\n2 = Customer id\n3 = Order number\n4 = First name\n5 = Last name\n6 = Adress\n7 = C/O adress\n8 = Postal number\n9 = City");
                            category = int.Parse(Console.ReadLine());

                            if (category == 1)
                            {
                                sCategory = "invoice_number";
                            }
                            else if (category == 2)
                            {
                                sCategory = "customer_id";
                            }
                            else if (category == 3)
                            {
                                sCategory = "order_number";
                            }
                            else if (category == 4)
                            {
                                sCategory = "first_name";
                            }
                            else if (category == 5)
                            {
                                sCategory = "last_name";
                            }
                            else if (category == 6)
                            {
                                sCategory = "invoice_adress";
                            }
                            else if (category == 7)
                            {
                                sCategory = "co_adress";
                            }
                            else if (category == 8)
                            {
                                sCategory = "postal_number";
                            }
                            else if (category == 9)
                            {
                                sCategory = "city";
                            }
                            else
                            {
                                sCategory = null;
                            }
                            Console.Clear();

                            Console.Write("Now enter the search value. The input does not need to include the exact value just parts of it is ok. \nEnter the search value: \n");
                            sInput = Console.ReadLine();
                            Console.Clear();

                            Console.WriteLine("Result:\n");
                            foreach (var i in invoiceCont.GetByString(sCategory, sInput))
                            {
                                Console.WriteLine($"Invoice number: {i.invoice_number} \nCustomer id: {i.customer_id}\nOrder number: {i.order_number} \nName: {i.first_name} {i.last_name} \nAdress: {i.invoice_adress} \nC/O adress: {i.co_adress} \nPostal number: {i.postal_number} {i.city}\n");
                            }

                            Console.ReadKey();
                            break;
                    }
                    break;
                }
                catch 
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Wrong input, press any key and try again!");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        internal static void PrintAddMenu()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("What data do you want to add?\n1.Customer.\n2.Bicycle.\n3.Order.\n4.Price.\n5.Invoice.");
                try
                {
                    HandleAddMenuInput(int.Parse(Console.ReadLine()));
                    break;
                }
                catch
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Wrong input, press any key and try again!");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        internal static void HandleAddMenuInput(int input)
        {    
            while (true)
            {
                try
                {
                    switch (input)
                    {
                        case 1:
                            CustomersController cController = new CustomersController();

                            Console.Clear();

                            Console.WriteLine("Enter the information below.\n");
                            Console.Write("First name: ");
                            var firstName = Console.ReadLine();
                            char.ToUpper(firstName[0]);
                            Console.Write("Last name: ");
                            var lastName = Console.ReadLine();
                            char.ToUpper(lastName[0]);
                            Console.Write("Phone number: ");
                            var phoneNumber = int.Parse(Console.ReadLine());

                            Console.Clear();

                            Console.WriteLine($"{cController.Add(new Customers { first_name = firstName, last_name = lastName, phone_number = phoneNumber })} new customer has been added");
                            Console.ReadKey();
                            break;

                        case 2:
                            BicyclesController bController = new BicyclesController();

                            Console.Clear();

                            Console.WriteLine("Enter the information below.\n");
                            Console.Write("Price category: ");
                            var priceCategory = int.Parse(Console.ReadLine());
                            Console.Write("Model: ");
                            var model = Console.ReadLine();

                            Console.Clear();

                            Console.WriteLine($"{bController.Add(new Bicycles { price_category = priceCategory, model = model })} new bike has been added");
                            Console.ReadKey();
                            break;

                        case 3:
                            RentalOrdersController oController = new RentalOrdersController();

                            Console.Clear();

                            Console.WriteLine("Enter the information below.\n");
                            Console.Write("Customer ID: ");
                            var customerID = int.Parse(Console.ReadLine());
                            Console.Write("Bicycle ID: ");
                            var bicycleID = int.Parse(Console.ReadLine());
                            Console.Write("Return date (format yyyy-mm-dd hh:mm:ss): ");
                            var returnDate = Console.ReadLine();

                            Console.Clear();

                            Console.WriteLine($"{oController.Add(new Rental_Orders { customer_id = customerID, bicycle_id = bicycleID, return_date = returnDate })} new order has been added");
                            Console.ReadKey();
                            break;

                        case 4:
                            RentalPricesController pController = new RentalPricesController();

                            Console.Clear();

                            Console.WriteLine("Enter the information below.\n");
                            Console.Write("Hour price: ");
                            var hourPrice = int.Parse(Console.ReadLine());
                            Console.Write("Day price: ");
                            var dayPrice = int.Parse(Console.ReadLine());

                            Console.Clear();

                            Console.WriteLine($"{pController.Add(new Rental_Prices { hour_price = hourPrice, day_price = dayPrice })} new price category has been added");
                            Console.ReadKey();
                            break;

                        case 5:
                            InvoiceInfoController iController = new InvoiceInfoController();

                            Console.Clear();

                            Console.WriteLine("Enter the information below.\n");
                            Console.Write("Customer id: ");
                            var customerId = int.Parse(Console.ReadLine());
                            Console.Write("Order number: ");
                            var orderNumber = int.Parse(Console.ReadLine());
                            Console.Write("First name: ");
                            firstName = Console.ReadLine();
                            char.ToUpper(firstName[0]);
                            Console.Write("Last name: ");
                            lastName = Console.ReadLine();
                            char.ToUpper(lastName[0]);
                            Console.Write("Invoice adress: ");
                            var invoiceAdress = Console.ReadLine();
                            Console.Write("C/O adress: ");
                            var coAdress = Console.ReadLine();
                            Console.Write("Postal number (format nnnnn): ");
                            var postalNumber = int.Parse(Console.ReadLine());
                            Console.Write("City: ");
                            var city = Console.ReadLine();
                            
                            Console.Clear();

                            Console.WriteLine($"{iController.Add(new Invoice_Info { customer_id = customerId, order_number = orderNumber, first_name = firstName, last_name = lastName, invoice_adress = invoiceAdress, co_adress = coAdress, postal_number = postalNumber, city = city })} new invoice has been added");
                            Console.ReadKey();
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.Write("Wrong input, press any key and try again.");
                    Console.ReadKey();
                }
                break;
            }
        }

        internal static void PrintUpdateMenu()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("What data do you want to update?\n1.Customer.\n2.Bicycle.\n3.Order.\n4.Price.\n5.Invoice.");
                try
                {
                    HandleUpdateMenuInput(int.Parse(Console.ReadLine()));
                    break;
                }
                catch
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Wrong input, press any key and try again!");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        internal static void HandleUpdateMenuInput(int input)
        {
            while (true)
            {
                try
                {
                    int category, id;
                    string sCategory;
                    string sInput;

                    switch (input)
                    {
                        case 1:
                            CustomersController customerCont = new CustomersController();
                            Console.Clear();

                            Console.Write("Enter the customer number that you want to update: ");
                            id = int.Parse(Console.ReadLine());

                            var customer = customerCont.GetByString("customer_id", $"{id.ToString()}").Single();
                            Console.WriteLine($"ID: {customer.customer_id} \nFirst name: {customer.first_name} \nLast name: {customer.last_name} \nPhone number: +46{customer.phone_number}\n");

                            Console.Write("What information do you want to update? Enter one of the numbers below.\n1 = First name\n2 = Last name\n3 = Phone number\n");
                            category = int.Parse(Console.ReadLine());

                            if (category == 1)
                            {
                                sCategory = "first_name";
                            }
                            else if (category == 2)
                            {
                                sCategory = "last_name";
                            }
                            else if (category == 3)
                            {
                                sCategory = "phone_number";
                            }
                            else
                            {
                                sCategory = null;
                            }

                            Console.Write("Now enter the new value: ");
                            sInput = Console.ReadLine();
                            Console.Clear();

                            customerCont.Update(id, sCategory, sInput);

                            Console.WriteLine("Result:\n");
                            customer = customerCont.GetByString("customer_id", $"{id.ToString()}").Single();
                            Console.WriteLine($"ID: {customer.customer_id} \nFirst name: {customer.first_name} \nLast name: {customer.last_name} \nPhone number: +46{customer.phone_number}\n");
                            
                            Console.ReadKey();
                            break;
                        case 2:
                            BicyclesController bicycleCont = new BicyclesController();
                            Console.Clear();

                            Console.Write("Enter the bicycle id that you want to update information on: ");
                            id = int.Parse(Console.ReadLine());
                            var bike = bicycleCont.GetByString("bicycle_id", $"{id.ToString()}").Single();
                            Console.WriteLine($"ID: {bike.bicycle_id} \nModel: {bike.model} \nPrice category: {bike.price_category} \nRental status: {bike.rental_status}\n");

                            Console.WriteLine("What information do you want to update? Enter one of the numbers below.\n1 = Price category\n2 = Rental status\n3 = model\n");
                            category = int.Parse(Console.ReadLine());

                            if (category == 1)
                            {
                                sCategory = "price_category";
                            }
                            else if (category == 2)
                            {
                                sCategory = "rental_status";
                            }
                            else if (category == 3)
                            {
                                sCategory = "model";
                            }
                            else
                            {
                                sCategory = null;
                            }

                            Console.Write("Now enter the new value: ");
                            sInput = Console.ReadLine();
                            Console.Clear();

                            bicycleCont.Update(id, sCategory, sInput);

                            Console.WriteLine("Result:\n");
                            bike = bicycleCont.GetByString("bicycle_id", $"{id.ToString()}").Single();
                            Console.WriteLine($"ID: {bike.bicycle_id} \nModel: {bike.model} \nPrice category: {bike.price_category} \nRental status: {bike.rental_status}\n");
                            

                            Console.ReadKey();
                            break;
                        case 3:
                            // OBS! kan inte uppdatera return_date eftersom det finns en CHECK på return_date i SQL som är felaktig. Man måste droppa den och lägga in följande kod: ALTER TABLE Rental_Orders
                            // ADD CHECK(return_date > order_date); Då fungerar det.

                            RentalOrdersController orderCont = new RentalOrdersController();
                            Console.Clear();

                            Console.Write("Enter the order number for the order that you want to update: ");
                            id = int.Parse(Console.ReadLine());
                            var order = orderCont.GetByString("order_number", $"{id.ToString()}").Single();
                            Console.WriteLine($"Order number: {order.order_number} \nCustomer id: {order.customer_id}\nBicycle id: {order.bicycle_id} \nOrder date: {order.order_date} \nReturn date: {order.return_date}\nRental hours: {order.rent_time}\nRental days: {order.days_rented}\n");

                            Console.WriteLine("What information do you want to update? Enter one of the numbers below.\n1 = Customer id\n2 = Bicycle id\n3 = Return date\n");
                            category = int.Parse(Console.ReadLine());

                            if (category == 1)
                            {
                                sCategory = "customer_id";
                            }
                            else if (category == 2)
                            {
                                sCategory = "bicycle_id";
                            }
                            else if (category == 3)
                            {
                                sCategory = "return_date";
                            }
                            else
                            {
                                sCategory = null;
                            }

                            Console.Write("Now enter the new value: ");
                            sInput = Console.ReadLine();
                            Console.Clear();

                            orderCont.Update(id, sCategory, sInput);

                            Console.WriteLine("Result:\n");
                            order = orderCont.GetByString("order_number", $"{id.ToString()}").Single();
                            Console.WriteLine($"Order number: {order.order_number} \nCustomer id: {order.customer_id}\nBicycle id: {order.bicycle_id} \nOrder date: {order.order_date} \nReturn date: {order.return_date}\nRental hours: {order.rent_time}\nRental days: {order.days_rented}\n");
                           

                            Console.ReadKey();
                            break;
                        case 4:
                            RentalPricesController priceCont = new RentalPricesController();
                            Console.Clear();

                            Console.Write("Enter the price category that you want to update: ");
                            id = int.Parse(Console.ReadLine());
                            var priceCat = priceCont.GetByString("price_category", $"{id.ToString()}").Single();
                            Console.WriteLine($"Price category: { priceCat.price_category} \nHour price: { priceCat.hour_price}\nDay price: { priceCat.day_price} \n");

                            Console.WriteLine("What information do you want to update? Enter one of the numbers below.\n1 = Hour price:\n2 = Day price:\n");
                            category = int.Parse(Console.ReadLine());

                            if (category == 1)
                            {
                                sCategory = "hour_price";
                            }
                            else if (category == 2)
                            {
                                sCategory = "day_price";
                            }
                            else
                            {
                                sCategory = null;
                            }

                            Console.Write("Now enter the new value: ");
                            sInput = Console.ReadLine();
                            Console.Clear();

                            priceCont.Update(id, sCategory, sInput);

                            Console.WriteLine("Result:\n");
                            priceCat = priceCont.GetByString("price_category", $"{id.ToString()}").Single();
                            Console.WriteLine($"Price category: { priceCat.price_category} \nHour price: { priceCat.hour_price}\nDay price: { priceCat.day_price} \n");

                            Console.ReadKey();
                            break;
                        case 5:
                            InvoiceInfoController invoiceCont = new InvoiceInfoController();
                            Console.Clear();

                            Console.Write("Enter the invoice number of the invoice that you want to update: ");
                            id = int.Parse(Console.ReadLine());
                            var i = invoiceCont.GetByString("invoice_number", $"{id.ToString()}").Single();
                            Console.WriteLine($"Invoice number: {i.invoice_number} \nCustomer id: {i.customer_id}\nOrder number: {i.order_number} \nName: {i.first_name} {i.last_name} \nAdress: {i.invoice_adress} \nC/O adress: {i.co_adress} \nPostal number: {i.postal_number} {i.city}\n");

                            Console.WriteLine("What information do you want to update? Enter one of the numbers below.\n1 = Customer id\n2 = Order number\n3 = First name\n4 = Last name\n5 = Adress\n6 = C/O adress\n7 = Postal number\n8 = City\n");
                            category = int.Parse(Console.ReadLine());

                            if (category == 1)
                            {
                                sCategory = "customer_id";
                            }
                            else if (category == 2)
                            {
                                sCategory = "order_number";
                            }
                            else if (category == 3)
                            {
                                sCategory = "first_name";
                            }
                            else if (category == 4)
                            {
                                sCategory = "last_name";
                            }
                            else if (category == 5)
                            {
                                sCategory = "invoice_adress";
                            }
                            else if (category == 6)
                            {
                                sCategory = "co_adress";
                            }
                            else if (category == 7)
                            {
                                sCategory = "postal_number";
                            }
                            else if (category == 8)
                            {
                                sCategory = "city";
                            }
                            else
                            {
                                sCategory = null;
                            }

                            Console.Write("Now enter the new value: ");
                            sInput = Console.ReadLine();
                            Console.Clear();

                            invoiceCont.Update(id, sCategory, sInput);

                            Console.WriteLine("Result:\n");
                            i = invoiceCont.GetByString("invoice_number", $"{id.ToString()}").Single();
                            Console.WriteLine($"Invoice number: {i.invoice_number} \nCustomer id: {i.customer_id}\nOrder number: {i.order_number} \nName: {i.first_name} {i.last_name} \nAdress: {i.invoice_adress} \nC/O adress: {i.co_adress} \nPostal number: {i.postal_number} {i.city}\n");

                            Console.ReadKey();
                            break;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Wrong input, press any key and try again!");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        internal static void PrintDeleteMenu()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("What data do you want to delete?\n1.Customer.\n2.Bicycle.\n3.Order.\n4.Price.\n5.Invoice.");
                try
                {
                    HandleDeleteMenuInput(int.Parse(Console.ReadLine()));
                    break;
                }
                catch
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Wrong input, press any key and try again!");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        internal static void HandleDeleteMenuInput(int input)
        {
            while (true)
            {
                try
                {
                    int id;
                    string confirmation;

                    switch (input)
                    {
                        case 1:
                            CustomersController customerCont = new CustomersController();
                            Console.Clear();

                            Console.Write("Enter the customer number that you want to delete: ");
                            id = int.Parse(Console.ReadLine());
                            var customer = customerCont.GetByString("customer_id", $"{id.ToString()}").Single();
                            Console.WriteLine($"ID: {customer.customer_id} \nFirst name: {customer.first_name} \nLast name: {customer.last_name} \nPhone number: +46{customer.phone_number}\n");

                            // Side note. I ett verkligt program skulle det vara mycket fler kriterier som ska uppfyllas för att kunna ta bort en kund eftersom det finns fakturor och liknande kopplat till den.  
                            Console.WriteLine("Are you sure that you want to delete this customer and all the data associated with it? Enter y/n.");
                            confirmation = Console.ReadLine();

                            if (confirmation.ToLower() == "y")
                            {
                                Console.Clear();
                                Console.WriteLine($"{customerCont.Delete(id)} row(s) has been deleted.");
                                Console.ReadKey();
                            }
                            else if (confirmation.ToLower() == "n")
                            {
                                Console.WriteLine("\nYou will be sent back to the main menu. Press any key.");
                                Console.ReadKey();
                                PrintMainMenu();
                            }
                            else
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine("Wrong input, press any key and try again!");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            
                            break;
                        case 2:
                            BicyclesController bicycleCont = new BicyclesController();
                            Console.Clear();

                            Console.Write("Enter the bicycle id that you want to delete: ");
                            id = int.Parse(Console.ReadLine());
                            var bike = bicycleCont.GetByString("bicycle_id", $"{id.ToString()}").Single();
                            Console.WriteLine($"ID: {bike.bicycle_id} \nModel: {bike.model} \nPrice category: {bike.price_category} \nRental status: {bike.rental_status}\n");

                            Console.WriteLine("Bicycles cant be deleted but the status can be changed to ''unavailable''. Do you want to continue? Enter y/n.");
                            confirmation = Console.ReadLine();

                            if (confirmation.ToLower() == "y")
                            {
                                Console.Clear();
                                bicycleCont.Update(id, "rental_status", "Unavailable");
                                Console.WriteLine($"The bicycle with id {id} has changed status to unavailable.");
                                Console.ReadKey();
                            }
                            else if (confirmation.ToLower() == "n")
                            {
                                Console.WriteLine("\nYou will be sent back to the main menu. Press any key.");
                                Console.ReadKey();
                                PrintMainMenu();
                            }
                            else
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine("Wrong input, press any key and try again!");
                                Console.ReadKey();
                                Console.Clear();
                            }

                            break;
                        case 3:
                            RentalOrdersController orderCont = new RentalOrdersController();
                            Console.Clear();

                            Console.Write("Enter the order number for the order that you want to delete: ");
                            id = int.Parse(Console.ReadLine());
                            var order = orderCont.GetByString("order_number", $"{id.ToString()}").Single();
                            Console.WriteLine($"Order number: {order.order_number} \nCustomer id: {order.customer_id}\nBicycle id: {order.bicycle_id} \nOrder date: {order.order_date} \nReturn date: {order.return_date}\nRental hours: {order.rent_time}\nRental days: {order.days_rented}\n");

                            // Ja, det kan vara flera fakturor kopplade till samma order. 
                            Console.WriteLine("Are you sure that you want to delete this order and all the invoices associated with it? Enter y/n.");
                            confirmation = Console.ReadLine();

                            if (confirmation.ToLower() == "y")
                            {
                                Console.Clear();
                                Console.WriteLine($"{orderCont.Delete(id)} row(s) has been deleted.");
                                Console.ReadKey();
                            }
                            else if (confirmation.ToLower() == "n")
                            {
                                Console.WriteLine("\nYou will be sent back to the main menu. Press any key.");
                                Console.ReadKey();
                                PrintMainMenu();
                            }
                            else
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine("Wrong input, press any key and try again!");
                                Console.ReadKey();
                                Console.Clear();
                            }

                            break;
                        case 4:
                            RentalPricesController priceCont = new RentalPricesController();
                            BicyclesController bicycleCont1 = new BicyclesController();
                            Console.Clear();

                            Console.Write("Enter the price category that you want to delete: ");
                            id = int.Parse(Console.ReadLine());
                            var priceCat = priceCont.GetByString("price_category", $"{id.ToString()}").Single();
                            Console.WriteLine($"Price category: { priceCat.price_category} \nHour price: { priceCat.hour_price}\nDay price: { priceCat.day_price} \n");

                            Console.WriteLine("Are you sure that you want to delete this price category? Enter y/n.");
                            confirmation = Console.ReadLine();

                            // Price category kan inte tas bort om det finns på en cykel, därför måste användaren ändra på de cyklar som innehåller den valda kategorin. 
                            if (confirmation.ToLower() == "y")
                            {
                                Console.Clear();
                                if (bicycleCont1.GetByString("price_category", id.ToString()).Count >= 1)
                                {
                                    Console.Write($"You need to change the price category on below bicycles before you can delete price category {id}.");
                                    List<Bicycles> bicyclesWithChosenPriceCategory = new List<Bicycles>();
                                    foreach(var b in bicyclesWithChosenPriceCategory)
                                    {
                                        Console.WriteLine($"ID: {b.bicycle_id} \nModel: {b.model} \nPrice category: {b.price_category} \nRental status: {b.rental_status}\n");
                                    }
                                    Console.WriteLine("\nYou will be sent back to the main menu. Press any key.");
                                    Console.ReadKey();
                                    PrintMainMenu();
                                }
                                else
                                {
                                    priceCont.Delete(id);
                                    Console.WriteLine($"Price category {id} has been deleted successfully.");
                                    Console.ReadKey();
                                }
                            }
                            else if (confirmation.ToLower() == "n")
                            {
                                Console.WriteLine("\nYou will be sent back to the main menu. Press any key.");
                                Console.ReadKey();
                                PrintMainMenu();
                            }
                            else
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine("Wrong input, press any key and try again!");
                                Console.ReadKey();
                                Console.Clear();
                            }

                            break;
                        case 5:
                            InvoiceInfoController invoiceCont = new InvoiceInfoController();
                            Console.Clear();

                            Console.Write("Enter the invoice number of the invoice that you want to delete: ");
                            id = int.Parse(Console.ReadLine());
                            var i = invoiceCont.GetByString("invoice_number", $"{id.ToString()}").Single();
                            Console.WriteLine($"Invoice number: {i.invoice_number} \nCustomer id: {i.customer_id}\nOrder number: {i.order_number} \nName: {i.first_name} {i.last_name} \nAdress: {i.invoice_adress} \nC/O adress: {i.co_adress} \nPostal number: {i.postal_number} {i.city}\n");

                            Console.WriteLine("Are you sure that you want to delete this invoice? Enter y/n.");
                            confirmation = Console.ReadLine();

                            if (confirmation.ToLower() == "y")
                            {
                                Console.Clear();
                                invoiceCont.Delete(id);
                                Console.WriteLine($"Invoice (invoice number {id}) has been deleted successfully.");
                                Console.ReadKey();
                            }
                            else if (confirmation.ToLower() == "n")
                            {
                                Console.WriteLine("\nYou will be sent back to the main menu. Press any key.");
                                Console.ReadKey();
                                PrintMainMenu();
                            }
                            else
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine("Wrong input, press any key and try again!");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Wrong input, press any key and try again!");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
