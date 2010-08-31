 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.application.catalogbrowsing;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs.web
 {   
     public class ViewMainDepartmentsSpecs
     {
         public abstract class concern : Observes<ApplicationCommand,
                                             ViewMainDepartments>
         {
        
         }

         [Subject(typeof(ViewMainDepartments))]
         public class when_observation_name : concern
         {
        
                 
         }
     }
 }
