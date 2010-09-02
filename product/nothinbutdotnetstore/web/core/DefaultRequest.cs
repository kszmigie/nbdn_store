using System;
using System.Collections.Specialized;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequest : Request
    {
        MappingGateway mapping_gateway;
        public NameValueCollection payload;

        public DefaultRequest(MappingGateway mapping_gateway, NameValueCollection payload, string application_command_name)
        {
            this.mapping_gateway = mapping_gateway;
            this.payload = payload;
            this.application_command_name = application_command_name;
        }

        public InputModel map<InputModel>()
        {
            return mapping_gateway.map<NameValueCollection, InputModel>(payload);
        }

        public string application_command_name { get; private set; }
    }
}