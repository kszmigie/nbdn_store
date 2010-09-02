 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.core;
 using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.specs
 {   
     public class ViewBrokerSpec
     {
         public abstract class concern : Observes<ViewBroker,
                                             DefaultViewBroker>
         {
        
         }

         [Subject(typeof(DefaultViewBroker))]
         public class when_view_for_type_is_requested : concern
         {
             private Establish c = () =>
                                       {
                                          
                                          provide_a_basic_sut_constructor_argument(); 
                                       };

             private Because b = () =>
                                 result = sut.get_view_for<int>();

             private It should_return__correct_view = () => 
                 result.ShouldEqual(expected_view);
             private static ViewFor<int> result;
             private static ViewFor<int> expected_view;
         }
     }
 }
