using System;
using System.Collections.Specialized;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequest : Request
    {
        MappingGateway mapping_gateway;
        public NameValueCollection payload;
        private string page;

        public DefaultRequest(MappingGateway mapping_gateway, NameValueCollection payload, string page_name)
        {
            this.mapping_gateway = mapping_gateway;
            this.payload = payload;
            this.page = page_name.ToLower().Replace(".store", "").Replace("/views/", "").TrimStart('/');
        }

        public InputModel map<InputModel>()
        {
            return mapping_gateway.map<NameValueCollection, InputModel>(payload);
        }

        public string page_name
        {
            get { return this.page; }
        }
    }
}