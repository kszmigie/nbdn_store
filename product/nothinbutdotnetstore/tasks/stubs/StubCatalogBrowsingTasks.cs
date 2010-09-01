using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.tasks.stubs
{
    public class StubCatalogBrowsingTasks : CatalogBrowsingTasks
    {
        public IEnumerable<T> GetAll<T>()
        {
            return new List<T>();
        }

        public IEnumerable<TResult> GetAllFor<T, TResult>(T filterType)
        {
            return new List<TResult>();
        }

        public IEnumerable<Department> get_all_departments()
        {
            return Enumerable.Range(1, 100).Select(x => new Department {name = x.ToString("Department 0")});
        }

        public IEnumerable<Department> get_sub_departments_in(Department departmentname)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> get_all_products_in(Department dept)
        {
            throw new NotImplementedException();
        }
    }
}