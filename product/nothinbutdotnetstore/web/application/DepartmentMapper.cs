using System;
using System.Collections.Specialized;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.web
{
    public class DepartmentMapper : Mapper<NameValueCollection, Department>
    {
        public const string id_tag = "department_id";
        public Department map(NameValueCollection input)
        {
            return new Department(Convert.ToInt32(input[id_tag]));
        }
    }
}