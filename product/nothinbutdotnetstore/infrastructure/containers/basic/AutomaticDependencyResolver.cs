using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class AutomaticDependencyResolver : DependencyResolver
    {
        readonly Container container;
        ConstructorSelectionStrategy constructor_selection_strategy;
        readonly Type type_to_resolve;

        public AutomaticDependencyResolver(Container container,
                                           ConstructorSelectionStrategy constructor_selection_strategy,
                                           Type type_to_resolve)
        {
            this.container = container;
            this.constructor_selection_strategy = constructor_selection_strategy;
            this.type_to_resolve = type_to_resolve;
        }

        public object create()
        {
            var constructor = constructor_selection_strategy.get_applicable_constructor_on(type_to_resolve);
            return constructor.Invoke(constructor.GetParameters().Select((type_parameter) => container.an(type_parameter.ParameterType)).ToArray());
        }
    }
}