using System;
using System.Collections.Generic;

namespace Bicycle_Empire
{
    public static class StatusUpdate
    {
        /// <summary>
        /// Kör denna varje dag för att uppdatera status på cyklar och ordrar. Returnerar sedan en lista med orders som lämnats in. 
        /// </summary>
        public static List<Rental_Orders> DailyBicycleStatusUpdate()
        {
            RentalOrdersController oCont = new RentalOrdersController();
            BicyclesController bCont = new BicyclesController();

            List<Bicycles> bikes = bCont.GetAll();
            List<Rental_Orders> orders = oCont.GetAll();
            List<Rental_Orders> ordersToCheck = new List<Rental_Orders>();

            //Kollar om dagens datum är större än det satta inlämningsdatumet på varje order och att cykeln på ordern inte har status tillgänglig. Om det stämmer så ändras status på cykeln. 
            foreach (var bike in bikes)
            {
                if (bike.rental_status != "Vacant")
                {
                    foreach (var order in orders)
                    {
                        if (DateTime.Compare(DateTime.Now, DateTime.Parse(order.return_date)) > 0 && bike.bicycle_id == order.bicycle_id)
                        {
                            bCont.Update(order.bicycle_id, "rental_status", $"Past return date, see order {order.order_number}");
                            ordersToCheck.Add(order);
                        }
                    }
                }
            }

            return ordersToCheck;
        }
    }
}
