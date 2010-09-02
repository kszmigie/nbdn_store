using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class IOC
    {
        public static ContainerResolver container_resolver = delegate
        {
            throw new NotImplementedException("This needs to be configured at startup");
        };

        public static Container retrieve
        {
            get { return container_resolver(); }
        }
    }
}