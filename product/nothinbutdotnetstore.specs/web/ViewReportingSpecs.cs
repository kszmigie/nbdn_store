 using Machine.Specifications;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs.web
 {   
     public class ViewReportingSpecs
     {
         public abstract class concern : Observes<ApplicationCommand,
                                             ViewReporting>
         {
        
         }

         [Subject(typeof(contract_implementation))]
         public class when_observation_name : concern
         {
        
             It first_observation = () =>        
                    
         }
     }
 }
