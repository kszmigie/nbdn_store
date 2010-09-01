using System;
using System.Web;
using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubRenderer : Renderer
    {
        public void render<ViewModel>(ViewModel view_model)
        {
            HttpContext.Current.Items.Add("blah",view_model);
            HttpContext.Current.Server.Transfer("~/views/DepartmentBrowser.aspx",true);
        }

    }
}