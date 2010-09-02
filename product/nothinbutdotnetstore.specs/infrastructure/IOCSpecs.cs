 
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class IOCSpecs
    {
        public abstract class concern : Observes
        {

        }

        [Subject(typeof(IOC))]
        public class when_accessing_the_container_services : concern
        {
            Establish c = () =>
            {
                the_container = an<Container>();
                the_resolver = () => the_container;
                change(() => IOC.container_resolver).to(the_resolver);
            };

            Because b = () =>
                result = IOC.retrieve;

            It should_provide_access_to_the_underlying_container_framework = () =>
                result.ShouldEqual(the_container);

            static Container result;
            static Container the_container;
            static ContainerResolver the_resolver;
        }
    }
}
