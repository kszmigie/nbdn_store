namespace nothinbutdotnetstore.model
{
    public class Product
    {
        private Department department;

        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        
        public Department parent_department
        {
            get { return department; }
            set
            {
                department = value;
                department.has_products = true;
            }
        }
        public decimal price { get; set; }
        public decimal quantity { get; set; }
    }
}