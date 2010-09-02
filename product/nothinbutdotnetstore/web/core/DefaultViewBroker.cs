using System;
using System.Collections.Generic;
using System.Web.Compilation;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultViewBroker : ViewBroker
    {

        ViewLookup viewsLookup;

        public static Func<string, Type, object> page_factory = (path, type) => BuildManager.CreateInstanceFromVirtualPath(path, type);

        private Type _type;

        public DefaultViewBroker(ViewLookup lookup)
        {
            viewsLookup = lookup;
        }

        public ViewFor<ViewModel> get_view_for<ViewModel>()
        {
            _type = typeof(ViewModel);
            string viewPath;
            try
            {
                viewPath = viewsLookup[_type];
            }
            catch(Exception ex)
            {
                throw new ApplicationException(String.Format("View for {0} not found", _type.ToString()), ex);
            }
            //"~/views/DepartmentBrowser.aspx"
            object item = page_factory(viewPath, typeof(ViewFor<ViewModel>));
            return (ViewFor<ViewModel>)item;
        }
    }
}