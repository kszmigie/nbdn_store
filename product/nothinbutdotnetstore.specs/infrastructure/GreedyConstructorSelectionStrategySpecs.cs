 using System.Reflection;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure.containers.basic;
 using System.Linq;

namespace nothinbutdotnetstore.specs.infrastructure
 {   
     public class GreedyConstructorSelectionStrategySpecs
     {
         public abstract class concern : Observes<ConstructorSelectionStrategy,
                                             GreedyConstructorSelectionStrategy>
         {
        
         }

         [Subject(typeof(GreedyConstructorSelectionStrategy))]
         public class when_asked_to_select_an_appropriate_constructor : concern
         {

             Because b = () =>
                result = sut.get_applicable_constructor_on(typeof (TheThing));


             It should_select_the_constructor_with_the_most_arguments = () =>
                 result.GetParameters().Count().ShouldEqual(4);

             static ConstructorInfo result;
         }


         class TheThing
         {
             public TheThing(string one, string two)
             {
                 
             }

             public TheThing(string one, string two, string three, string four)
             {
                 
             }


         }

     }
 }
