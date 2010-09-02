using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.basic;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tasks.startup
{
    public class Startup
    {
        public static void run()
        {
            ResolverRegistry registry = null; // ToDo: implement
            var c = new DefaultContainer(registry);

//            registry.register<MapperRegistry>(()) => new Default
//            registry.register<MappingGateway>(() => new DefaultMappingGateway(IOC.retrieve.an<MapperRegistry>()));
//            registry.register<RequestFactory>(() => new DefaultRequestFactory(IOC.retrieve.an<MappingGateway>()));



            IOC.container_resolver = () => c;
        }
    }
}