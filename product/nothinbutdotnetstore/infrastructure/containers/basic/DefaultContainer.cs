using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class DefaultContainer : Container
    {
        ResolverRegistry resolver_registry;

        public DefaultContainer(ResolverRegistry resolver_registry)
        {
            this.resolver_registry = resolver_registry;
        }

        public Dependency an<Dependency>()
        {
            return (Dependency)an(typeof(Dependency));
        }

        public object an(Type dependency)
        {
            var resolver = resolver_registry.get_resolver_to_create(dependency);
            try
            {
                return resolver.create();
            }
            catch (Exception e)
            {
                throw new DependencyCreationException(dependency, e);
            }
        }
    }
}