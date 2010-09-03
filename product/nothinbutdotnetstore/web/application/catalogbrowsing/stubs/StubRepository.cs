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

        static int id = 0;
        int next_id { get { return ++id; } }

        public StubRepository()
        {
            departments = new List<Department>();
            products = new List<Product>();

            for (int departmentCounter = 0; departmentCounter < 10; departmentCounter++)
            {
                var main_department = new Department(next_id, string.Format("Department_{0}", departmentCounter));
                departments.Add(main_department);
                for (int subDepartmentCounter = 0; subDepartmentCounter < 5; subDepartmentCounter++)
                {
                    int sub_id = next_id;
                    var sub_department = new Department(sub_id,
                                                        string.Format("SubDepartment_{0}_{1}", main_department.id,
                                                                      sub_id), main_department.id);
                    departments.Add(sub_department);
                    for (int productCounter = 0; productCounter < 10; productCounter++)
                    {
                        products.Add(new Product{name = string.Format("Product_{0}_{1}_{2}", main_department.id, sub_department.id, productCounter), parent_department = sub_department});
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