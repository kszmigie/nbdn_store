using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.infrastructure
{
    public class DefaultMappingGateway : MappingGateway
    {
        IList<Mapper> mappers;

        public DefaultMappingGateway(IEnumerable<Mapper> mappers)
        {
            this.mappers = new List<Mapper>(mappers);
        }

        public Output map<Input, Output>(Input input)
        {
            return mappers.First(m => m.can_map<Input, Output>(input)).map<Input, Output>(input);
        }

        public bool can_map<Input, Output>(Input input)
        {
            return mappers.Any(m => m.can_map<Input, Output>(input));
        }
    }
}