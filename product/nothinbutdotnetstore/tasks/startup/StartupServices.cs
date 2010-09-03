using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure.containers.basic;

namespace nothinbutdotnetstore.tasks.startup
{
    public interface StartupServices : IDictionary<Type,DependencyResolver>
    {
        void register_dependency_factory<Contract>(Func<object> resolver);
    }
}