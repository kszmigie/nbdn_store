using System;
using System.Collections.Generic;
using nothinbutdotnetstore.model;
using System.Linq;

namespace nothinbutdotnetstore.tasks
{
    public class DefaultCatalogBrowsingTasks : CatalogBrowsingTasks
    {
        private Repository repository;

        public DefaultCatalogBrowsingTasks(Repository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Department> get_all_departments()
        {
            return repository.get_departments().Where(d => !d.has_parent_department);
        }

        public IEnumerable<Department> get_sub_departments_in(Department parent_department)
        {
            return repository.get_departments().Where(d => d.parent_department_id == parent_department.id);
        }

        public IEnumerable<Product> get_all_products_in(Department parent_department)
        {
            return repository.get_products().Where(p => p.parent_department == parent_department);
        }
    }
}
