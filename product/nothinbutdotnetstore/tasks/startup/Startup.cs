using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.basic;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.web;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.application.catalogbrowsing.stubs;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tasks.startup
{
    internal static class StartupHelpers
    {
        public static void add<T>(this Dictionary<Type, DependencyResolver> resolvers, Func<object> factory)
        {
            resolvers.Add(typeof(T), new FunctionalDependencyResolver(factory));
        }

        public static void add<Input, Output>(this IDictionary<Type, IDictionary<Type, object>> mappers, Mapper<Input, Output>  mapper)
        {
            if (!mappers.ContainsKey(typeof(Input)))
            {
                mappers[typeof(Input)] = new Dictionary<Type, object>();
            }
            mappers[typeof (Input)][typeof (Output)] = mapper;
        }

    }

    public class Startup
    {
        public static void run()
        {
            var resolvers = new Dictionary<Type, DependencyResolver>();

            resolvers.add<IDictionary<Type, IDictionary<Type, object>>>(get_mappers);
            resolvers.add<MapperRegistry>(() => new DefaultMapperRegistry(IOC.retrieve.an<Container>()));
            resolvers.add<MappingGateway>(() => new DefaultMappingGateway(IOC.retrieve.an<MapperRegistry>()));
            resolvers.add<RequestFactory>(() => new DefaultRequestFactory(IOC.retrieve.an<MappingGateway>()));
            resolvers.add<FrontController>(() => new DefaultFrontController(IOC.retrieve.an<CommandBroker>()));
            resolvers.add<CommandBroker>(() => new DefaultCommandBroker(IOC.retrieve.an<IEnumerable<RequestCommand>>()));
            resolvers.add<Renderer>(() => new WebFormRenderer(IOC.retrieve.an<ViewBroker>()));
            resolvers.add<IEnumerable<RequestCommand>>(get_commands);
            resolvers.add<DefaultViewPathRegistry>(get_viewmappings);
            resolvers.add<ViewBroker>(() => new DefaultViewBroker(IOC.retrieve.an<DefaultViewPathRegistry>()));
            resolvers.add<CatalogBrowsingTasks>(() => new DefaultCatalogBrowsingTasks(IOC.retrieve.an<Repository>()));
            resolvers.add<Mapper<NameValueCollection, Department>>(() => new DepartmentMapper());

            Repository the_repository = new StubRepository();
            resolvers.add<Repository>(() => the_repository);
            
            ResolverRegistry registry = new DefaultResolverRegistry(resolvers);
            var c = new DefaultContainer(registry);

            resolvers.add<Container>(() => c);

            IOC.container_resolver = () => c;
            WebFormRenderer.retriever = () => HttpContext.Current;
        }

        static DefaultViewPathRegistry get_viewmappings()
        {
            var mappings = new DefaultViewPathRegistry();
            mappings.register_path_for<IEnumerable<Department>>( "~/views/DepartmentBrowser.aspx"); 
            return mappings;
        }

        static object get_commands()
        {
            List<RequestCommand> commands = new List<RequestCommand>();
            commands.Add(new DefaultRequestCommand(r => r.application_command_name == "ViewMainDepartments.store",
                                                   new ViewMainDepartments(IOC.retrieve.an<CatalogBrowsingTasks>(),
                                                                           IOC.retrieve.an<Renderer>())));
            commands.Add(new DefaultRequestCommand(r => r.application_command_name == "ViewSubDepartments.store",
                                                   new ViewSubDepartments(IOC.retrieve.an<CatalogBrowsingTasks>(),
                                                                           IOC.retrieve.an<Renderer>())));
            return commands;
        }

        static object get_mappers()
        {
            IDictionary<Type, IDictionary<Type, object>> mappers = new Dictionary<Type, IDictionary<Type, object>>();
            mappers.add(new DepartmentMapper());
            return mappers;
        }
    }
}