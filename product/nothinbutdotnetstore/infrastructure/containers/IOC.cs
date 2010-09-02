using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class IOC
    {
        public static ContainerResolver container_resolver = delegate
        {
            throw new NotImplementedException();
        };

        public static Container retrieve
        {
            get { throw new NotImplementedException(); }
        }
    }
}