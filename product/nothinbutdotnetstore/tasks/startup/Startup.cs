
using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.basic;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.tasks.startup
{
    internal static class ResolverDictionaryExtensions
    {
        public static void add<T>(this Dictionary<Type, DependencyResolver> resolvers, Func<object> factory)
        {
            resolvers.Add(typeof(T), new FunctionalDependencyResolver(factory));
        }

    }

    public class Startup
    {
        public static void run()
        {

            Dictionary<Type, DependencyResolver> resolvers = new Dictionary<Type, DependencyResolver>();

            resolvers.add<IDictionary<Type, IDictionary<Type, object>>>(get_mappers);
            resolvers.add<MapperRegistry>(() => new DefaultMapperRegistry(IOC.retrieve.an<IDictionary<Type, IDictionary<Type, object>>>()));
            resolvers.add<MappingGateway>(() => new DefaultMappingGateway(IOC.retrieve.an<MapperRegistry>()));
            resolvers.add<RequestFactory>(() => new DefaultRequestFactory(IOC.retrieve.an<MappingGateway>()));
            resolvers.add<FrontController>(() => new DefaultFrontController(IOC.retrieve.an<CommandBroker>()));
            resolvers.add<CommandBroker>(() => new DefaultCommandBroker(IOC.retrieve.an<IEnumerable<RequestCommand>>()));
            resolvers.add<Renderer>(() => new WebFormRenderer(IOC.retrieve.an<ViewBroker>()));
            resolvers.add<IEnumerable<RequestCommand>>(get_commands);

            resolvers.add<ViewBroker>(() => new StubViewBroker());
            resolvers.add<CatalogBrowsingTasks>(() => new StubCatalogBrowsingTasks());
            
            ResolverRegistry registry = new DefaultResolverRegistry(resolvers);
            var c = new DefaultContainer(registry);

            IOC.container_resolver = () => c;
        }

        static object get_commands()
        {
            List<RequestCommand> commands = new List<RequestCommand>();
            commands.Add(new DefaultRequestCommand(r => true,
                                                   new ViewMainDepartments(IOC.retrieve.an<CatalogBrowsingTasks>(),
                                                                           IOC.retrieve.an<Renderer>())));
            return commands;
        }

        static object get_mappers()
        {
            Dictionary<Type, Dictionary<Type, object>> mappers = new Dictionary<Type, Dictionary<Type, object>>();
            return mappers;

        }
    }
}