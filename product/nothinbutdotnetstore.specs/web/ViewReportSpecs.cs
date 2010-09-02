using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
     public class ViewReportingSpecs
     {
         public abstract class concern : Observes<ApplicationCommand,
                                             ViewReporting>
         {
        
         }

         public class when_observation_name : concern
         {
        
             Establish c = () =>
            {
                renderer = the_dependency<Renderer>();
                default_catalog_browsing_tasks = the_dependency<CatalogBrowsingTasks>();
                request = an<Request>();

                all_departments = new List<Department>();
                department = new Department();

                request.Stub(x => x.map<Department>()).Return(department);
                default_catalog_browsing_tasks.Stub(x => x.GetAll<Department>()).Return(all_departments);
            };

            Because b = () => sut.process(request);

            It should__tell_the_renderer_to_render_the_departments_ = () => renderer.received(x => x.render(all_departments));
            
            static IEnumerable<Department> all_departments;
            static Request request;
            static CatalogBrowsingTasks default_catalog_browsing_tasks;
            static Department department;
            static Renderer renderer;
         }
     }

    
}