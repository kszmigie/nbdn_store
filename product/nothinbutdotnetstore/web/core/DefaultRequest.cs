using System.Collections.Specialized;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequest : Request
    {
        MappingGateway mapping_gateway;
        public NameValueCollection payload;

        public DefaultRequest(MappingGateway mapping_gateway, NameValueCollection payload)
        {
            this.mapping_gateway = mapping_gateway;
            this.payload = payload;
        }

        public InputModel map<InputModel>()
        {
            return mapping_gateway.map<NameValueCollection, InputModel>(payload);
        }
    }
}