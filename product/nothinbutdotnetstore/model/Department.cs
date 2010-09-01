namespace nothinbutdotnetstore.model
{
    public class Department
    {
        private string department_name;

        public Department(string department_name)
        {
            this.department_name = department_name;
        }

        public string DepartmentName
        {
            get { return department_name; }
        }
    }
}