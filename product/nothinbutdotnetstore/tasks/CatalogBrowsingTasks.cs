using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.tasks
{
    public interface CatalogBrowsingTasks
    {
        IEnumerable<Department> get_all_departments();
        IEnumerable<Department> get_sub_departments_in(Department parent_department);
        IEnumerable<Product> get_all_products_in(Department dept);
        Product get_product_details(int id);
    }

}