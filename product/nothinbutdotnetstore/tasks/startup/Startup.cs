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
            StartupServices ss = new DefaultStartupServices();
            StartupCommandFactory command_factory = new DefaultStartupCommandFactory(ss);

            Start.by<ConfigureCoreServices>(command_factory)
                .followed_by<ConfigureInfrastructure>()
                .followed_by<ConfigureFrontController>()
                .followed_by<ConfigureRoutes>()
                .followed_by<ConfigureServiceLayer>()
                .finish_by<ConfigureMappers>();
        }
    }
}