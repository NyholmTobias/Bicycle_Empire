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
                Console.WriteLine("Welcome! What do you want to do?\n");
                Console.WriteLine("1. See all the info from a category.\n");

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
                Console.WriteLine("Pick a category to get all the information from.\n");
                Console.WriteLine("1. Customers.\n");

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
            }
        }

        //public static void PrintGetSpecificMenu()
        //{

        //}

        //public static int HandleGetSpecificMenuInput()
        //{

        //}

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
