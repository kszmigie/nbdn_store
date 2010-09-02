using System;
using System.Runtime.Serialization;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class DependencyCreationException : Exception
    {
        public DependencyCreationException(Type type_that_could_not_be_created, Exception innerException) : base(get_descriptive_string(type_that_could_not_be_created), innerException)
        {
            this.type_that_could_not_be_created = type_that_could_not_be_created;
        }

        static string get_descriptive_string(Type type_to_create)
        {
            return string.Format("Failed to create dependency: {0}", type_to_create);
        }

        protected DependencyCreationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public Type type_that_could_not_be_created { get; private set; }
    }
}