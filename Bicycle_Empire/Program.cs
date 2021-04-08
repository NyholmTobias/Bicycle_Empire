using System.Linq;

namespace Bicycle_Empire
{
    class Program
    {
        // Jag har skrivit de flesta kommentarerna i klasserna Menu och CustomersController.
        // "Controller" klasser har hand om anropen till och från databasen. 
        // Model är POCO klasser och är bara ramar för de objekt som hanteras av controller klasserna.
        // HelpClasses är statiska klasser som har hand om lite olika.
        // Menu hanterar utskrifter och input från användaren.
        // Seeder fyller på databasen automatiskt första gången man använder programmet.
        // StatusUpdate har en metod som fungerar som en daglig check, gå in i klassen så fattar du :)
        // InvoiceCreator skapar en faktura och visar den på skärmen. 
        // De "vanliga" valen i huvudmenyn är till för att visa på att jag kan göra en CRUD-databas.
        // Valet "Real life example" är en kort simulation av hur ett verkligt företag hade kunnat använda sig av mjukvaran och databasen.
        // PS. metoderna i Menu klassen som hanterar "real life" är roligast att kika närmare på! 
        static void Main(string[] args)
        {
            CustomersController c = new CustomersController();

            if (c.GetAll().Count() == 0)
            {
                Seeder.FillData();
            }
            Menu.PrintMainMenu();
        }
    }
}
