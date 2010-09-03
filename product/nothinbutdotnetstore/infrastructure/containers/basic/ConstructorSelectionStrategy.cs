using System;
using System.Reflection;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public interface ConstructorSelectionStrategy
    {
        ConstructorInfo get_applicable_constructor_on(Type type_with_dependencies);
    }
}