using System;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.infrastructure
{
    public class DefaultMapperRegistry : MapperRegistry
    {
        Container container;

        public DefaultMapperRegistry(Container container)
        {
            this.container = container;
        }

        public Mapper<Input, Output> get_mapper_to_map<Input, Output>()
        {
            return container.an<Mapper<Input, Output>>();
        }
    }
}