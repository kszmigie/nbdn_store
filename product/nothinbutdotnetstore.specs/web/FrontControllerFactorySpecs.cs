using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs.web
 {   
     public class FrontControllerFactorySpecs
     {
         public abstract class concern : Observes<FrontControllerFactory, DefaultFrontControllerFactory>
         {
        
         }

         [Subject(typeof(DefaultFrontControllerFactory))]
         public class when_getting_the_front_controller : concern
         {

             Because b = () =>
                 front_controller = sut.get_front_controller();

             It should_return_a_front_controller_of_type_default_front_controller = () =>
                 front_controller.ShouldBeOfType(typeof(DefaultFrontController));

             private static FrontController front_controller;
                    
         }
     }
 }
