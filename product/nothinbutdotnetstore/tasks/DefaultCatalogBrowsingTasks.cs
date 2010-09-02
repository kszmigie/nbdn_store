using System;
using System.Collections.Generic;
using nothinbutdotnetstore.model;
using System.Linq;

namespace nothinbutdotnetstore.tasks
{
    public class DefaultCatalogBrowsingTasks : CatalogBrowsingTasks
    {
        private IEnumerable<Product> products;
        private IEnumerable<Department> departments;

        public DefaultCatalogBrowsingTasks(): this(
            Enumerable.Range(1, 10).Select(x => new Department{name = x.ToString("Department 0")}),
            Enumerable.Range(1, 10).Select(x => new Product { name = x.ToString("Product 0") })
            )
        {
            
        }

        public DefaultCatalogBrowsingTasks(IEnumerable<Department> departments, IEnumerable<Product> products)
        {
            this.departments = departments;
            this.products = products;
        }

        public IEnumerable<Department> get_all_departments()
        {
            return departments.Where(d => d.parent_department == null);
        }

        public IEnumerable<Department> get_sub_departments_in(Department parent_department)
        {
            return departments.Where(d => d.parent_department == parent_department);
        }

        public IEnumerable<Product> get_all_products_in(Department parent_department)
        {
            return products.Where(p => p.parent_department == parent_department);
        }
    }
}