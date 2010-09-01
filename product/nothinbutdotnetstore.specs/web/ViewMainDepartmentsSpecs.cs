 using System.Collections.Generic;
 using System.Data;
 using System.Security.Principal;
 using System.Threading;
 using System.Web;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.model;
 using nothinbutdotnetstore.specs.utility;
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
                    default_gateway = the_dependency<DefaultGateway>();
                    path = "path";
                    provide_a_basic_sut_constructor_argument(path);
                    all_departments = new List<Department>() { new Department("test") };

                    default_gateway.Stub(x => x.get_all_departments()).Return(all_departments);
                    renderer = the_dependency<PageRenderer>();
                    renderer.Stub(x => x.Render(request, path, all_departments));
                };

             Because b = () =>
                 sut.process(request);

             It should_request_all_departments_from_gateway = () =>
                 default_gateway.received(x => x.get_all_departments());

             It should_call_render_with_gateway_provided_departments = () =>
                 renderer.received(x => x.Render(request, path, all_departments));

             private static DefaultGateway default_gateway;
             private static PageRenderer renderer;
             private static Request request;
             private static IEnumerable<Department> all_departments;
             private static string path;
         }
     }
 }
