using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public interface ViewFor<Model> : IHttpHandler
    {
        Model model { get; set; }
    }
}