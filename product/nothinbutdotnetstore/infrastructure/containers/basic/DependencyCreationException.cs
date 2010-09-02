using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class DependencyCreationException : Exception
    {
        public Type type_that_could_not_be_created { get; private set; }
    }
}