using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.tasks
{
    public interface CatalogBrowsingTasks
    {
        //IEnumerable<T> GetAll<T>();
        //IEnumerable<TResult> GetAllFor<T, TResult>(T filterType);

        IEnumerable<Department> get_all_departments();
        IEnumerable<Department> get_sub_departments_in(Department departmentname);
        IEnumerable<Product> get_dept_products(Department dept);
    }
}