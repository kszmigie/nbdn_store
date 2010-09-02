using System.Web;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequestFactory : RequestFactory
    {
        MappingGateway mapping_gateway;

        public DefaultRequestFactory(MappingGateway mapping_gateway)
        {
            this.mapping_gateway = mapping_gateway;
        }

        public Request create_from(HttpContext context)
        {
            string path = context.Request.Url.AbsolutePath;
            var command_name = path.Substring(path.LastIndexOf('/') + 1);
            return new DefaultRequest(mapping_gateway, context.Request.Params, command_name);
        }
    }
}