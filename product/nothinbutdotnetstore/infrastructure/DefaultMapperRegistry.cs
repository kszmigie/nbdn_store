using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.infrastructure
{
    public class DefaultMapperRegistry : MapperRegistry
    {
        private readonly IDictionary<Type, IDictionary<Type, object>> mappers;

        public DefaultMapperRegistry(IDictionary<Type, IDictionary<Type, object>> mappers)
        {
            this.mappers = mappers;
        }


        public Mapper<Input, Output> get_mapper_to_map<Input, Output>()
        {
            if (mappers.ContainsKey(typeof (Input)))
            {
                var subDict = mappers[typeof (Input)];
                if (subDict.ContainsKey(typeof(Output)))
                {
                    return (Mapper<Input,Output>) subDict[typeof(Output)];
                }
            }
            throw new ApplicationException(string.Format("Mapper not found for types, Input: {0}, Output: {1}",
                                                         typeof (Input), typeof (Output)));
        }
    }
}