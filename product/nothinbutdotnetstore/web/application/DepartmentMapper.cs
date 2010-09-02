using System;
using System.Collections.Specialized;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.web
{
    public class DepartmentMapper : Mapper<NameValueCollection, Department>
    {
        public const string name_tag = "name";
        public Department map(NameValueCollection input)
        {
            return new Department
                       {
                           name = input[name_tag]
                       };
        }
    }
}