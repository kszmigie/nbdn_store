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
                    expected_builder = an<StartupBuilder>();
                };

            Because b = () =>
                result = Start.by<FakeStartupCommand>();

            It should_return_a_startup_builder = () =>
                result.ShouldBeAn<StartupBuilder>();

            static StartupBuilder result;
            static StartupBuilder expected_builder;
        }
        
        class FakeStartupCommand : StartupCommand
        {
            public void run()
            {
                
            }
        }

    }
}
