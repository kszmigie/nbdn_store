using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.tasks.startup;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs.tasks
{
    public class StartupSpecs
    {
        public abstract class concern : Observes
        {
        }

        [Subject(typeof(Startup))]
        public class when_the_application_has_started_up : concern
        {
            Because b = Startup.run;

            It should_be_able_to_access_key_services = () =>
                IOC.retrieve.an<FrontController>().ShouldBeAn<DefaultFrontController>();
        }
    }
}