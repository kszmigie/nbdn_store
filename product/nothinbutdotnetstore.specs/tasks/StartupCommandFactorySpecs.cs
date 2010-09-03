 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.tasks.startup;
 using Rhino.Mocks;
 using Machine.Specifications.DevelopWithPassion.Extensions;

namespace nothinbutdotnetstore.specs.tasks
 {   
     public class StartupCommandFactorySpecs
     {
         public abstract class concern : Observes<StartupCommandFactory,
                                             DefaultStartupCommandFactory>
         {
        
         }

         [Subject(typeof(DefaultStartupCommandFactory))]
         public class when_asked_to_construct_startup_command_from_type : concern
         {

             Establish c = () =>
                 {
                     startup_services = the_dependency<StartupServices>();
                 };

             Because b = () =>
                     result = sut.create_command_of(typeof(FakeStartupCommand));

             It should_create_command_an_pass_the_startup_services_to_the_created_command = () =>
                 result.ShouldBeAn<FakeStartupCommand>()
                       .startup_services.ShouldBeTheSameAs(startup_services);

             static StartupCommand result;
             static StartupServices startup_services;
         }

        class FakeStartupCommand : StartupCommand
        {
            public StartupServices startup_services;

            public FakeStartupCommand(StartupServices startup_services)
            {
                this.startup_services = startup_services;
            }

            public void run()
            {
                
            }
        }

     }
 }
