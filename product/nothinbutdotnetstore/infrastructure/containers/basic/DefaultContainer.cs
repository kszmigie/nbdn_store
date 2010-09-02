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
            var resolver = resolver_registry.get_resolver_to_create(typeof(Dependency));
            try
            {
                return (Dependency)resolver.create();
            }
            catch(Exception e)
            {
                throw new DependencyCreationException(typeof(Dependency), e);
            }
        }

        public object an(Type dependency)
        {
            throw new NotImplementedException();
        }
    }
}
