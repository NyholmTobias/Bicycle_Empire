namespace Bicycle_Empire
{
    class RentalOrderSearchResult
    {
        public int order_number { get; set; }
        public int customer_id { get; set; }
        public string order_date { get; set; }
        public string return_date { get; set; }
        public int bicycle_id { get; set; }
        public int rent_time { get; }
        public int days_rented { get; }
        public int price_category { get; set; }
        public string rental_status { get; set; }
        public int invoice_number { get; set; }
        public double total_price { get; set; } 
    }
}
