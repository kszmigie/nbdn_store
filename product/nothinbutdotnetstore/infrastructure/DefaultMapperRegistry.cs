using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace nothinbutdotnetstore.infrastructure
{
    public class DefaultMapperRegistry : MapperRegistry
    {
        private readonly IDictionary<Type, IDictionary<Type, object>> mappers;
        private Type inputType;
        private Type outputType;

        public DefaultMapperRegistry(IDictionary<Type, IDictionary<Type, object>> mappers)
        {
            this.mappers = mappers;
        }


        public Mapper<Input, Output> get_mapper_to_map<Input, Output>()
        {
            
            inputType = typeof(Input);
            outputType = typeof(Output);
            if (mappers.ContainsKey(inputType))
            {
                var subDict = mappers[inputType];
                if (subDict.ContainsKey(outputType))
                    return (Mapper<Input, Output>)subDict[outputType];
            }
            throw new ApplicationException("Mapper not found for input");
        }
    }
}