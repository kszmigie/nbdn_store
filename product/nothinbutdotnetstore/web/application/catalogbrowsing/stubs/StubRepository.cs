using System;
using System.Collections.Generic;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.tasks;
using System.Linq;

namespace nothinbutdotnetstore.web.application.catalogbrowsing.stubs
{
    public class StubRepository : Repository
    {
        private IList<Department> departments;
        private IList<Product> products;

        public StubRepository()
        {
            departments = new List<Department>();
            products = new List<Product>();

            for (int departmentCounter = 0; departmentCounter < 10; departmentCounter++)
            {
                var department = new Department{name = string.Format("Department_{0}", departmentCounter)};
                departments.Add(department);
                for (int subDepartmentCounter = 0; subDepartmentCounter < 5; subDepartmentCounter++)
                {
                    var sub_department = new Department { name = string.Format("Department_{0}{1}", departmentCounter, subDepartmentCounter),parent_department=department };
                    departments.Add(sub_department);
                    for (int productCounter = 0; productCounter < 10; productCounter++)
                    {
                        products.Add(new Product{name = string.Format("Product_{0}{1}{2}", departmentCounter, subDepartmentCounter, productCounter)});
                    }
                }
            }
        }

        public IEnumerable<Department> get_departments()
        {
            foreach (var department in departments)
            {
                yield return department;
            }
        }

        public IEnumerable<Product> get_products()
        {
            foreach (var product in products)
            {
                yield return product;
            }
        }

        public Department get_department(string department_name)
        {
            return departments.First(department => department.name == department_name);
        }
    }
}