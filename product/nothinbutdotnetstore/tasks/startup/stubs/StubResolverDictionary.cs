using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.basic;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.tasks.startup.stubs
{
    public class StubResolverDictionary
    {
        public static IDictionary<Type, Object> resolvers;

        static StubResolverDictionary()
        {
            //note: not sure if this should be a stub or not
            resolvers = new Dictionary<Type, object>
                {
                    {typeof (FrontController), new FunctionalDependencyResolver(() => new DefaultFrontController(IOC.retrieve.an<CommandBroker>())) },
                    {typeof (CommandBroker), new FunctionalDependencyResolver(() => new DefaultCommandBroker(IOC.retrieve.an<IEnumerable<RequestCommand>>())) },
                    {typeof (IEnumerable<RequestCommand>), new FunctionalDependencyResolver(() => new StubSetOfCommands())},
                    {typeof (RequestFactory), new FunctionalDependencyResolver(() => new DefaultRequestFactory(IOC.retrieve.an<MappingGateway>()))},
                    {typeof (MappingGateway), new FunctionalDependencyResolver(() => new DefaultMappingGateway(IOC.retrieve.an<MapperRegistry>()))},
                    {typeof (MapperRegistry), new FunctionalDependencyResolver(() => new DefaultMapperRegistry())},
                    {typeof (CatalogBrowsingTasks), new FunctionalDependencyResolver(() => new StubCatalogBrowsingTasks())},
                    {typeof (Renderer), new FunctionalDependencyResolver(() => new WebFormRenderer(IOC.retrieve.an<ViewBroker>()))},
                    {typeof (ViewBroker), new FunctionalDependencyResolver(() => new StubViewBroker())}
                };

        }
    }
}