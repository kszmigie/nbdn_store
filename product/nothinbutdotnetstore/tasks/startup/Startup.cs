using System;
using System.Collections.Generic;
using System.Web;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.basic;
using nothinbutdotnetstore.tasks.startup.stubs;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.tasks.startup
{
    public class Startup
    {
        public static void run()
        {
            WebFormRenderer.retriever = () => HttpContext.Current;
            ResolverRegistry resolver_registry = new DefaultResolverRegistry(StubResolverDictionary.resolvers);
            IOC.container_resolver = () => new DefaultContainer(resolver_registry);
        }
    }
}