using System;

namespace nothinbutdotnetstore.infrastructure
{
    public interface MapperRegistry
    {
        Mapper<Input,Output> get_mapper_to_map<Input, Output>();
    }

    class DefaultMapperRegistry : MapperRegistry
    {
        public Mapper<Input, Output> get_mapper_to_map<Input, Output>()
        {
            throw new NotImplementedException();
        }
    }
}