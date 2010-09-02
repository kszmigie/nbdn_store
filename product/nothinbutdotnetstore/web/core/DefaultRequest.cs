using System;
using System.Collections.Specialized;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequest : Request
    {
        MappingGateway model_mapper;
        NameValueCollection payload;

        public DefaultRequest(MappingGateway model_mapper, NameValueCollection payload)
        {
            this.model_mapper = model_mapper;
            this.payload = payload;
        }

        public InputModel map<InputModel>()
        {
            return model_mapper.map<NameValueCollection,InputModel>(payload);
        }
    }
}