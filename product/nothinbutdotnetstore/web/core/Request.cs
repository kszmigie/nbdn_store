using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public interface Request
    {
        HttpContext HttpContext { get; }
    }
}