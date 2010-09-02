namespace nothinbutdotnetstore.model
{
    public class Department
    {
        public string name { get; set; }
        public Department parent_department { get; set; }
        public bool has_products { get; set; }
    }
}