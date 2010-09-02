using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public interface ResolverRegistry
    {
        DependencyResolver get_resolver_to_create(Type dependency);
    }
}