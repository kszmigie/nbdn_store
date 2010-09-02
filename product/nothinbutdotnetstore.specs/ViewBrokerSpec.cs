 using System;
 using System.Collections.Generic;
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
                                           expected_view = new DefaultViewFor<int>();
                                          viewsLookup = new Dictionary<Type, string>();
                                          viewsLookup.Add(typeof(int), "blah");
                                          provide_a_basic_sut_constructor_argument(viewsLookup);

                                           Func<string, Type, object> FakePageFactory =
                                               (path, type) => ((object) expected_view);
                                          change(() => DefaultViewBroker.PageFactory ).to( FakePageFactory );
                                       };

             private Because b = () =>
                                 result = sut.get_view_for<int>();

             private It should_return__correct_view = () => 
                 result.ShouldBe(typeof(ViewFor<int>));
             private static ViewFor<int> result;
             private static ViewFor<int> expected_view;
             private static IDictionary<Type, string> viewsLookup;
         }
     }
 }
