using System;
using System.Reflection;
using System.Linq;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class GreedyConstructorSelectionStrategy : ConstructorSelectionStrategy
    {
        public ConstructorInfo get_applicable_constructor_on(Type type_with_dependencies)
        {
            return type_with_dependencies.GetConstructors().OrderByDescending(c => c.GetParameters().Count()).First();
        }
    }
}