using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class FunctionalDependencyResolver : DependencyResolver
    {
        private Func<object> object_to_create;

        public FunctionalDependencyResolver(Func<object> object_to_create)
        {
            this.object_to_create = object_to_create;
        }

        public object create()
        {
            return object_to_create();
        }
    }
}