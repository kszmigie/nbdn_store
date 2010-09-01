using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class ViewProductsSpecs
    {
        public abstract class concern : Observes<ApplicationCommand,
                                            ViewProducts>
        {
        }

        [Subject(typeof(ViewProductsSpecs))]
        public class when_processing_request : concern
        {
            Establish c = () =>
            {
                renderer = the_dependency<Renderer>();
                default_catalog_browsing_tasks = the_dependency<CatalogBrowsingTasks>();
                request = an<Request>();

                all_dept_products = new List<Product>();
                department = new Department();

                request.Stub(x => x.map<Department>()).Return(department);
                default_catalog_browsing_tasks.Stub(x => x.get_all_products_in(department)).Return(all_dept_products);
            };

            Because b = () => sut.process(request);

            It should_tell_the_renderer_to_render_the_products = () =>
                renderer.received(x => x.render(all_dept_products));

            static IEnumerable<Product> all_dept_products;
            static Request request;
            static CatalogBrowsingTasks default_catalog_browsing_tasks;
            static Department department;
            static Renderer renderer;
        }
    }
}