using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class FunctionalDependencyResolver : DependencyResolver
    {
        private readonly Func<object> _creator;

        public FunctionalDependencyResolver(Func<object> creator)
        {
            _creator = creator;
        }

        public object create()
        {
            return _creator();
        }
    }
}