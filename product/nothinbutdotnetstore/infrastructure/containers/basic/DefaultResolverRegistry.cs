using System;
using System.Collections;
using System.Collections.Generic;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class DefaultResolverRegistry : ResolverRegistry
    {
        IDictionary<Type, DependencyResolver> resolvers;

        public DefaultResolverRegistry(IDictionary<Type, DependencyResolver> resolvers)
        {
            this.resolvers = resolvers;
        }

        public DependencyResolver get_resolver_to_create(Type dependency)
        {
            return resolvers[dependency];
        }
    }
}