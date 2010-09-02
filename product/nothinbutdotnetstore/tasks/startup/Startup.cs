using System;
using System.Collections.Generic;
using System.Web;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.basic;
using nothinbutdotnetstore.tasks.startup.stubs;
using nothinbutdotnetstore.web.application.catalogbrowsing.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.tasks.startup
{
    public class Startup
    {
        public static void run()
        {
            IDictionary<Type, DependencyResolver> resolvers = new Dictionary<Type, DependencyResolver>();
            IOC.container_resolver = () => new DefaultContainer(new DefaultResolverRegistry(resolvers));

            var stub_repository = new StubRepository();
            resolvers = new Dictionary<Type, DependencyResolver>
                {
                    {typeof (FrontController), new FunctionalDependencyResolver(() => new DefaultFrontController(IOC.retrieve.an<CommandBroker>())) },
                    {typeof (CommandBroker), new FunctionalDependencyResolver(() => new DefaultCommandBroker(IOC.retrieve.an<IEnumerable<RequestCommand>>())) },
                    {typeof (IEnumerable<RequestCommand>), new FunctionalDependencyResolver(() => new StubSetOfCommands())},
                    {typeof (RequestFactory), new FunctionalDependencyResolver(() => new DefaultRequestFactory(IOC.retrieve.an<MappingGateway>()))},
                    {typeof (MappingGateway), new FunctionalDependencyResolver(() => new DefaultMappingGateway(IOC.retrieve.an<MapperRegistry>()))},
                    {typeof (MapperRegistry), new FunctionalDependencyResolver(() => new DefaultMapperRegistry(IOC.retrieve.an<Container>()))},
                    {typeof (CatalogBrowsingTasks), new FunctionalDependencyResolver(() => new DefaultCatalogBrowsingTasks(IOC.retrieve.an<Repository>()))},
                    {typeof (Renderer), new FunctionalDependencyResolver(() => new WebFormRenderer(IOC.retrieve.an<ViewBroker>()))},
                    {typeof (ViewBroker), new FunctionalDependencyResolver(() => new DefaultViewBroker())},
                    {typeof (Repository), new FunctionalDependencyResolver(()=> stub_repository)},
                    {typeof (IDictionary<Type, IDictionary<Type, Func<object>>>), new FunctionalDependencyResolver(() => StubSetOfMappers.set_of_mappers)}
                };

            WebFormRenderer.retriever = () => HttpContext.Current;
            ResolverRegistry resolver_registry = new DefaultResolverRegistry(StubResolverDictionary.resolvers);
        }
    }
}