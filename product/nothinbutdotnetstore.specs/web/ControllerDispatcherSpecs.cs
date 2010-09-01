 using System.Data;
 using System.Security.Principal;
 using System.Threading;
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
                 request = an<Request>();

                 request_factory.Stub(factory => factory.create_from(the_context)).Return(request);
             };

             Because b = () =>
                 sut.ProcessRequest(the_context);

             It should_dispatch_to_the_front_controller = () =>
                 front_controller.received(controller => controller.process(request));

             static FrontController front_controller;
             static Request request;
             static HttpContext the_context;
             static RequestFactory request_factory;
         }

         [Subject(typeof(ControllerDispatcher))]
         public class when_creating_a_controller_dispatcher : concern
         {
             //Establish c = () =>
             //{
             //   the_dependency<DefaultRequestFactory>()                         
             //}


             //no because, as we are testing the creation of the sut
             //Because b = () => 
                 

             It should_use_the_default_front_controller = () =>
                 default_front_controller_factory.received(x => x.get_front_controller());

             private static DefaultFrontControllerFactory default_front_controller_factory;
         }
     }
 }
