 using System;
 using System.Collections.Generic;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.tasks.startup;
 using Machine.Specifications.DevelopWithPassion.Extensions;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.tasks
 {   
     public class StartupBuilderSpecs
     {
         public abstract class concern : Observes<StartupBuilder,
                                             DefaultStartupBuilder>
         {
        
         }

         [Subject(typeof(DefaultStartupBuilder))]
         public class when_asked_to_include_a_startup_command : concern
         {
             Establish c = () =>
                 {
                     existing_types = new Type[0];
                     provide_a_basic_sut_constructor_argument(existing_types);
                 };


             Because b = () =>
                result = sut.followed_by<FakeStartupCommand>();

             It should_a_new_builder_to_allow_method_chaining = () =>
                result.ShouldBeAn<StartupBuilder>().ShouldNotEqual(sut);

             It should_keep_track_of_the_type_of_that_command = () =>
                 result.downcast_to<DefaultStartupBuilder>().command_types_to_create.ShouldContainOnly(typeof(FakeStartupCommand));

             static StartupBuilder result;
             static IEnumerable<Type> existing_types;
         }
         
         [Subject(typeof(DefaultStartupBuilder))]
         public class when_asked_to_include_an_additional_startup_command : concern
         {
             Establish c = () =>
                 {
                     existing_types = new Type[] {typeof (StartupCommand)};
                     provide_a_basic_sut_constructor_argument(existing_types);
                 };


             Because b = () =>
                result = sut.followed_by<FakeStartupCommand>();

             It should_keep_track_of_the_type_of_that_command = () =>
                 result.downcast_to<DefaultStartupBuilder>().command_types_to_create.ShouldContainOnly(
                 typeof(StartupCommand), 
                 typeof(FakeStartupCommand));

             static StartupBuilder result;
             static IEnumerable<Type> existing_types;
         }

         [Subject(typeof(DefaultStartupBuilder))]
         public class when_asked_to_finish_registration_of_startup_command : concern
         {
             Establish c = () =>
                 {
                     the_command = an<StartupCommand>();
                     existing_types = new Type[0];

                     command_factory = the_dependency<StartupCommandFactory>();
                     provide_a_basic_sut_constructor_argument(existing_types);

                     command_factory.Stub(cf => cf.create_command_of(typeof (FakeStartupCommand))).Return(the_command);
                 };


             Because b = () =>
                sut.finish_by<FakeStartupCommand>();

             It should_create_instances_of_startup_commands_and_invoke_run = () =>
                 the_command.received(c => c.run());

             static StartupBuilder result;
             static IEnumerable<Type> existing_types;
             static StartupCommand the_command;
             static StartupCommandFactory command_factory;
         }

        class FakeStartupCommand : StartupCommand
        {
            public void run()
            {
                
            }
        }
     }
 }
