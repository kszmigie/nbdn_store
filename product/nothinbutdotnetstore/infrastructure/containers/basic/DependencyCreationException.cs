using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class DependencyCreationException : Exception
    {
        public DependencyCreationException(Type type_that_could_not_be_created, Exception innerException) : base(get_descriptive_string(type_that_could_not_be_created, innerException), innerException)
        {
            this.type_that_could_not_be_created = type_that_could_not_be_created;
        }

        static string get_descriptive_string(Type type_to_create, Exception innerException)
        {
/*            List<DependencyCreationException> creationExceptions = new List<DependencyCreationException>();
            while(innerException is DependencyCreationException)
            {
                creationExceptions.Add(innerException as DependencyCreationException);
                innerException = innerException.InnerException;
            }

            string chain = string.Join("\n",
                                       creationExceptions.Select(e => e.type_that_could_not_be_created.ToString()).
                                           ToArray());*/
            return string.Format("Failed to create dependency: {0}", type_to_create); //", resolve chain: {1}", type_to_create, chain);
        }

        protected DependencyCreationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public Type type_that_could_not_be_created { get; private set; }
    }
}