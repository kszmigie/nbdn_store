using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequestFactory : RequestFactory
    {
        public Request create_from(HttpContext context)
        {
            return new DefaultRequest(context);
        }
    }
}