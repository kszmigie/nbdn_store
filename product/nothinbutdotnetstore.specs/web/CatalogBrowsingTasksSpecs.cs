using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.tasks;
using Machine.Specifications.DevelopWithPassion.Extensions;
using nothinbutdotnetstore.web.application.catalogbrowsing.stubs;
using Rhino.Mocks;

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
                                      var repository = (Repository)new StubRepository();
                                      provide_a_basic_sut_constructor_argument(repository);
                                      the_main_departments = repository.get_departments().Where(department => !department.has_parent_department);
                                  };

            Because b = () =>
                main_departments = sut.get_all_departments();
            
            It should_only_return_the_departments_without_parent_departments = () =>
                main_departments.ShouldContainOnly(the_main_departments);

            private static IEnumerable<Department> main_departments;
            private static IEnumerable<Department> the_main_departments;
        }

        [Subject(typeof(DefaultCatalogBrowsingTasks))]
        public class when_requesting_sub_departments : concern
        {
            private Establish c = () =>
            {
                var repository = (Repository)new StubRepository();
                provide_a_basic_sut_constructor_argument(repository);
                requested_department = repository.get_departments().First(department => !department.has_parent_department);
                the_sub_departments = repository.get_departments().Where(department => department.parent_department_id == requested_department.id);
            };
            
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
            private Establish c = () =>
            {
                var repository = new StubRepository();
                provide_a_basic_sut_constructor_argument((Repository)repository);
                requested_department = repository.get_departments().First(department => department.has_parent_department);
                the_products = repository.get_products().Where(department => department.parent_department == requested_department);
            };
            
            
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
