using System;
using System.Runtime.Serialization;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class DependencyResolverNotFoundException : Exception
    {
        public Type type_for_which_resolver_not_found { get; private set; }

        public DependencyResolverNotFoundException(Type dependency_for_which_resolver_not_found) : base(get_descriptive_string(dependency_for_which_resolver_not_found))
        {
            this.type_for_which_resolver_not_found = dependency_for_which_resolver_not_found;
        }

        static string get_descriptive_string(Type type_to_create)
        {
            return string.Format("Failed to find resolver for dependency: {0}", type_to_create);
        }
    }
}