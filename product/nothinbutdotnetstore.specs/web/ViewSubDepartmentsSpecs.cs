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
    public class ViewSubDepartmentsSpecs
    {
        public abstract class concern : Observes<ApplicationCommand,
                                            ViewSubDepartments>
        {
        }

        [Subject(typeof(ViewSubDepartments))]
        public class when_processing_request : concern
        {
            Establish c = () =>
            {
                request = an<Request>();
                default_catalog_browsing_tasks = the_dependency<CatalogBrowsingTasks>();
                all_sub_departments = new List<Department>();
                department = new Department();

                request.Stub(x => x.map<Department>()).Return(department);
                default_catalog_browsing_tasks.Stub(x => x.get_sub_departments_in(department)).Return(all_sub_departments);

                renderer = the_dependency<Renderer>();
            };

            Because b = () =>
                sut.process(request);

            It should_tell_the_renderer_to_render_the_sub_departments = () =>
                renderer.received(x => x.render(all_sub_departments));

            static CatalogBrowsingTasks default_catalog_browsing_tasks;
            static Renderer renderer;
            static Request request;
            static IEnumerable<Department> all_sub_departments;
            static Department department;
        }
    }
}