using System.Web.Compilation;
using System.Web.UI;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class DefaultPageRenderer : PageRenderer
    {
        public void Render(Request request, string path, object view_model)
        {
            //create page object from the view
            Page page = (Page)BuildManager.CreateInstanceFromVirtualPath(path, typeof(Page));
            //pass the view model into it
            page.Items.Add("ViewModel", view_model);
            //kick back into the asp.net pipeline to render the webform
            page.ProcessRequest(request.HttpContext);
        }
    }
}