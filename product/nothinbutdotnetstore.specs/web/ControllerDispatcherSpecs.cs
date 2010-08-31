 using System.Web;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.specs.utility;
 using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
 {   
     public class ControllerDispatcherSpecs
     {
         public abstract class concern : Observes<IHttpHandler,
                                             ControllerDispatcher>
         {
        
         }

         [Subject(typeof(ControllerDispatcher))]
         public class when_processing_an_http_context : concern
         {
             Establish c = () =>
             {
                 request_factory = the_dependency<RequestFactory>();
                 front_controller = the_dependency<FrontController>();

                 the_context = ObjectMother.create_http_context();
                 request = new object();

                 request_factory.Stub(factory => factory.create_from(the_context)).Return(request);
             };

             Because b = () =>
                 sut.ProcessRequest(the_context);

             It should_dispatch_to_the_front_controller = () =>
                 front_controller.received(controller => controller.process(request));

             static FrontController front_controller;
             static object request;
             static HttpContext the_context;
             static RequestFactory request_factory;
         }
     }
 }
