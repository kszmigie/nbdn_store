using System;
using System.Collections.Generic;
using System.Web.Compilation;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultViewBroker : ViewBroker
    {
        public ViewFor<ViewModel> get_view_for<ViewModel>()
        {
            var typeName = typeof (ViewModel).Name;

            string path = "DepartmentBrowser.aspx";
            object item = BuildManager.CreateInstanceFromVirtualPath(path, typeof(ViewFor<ViewModel>));

            return (ViewFor<ViewModel>)item;
        }
    }
}