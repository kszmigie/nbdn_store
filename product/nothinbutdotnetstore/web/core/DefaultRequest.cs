using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequest : Request
    {
        private HttpContext http_context;

        public DefaultRequest(HttpContext http_context)
        {
            this.http_context = http_context;
        }

        public HttpContext HttpContext
        {
            get { return http_context; }
        }
    }
}