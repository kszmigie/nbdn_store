using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class MissingDependencyResolver : DependencyResolver
    {
        public object create()
        {
            throw new NotImplementedException();
        }
    }
}