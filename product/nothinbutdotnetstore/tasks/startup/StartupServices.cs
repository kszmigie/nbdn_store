using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure.containers.basic;

namespace nothinbutdotnetstore.tasks.startup
{
    public interface StartupServices
    {
        void register_dependency_factory<Contract>(Func<object> resolver);
        DependencyResolver get_resolver_for(Type dependency);
    }
}