using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class DefaultResolverRegistry : ResolverRegistry
    {
        private readonly IDictionary<Type, object> list_of_resolvers;

        public DefaultResolverRegistry(IDictionary<Type, object> list_of_resolvers)
        {
            this.list_of_resolvers = list_of_resolvers;
        }

        public DependencyResolver get_resolver_to_create(Type dependency)
        {
            object resolver_to_create;
            list_of_resolvers.TryGetValue(dependency, out resolver_to_create);
            return (DependencyResolver)resolver_to_create;
        }
    }
}