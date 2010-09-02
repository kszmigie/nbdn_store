using System;
using System.Collections.Generic;
using nothinbutdotnetstore.model;
using System.Linq;

namespace nothinbutdotnetstore.tasks
{
    public class DefaultCatalogBrowsingTasks : CatalogBrowsingTasks
    {
        private ProductRepository products;
        private DepartmentRepository departments;

        public DefaultCatalogBrowsingTasks(DepartmentRepository departments, ProductRepository products)
        {
            this.departments = departments;
            this.products = products;
        }

        public IEnumerable<Department> get_all_departments()
        {
            return departments.get_departments().Where(d => d.parent_department == null);
        }

        public IEnumerable<Department> get_sub_departments_in(Department parent_department)
        {
            return departments.get_departments().Where(d => d.parent_department == parent_department);
        }

        public IEnumerable<Product> get_all_products_in(Department parent_department)
        {
            return products.get_products().Where(p => p.parent_department == parent_department);
        }
    }
}