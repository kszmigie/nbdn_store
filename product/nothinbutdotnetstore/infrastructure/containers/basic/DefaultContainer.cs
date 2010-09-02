using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class DefaultContainer : Container
    {
        private readonly ResolverRegistry _registry;

        public DefaultContainer(ResolverRegistry registry)
        {
            _registry = registry;
        }

        public Dependency an<Dependency>()
        {
            return (Dependency) _registry.get_resolver_to_create(typeof (Dependency)).create();
        }
    }
}