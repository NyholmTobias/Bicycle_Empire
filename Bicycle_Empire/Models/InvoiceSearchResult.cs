namespace Bicycle_Empire
{
    class InvoiceSearchResult
    {
        public int invoice_number { get; set; }
        public string invoice_adress { get; set; }
        public string co_adress { get; set; }
        public int postal_number { get; set; }
        public string city { get; set; }
        public int order_number { get; set; }
        public int customer_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int price_category { get; set; }
        public double total_price { get; set; }
    }
}
