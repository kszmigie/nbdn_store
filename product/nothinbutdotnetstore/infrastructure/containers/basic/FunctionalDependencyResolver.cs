using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class FunctionalDependencyResolver : DependencyResolver
    {
        Func<object> factory;

        public FunctionalDependencyResolver(Func<object> factory)
        {
            this.factory = factory;
        }

        public object create()
        {
            return factory();
        }
    }
}
