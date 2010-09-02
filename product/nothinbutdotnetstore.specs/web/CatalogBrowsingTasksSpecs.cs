using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.tasks;
using Machine.Specifications.DevelopWithPassion.Extensions;

namespace nothinbutdotnetstore.specs.web
{
    public class CatalogBrowsingTasksSpecs
    {
        public abstract class concern : Observes<CatalogBrowsingTasks,
                                            DefaultCatalogBrowsingTasks>
        {
            Establish c = () =>
                {

                };
        }

        [Subject(typeof(DefaultCatalogBrowsingTasks))]
        public class when_requesting_all_departments : concern
        {
            private Establish c = () =>
                                  {
                                      the_main_departments = new List<Department>();
                                      Enumerable.Range(1, 10).each(i => the_main_departments.Add(new Department {name = string.Format("Department {0}", i)}));

                                      provide_a_basic_sut_constructor_argument<IEnumerable<Department>>(the_main_departments);
                                  };

            Because b = () =>
                main_departments = sut.get_all_departments();


            It should_only_return_the_departments_without_parent_departments = () =>
                main_departments.ShouldContainOnly(the_main_departments);

            private static IEnumerable<Department> main_departments;
            private static List<Department> the_main_departments;
        }

        [Subject(typeof(DefaultCatalogBrowsingTasks))]
        public class when_requesting_sub_departments : concern
        {
            Because b = () =>
                sub_departments = sut.get_sub_departments_in(requested_department);

            It should_only_return_the_departments_with_a_parent_department_of_the_specified_department = () =>
                sub_departments.ShouldContainOnly(the_sub_departments);

            private static IEnumerable<Department> sub_departments;
            private static IEnumerable<Department> the_sub_departments;
            private static Department requested_department;
        }

        [Subject(typeof(DefaultCatalogBrowsingTasks))]
        public class when_requesting_products : concern
        {
            Because b = () =>
                products = sut.get_all_products_in(requested_department);

            It should_only_return_the_products_with_a_parent_department_of_the_specified_department = () =>
                products.ShouldContainOnly(the_products);

            private static IEnumerable<Product> products;
            private static IEnumerable<Product> the_products;
            private static Department requested_department;
        }
    }
}
