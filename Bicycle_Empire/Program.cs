namespace Bicycle_Empire
{
    class Program
    {
        // Jag har skrivit de flesta kommentarerna i klasserna Menu och CustomersController.
        // Strukturen är så att alla "Controller" klasser har hand om anropen till och från databasen. Menu och Seeder klasserna är bara stödklasser som har hand om utskrifter och fyller på databasen. 
        // Model är POCO klasser och är bara ramar för de objekt som hanteras av controller klasserna.  
        // De "vanliga" valen i huvudmenyn är till för att visa på att jag kan göra en CRUD-databas.
        // Valet "Real life example" är en kort simulation av hur ett verkligt företag hade kunnat använda sig av mjukvaran och databasen.
        static void Main(string[] args)
        {
            Menu.PrintMainMenu();
        }
    }
}
