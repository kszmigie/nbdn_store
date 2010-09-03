using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.basic;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureCoreServices : StartupCommand
    {
        StartupServices resolvers;

        public ConfigureCoreServices(StartupServices resolvers)
        {
            this.resolvers = resolvers;
        }

        public void run()
        {
            ResolverRegistry registry = new DefaultResolverRegistry(resolvers);
            var c = new DefaultContainer(registry);
            IOC.container_resolver = () => c;
            resolvers.register_dependency_factory<Container>(() => c);
        }
    }
}