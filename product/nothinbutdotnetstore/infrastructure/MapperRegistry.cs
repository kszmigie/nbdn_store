using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.infrastructure
{
    public interface MapperRegistry
    {
        Mapper<Input,Output> get_mapper_to_map<Input, Output>();
    }

    class DefaultMapperRegistry : MapperRegistry
    {
        IDictionary<Type, IDictionary<Type, Func<object>>> list_of_mappers;

        public DefaultMapperRegistry(IDictionary<Type, IDictionary<Type, Func<object>>> list_of_mappers)
        {
            this.list_of_mappers = list_of_mappers;
        }

        public Mapper<Input, Output> get_mapper_to_map<Input, Output>()
        {
            IDictionary<Type, Func<object>> mappers_for_input_type;
            list_of_mappers.TryGetValue(typeof (Input), out mappers_for_input_type);

            //todo: throw exception if null

            Func<object> mapper;
            mappers_for_input_type.TryGetValue(typeof (Output), out mapper);

            //todo: throw exception if null

            return (Mapper<Input, Output>) mapper();
        }
    }
}