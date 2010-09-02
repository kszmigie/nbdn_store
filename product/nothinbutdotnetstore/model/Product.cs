namespace nothinbutdotnetstore.model
{
    public class Product
    {
        public string name { get; set; }
        public string description { get; set; }
        public Department parent_department { get; set; }
       public decimal price { get; set; }
    }
}