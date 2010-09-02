using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public interface Container
    {
        Dependency an<Dependency>();
        object an(Type dependency);
    }
}