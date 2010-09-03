using System;
using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.tasks.startup;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class DefaultResolverRegistry : ResolverRegistry
    {
        StartupServices resolvers_map;

        public DefaultResolverRegistry(StartupServices resolvers_map)
        {
            this.resolvers_map = resolvers_map;
        }

        public DependencyResolver get_resolver_to_create(Type dependency)
        {
            try
            {
                return resolvers_map.get_resolver_for(dependency);
            }
            catch (KeyNotFoundException e)
            {
                throw new DependencyResolverNotFoundException(dependency, e);
            }
        }
    }
}