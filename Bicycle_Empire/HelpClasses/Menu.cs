using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bicycle_Empire
{
    public static class Menu
    {
        public static void PrintMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome! \nWhat do you want to do?\n");
                Console.WriteLine("1. See all the info from a category.\n2. Search for information by entering a specific value.\n6. Exit\n");

                try
                {
                    Menu.HandleMainMenuInput(int.Parse(Console.ReadLine()));
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
                    Menu.PrintGetAllMenu();
                    break;
                case 2:
                    Menu.PrintGetSpecificMenu();
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
                Console.WriteLine("Pick a category to get all the information from.\n1.Customers.\n2.Bicycles.\n3.Orders.\n4.Prices.\n5.Invoices.");

                try
                {
                    Menu.HandleGetAllMenuInput(int.Parse(Console.ReadLine()));
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
                Console.WriteLine("Pick a table below to search in.\n1.Customers.\n2.Bicycles.\n3.Orders.\n4.Prices.\n5.Invoices.");
                try
                {
                    Menu.HandleGetSpecificMenuInput(int.Parse(Console.ReadLine()));
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

                    Console.WriteLine("What parameter do you want to filter your search by? Enter one of the numbers below.\n1 = Customer id\n2 = First name\n3 = Last name\n4 = Phone number");
                    category = int.Parse(Console.ReadLine());
                    Console.Clear();

                    switch (input)
                    {
                        case 1:
                            CustomersController customerCont = new CustomersController();

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

        //public static void PrintAddMenu()
        //{

        //}

        //public static int HandleAddMenuInput()
        //{

        //}

        //public static void PrintUpdateMenu()
        //{

        //}

        //public static int HandleUpdateMenuInput()
        //{

        //}

        //public static void PrintDeleteMenu()
        //{

        //}

        //public static int HandleDeleteMenuInput()
        //{

        //}
    }
}
