using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.basic;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.tasks.startup.stubs;
using nothinbutdotnetstore.web;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.application.catalogbrowsing.stubs;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tasks.startup
{
    static class StartupHelpers
    {
        public static void add<T>(this IDictionary<Type, DependencyResolver> resolvers, Func<object> factory)
        {
            resolvers.Add(typeof(T), new FunctionalDependencyResolver(factory));
        }
    }

    public class Startup
    {
        static IDictionary<Type, DependencyResolver> resolvers = new Dictionary<Type, DependencyResolver>();

        public static void run()
        {
            StartupServices ss = new StubStartupServices();
            StartupCommandFactory command_factory = new DefaultStartupCommandFactory(ss);

            Start.by<ConfigureCoreServices>(command_factory)
                .followed_by<ConfigureInfrastructure>()
                .finish_by<ConfigureInfrastructure>();

//            configure_infrastructure();
//            configure_front_controller();
//            configure_routes();
//            configure_service_layer();
//            configure_mappers();
        }

        static void configure_mappers()
        {
            resolvers.add<Mapper<NameValueCollection, Department>>(() => new DepartmentMapper());
        }

        static void configure_service_layer()
        {
            resolvers.add<CatalogBrowsingTasks>(() => new DefaultCatalogBrowsingTasks(IOC.retrieve.an<Repository>()));
            Repository the_repository = new StubRepository();
            resolvers.add<Repository>(() => the_repository);
        }

        static void configure_infrastructure()
        {
            resolvers.add<MapperRegistry>(() => new DefaultMapperRegistry(IOC.retrieve.an<Container>()));
            resolvers.add<MappingGateway>(() => new DefaultMappingGateway(IOC.retrieve.an<MapperRegistry>()));
        }

        static void configure_routes()
        {
            resolvers.add<IEnumerable<RequestCommand>>(get_commands);
        }

        static void configure_front_controller()
        {
            resolvers.add<FrontController>(() => new DefaultFrontController(IOC.retrieve.an<CommandBroker>()));
            resolvers.add<CommandBroker>(() => new DefaultCommandBroker(IOC.retrieve.an<IEnumerable<RequestCommand>>()));
            resolvers.add<RequestFactory>(() => new DefaultRequestFactory(IOC.retrieve.an<MappingGateway>()));
            resolvers.add<ViewBroker>(() => new DefaultViewBroker(IOC.retrieve.an<DefaultViewPathRegistry>()));
            resolvers.add<Renderer>(() => new WebFormRenderer(IOC.retrieve.an<ViewBroker>()));
            resolvers.add<DefaultViewPathRegistry>(get_viewmappings);
            WebFormRenderer.retriever = () => HttpContext.Current;
        }

        static void configure_core_services()
        {
            ResolverRegistry registry = new DefaultResolverRegistry(resolvers);
            var c = new DefaultContainer(registry);
            IOC.container_resolver = () => c;
            resolvers.add<Container>(() => c);
        }

        static DefaultViewPathRegistry get_viewmappings()
        {
            var mappings = new DefaultViewPathRegistry();
            mappings.register_path_for<IEnumerable<Department>>("~/views/DepartmentBrowser.aspx");
            return mappings;
        }

        static object get_commands()
        {
            var commands = new List<RequestCommand>();
            commands.Add(new DefaultRequestCommand(r => r.application_command_name == "ViewMainDepartments.store",
                                                   new ViewMainDepartments(IOC.retrieve.an<CatalogBrowsingTasks>(),
                                                                           IOC.retrieve.an<Renderer>())));
            commands.Add(new DefaultRequestCommand(r => r.application_command_name == "ViewSubDepartments.store",
                                                   new ViewSubDepartments(IOC.retrieve.an<CatalogBrowsingTasks>(),
                                                                          IOC.retrieve.an<Renderer>())));
            return commands;
        }
    }
}