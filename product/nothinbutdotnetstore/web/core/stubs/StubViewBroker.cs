using System;
using System.Collections.Generic;
using System.Web.Compilation;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubViewBroker : ViewBroker
    {
        public ViewFor<ViewModel> get_view_for<ViewModel>()
        {
            object item = BuildManager.CreateInstanceFromVirtualPath("~/views/DepartmentBrowser.aspx",typeof(ViewFor<IEnumerable<Department>>));
            return (ViewFor<ViewModel>) item;
        }
    }
}