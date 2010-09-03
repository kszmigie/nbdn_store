using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class AutomaticDependencyResolver : DependencyResolver
    {
        private readonly Container container;
        private ConstructorSelectionStrategy constructor_selection_strategy;
        private readonly Type type_to_resolve;

        public AutomaticDependencyResolver(Container container, ConstructorSelectionStrategy constructor_selection_strategy, Type type_to_resolve)
        {
            this.container = container;
            this.constructor_selection_strategy = constructor_selection_strategy;
            this.type_to_resolve = type_to_resolve;
        }

        public object create()
        {
            var constructor = constructor_selection_strategy.get_applicable_constructor_on(type_to_resolve);
            
            var parameters = constructor.GetParameters().Select((type_parameter) => container.an(type_parameter.ParameterType));
            
            return constructor.Invoke(parameters.ToArray());
        }
    }
}