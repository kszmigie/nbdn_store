using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class DefaultResolverRegistry : ResolverRegistry
    {
        IDictionary<Type, DependencyResolver> list_of_resolvers;

        public DefaultResolverRegistry(IDictionary<Type, DependencyResolver> list_of_resolvers)
        {
            this.list_of_resolvers = list_of_resolvers;
        }

        public DependencyResolver get_resolver_to_create(Type dependency)
        {
            try
            {
                return list_of_resolvers[dependency];
            }
            catch (KeyNotFoundException e)
            {
                throw new DependencyResolverNotFoundException(dependency);
            }
        }
    }
}