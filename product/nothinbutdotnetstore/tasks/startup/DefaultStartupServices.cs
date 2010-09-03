using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure.containers.basic;

namespace nothinbutdotnetstore.tasks.startup
{
    public class DefaultStartupServices : StartupServices
    {
        IDictionary<Type, DependencyResolver> resolvers = new Dictionary<Type, DependencyResolver>();
        
        public void register_dependency_factory<Contract>(Func<object> resolver)
        {
            resolvers.Add(typeof (Contract), new FunctionalDependencyResolver(resolver));
        }

        public DependencyResolver get_resolver_for(Type dependency)
        {
            return resolvers[dependency];
        }
    }
}