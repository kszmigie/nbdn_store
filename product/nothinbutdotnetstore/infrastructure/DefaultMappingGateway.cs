namespace nothinbutdotnetstore.infrastructure
{
    public class DefaultMappingGateway : MappingGateway
    {
        MapperRegistry mapper_registry;

        public DefaultMappingGateway(MapperRegistry mapper_registry)
        {
            this.mapper_registry = mapper_registry;
        }

        public Output map<Input, Output>(Input input)
        {
            return mapper_registry.get_mapper_to_map<Input, Output>().map(input);
        }
    }
}