using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.tasks.stubs
{
    public class StubCatalogBrowsingTasks : CatalogBrowsingTasks
    {
        static int current_id = 0;
        static Department fruits;
        static Department fruits_common;
        static Department fruits_exotic;
        static Department meats;
        static Department candy;
        static Department meats_beef;
        static Department meats_rodent;

        static List<Department> all_departments = new List<Department>();

        static int next_id
        {
            get { return current_id++; }
        }


        static StubCatalogBrowsingTasks()
        {
            fruits = new Department(next_id, "Fruit");
            meats = new Department(next_id, "Meats");
            candy = new Department(next_id, "Candy");
            fruits_common = new Department(next_id, "Fruit", fruits.id);
            fruits_exotic = new Department(next_id, "Fruit", fruits.id);

            meats_beef = new Department(next_id, "Beef", meats.id);
            meats_rodent = new Department(next_id, "Rodent", meats.id);
            all_departments = new List<Department>
                                  {
                                      fruits,
                                      meats,
                                      candy,
                                      fruits_common,
                                      fruits_exotic,
                                      meats_beef,
                                      meats_rodent
                                  };
        }



        public IEnumerable<Department> get_all_departments()
        {
            return all_departments.Where(d => !d.has_parent_department);
        }

        public IEnumerable<Department> get_sub_departments_in(Department parent_department)
        {
            return all_departments.Where(d => d.has_parent_department && d.parent_department_id == parent_department.id);
        }

        public IEnumerable<Product> get_all_products_in(Department dept)
        {
            throw new NotImplementedException();
        }
    }
}