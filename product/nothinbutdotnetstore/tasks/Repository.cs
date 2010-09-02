using System.Collections.Generic;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.tasks
{
    public interface Repository
    {
        IEnumerable<Department> get_departments();
        IEnumerable<Product> get_products();
    }
}