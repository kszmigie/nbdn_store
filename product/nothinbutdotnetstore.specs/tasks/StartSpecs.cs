using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.tasks.startup;

namespace nothinbutdotnetstore.specs.tasks
{
    public class StartSpecs
    {
        public abstract class concern : Observes
        {

        }

        [Subject(typeof (StartSpecs))]
        public class when_starting_a_startup_configuration : concern
        {
            Establish c = () =>
                {
                    command_factory = an<StartupCommandFactory>();
                };

            Because b = () =>
                result = Start.by<FakeStartupCommand>(command_factory);

            It should_return_a_startup_builder = () =>
                result.ShouldBeAn<StartupBuilder>();

            It should_use_the_provided_factory_in_the_startup_builder =()=>
                result.ShouldBeAn<DefaultStartupBuilder>().command_factory.ShouldEqual(command_factory);

            static StartupBuilder result;
            static StartupBuilder expected_builder;
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
