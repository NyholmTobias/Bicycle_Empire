namespace Bicycle_Empire
{
    public class Rental_Orders
    {
        public int order_number { get; set; }
        public string order_date { get; set; }
        public string return_date { get; set; }
        public int customer_id { get; set; }
        public int bicycle_id { get; set; }
        
        // Sätter bara getters på nedan eftersom det är computed resultat i tabellen vilket innebär att de inte går att ändra.
        public int rent_time { get; }
        public int days_rented { get; }
    }
}
