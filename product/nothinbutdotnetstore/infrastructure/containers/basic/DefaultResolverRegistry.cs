using System;
using System.Collections;
using System.Collections.Generic;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class DefaultResolverRegistry : ResolverRegistry
    {
        IDictionary<Type, DependencyResolver> resolvers_map;

        public DefaultResolverRegistry(IDictionary<Type, DependencyResolver> resolvers_map)
        {
            this.resolvers_map = resolvers_map;
        }

        public DependencyResolver get_resolver_to_create(Type dependency)
        {
            try
            {
                return resolvers_map[dependency];
            }
            catch (KeyNotFoundException e)
            {
                throw new DependencyResolverNotFoundException(dependency, e);
            }
        }
    }
}