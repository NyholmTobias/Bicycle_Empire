namespace Bicycle_Empire
{
    class Program
    {
        // Jag har skrivit de flesta kommentarerna i klasserna Menu och CustomersController.
        // Strukturen är så att alla "Controller" klasser har hand om anropen till och från databasen. Menu klassen är bara en stödklass som har hand om utskrifter. 
        // Model är POCO klasser och är bara ramar för de objekt som hanteras av controller klasserna.  
        // De "vanliga" valen i huvudmenyn är till för att visa på att jag kan göra en CRUD-databas, medan valet "Real life example" är en kort simulation av hur ett verkligt företag hade kunnat använda sig av mjukvaran och databasen.
        static void Main(string[] args)
        {
            Menu.PrintMainMenu();
        }
    }
}
