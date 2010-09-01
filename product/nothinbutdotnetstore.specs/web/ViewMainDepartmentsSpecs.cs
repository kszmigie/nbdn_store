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
    public class ViewMainDepartmentsSpecs
    {
        public abstract class concern : Observes<ApplicationCommand,
                                            ViewMainDepartments>
        {
        }

        [Subject(typeof(ViewMainDepartments))]
        public class when_processing_request : concern
        {
            Establish c = () =>
            {
                request = an<Request>();
                default_catalog_browsing_tasks = the_dependency<CatalogBrowsingTasks>();
                all_departments = new List<Department>();

                default_catalog_browsing_tasks.Stub(x => x.get_all_departments()).Return(all_departments);
                renderer = the_dependency<Renderer>();
            };

            Because b = () =>
                sut.process(request);

            It should_tell_the_renderer_to_render_the_main_departments = () =>
                renderer.received(x => x.render(all_departments));

            static CatalogBrowsingTasks default_catalog_browsing_tasks;
            static Renderer renderer;
            static Request request;
            static IEnumerable<Department> all_departments;
        }
    }
}