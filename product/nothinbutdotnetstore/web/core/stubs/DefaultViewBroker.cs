using System;
using System.Collections.Generic;
using System.Web.Compilation;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class DefaultViewBroker : ViewBroker
    {

        IDictionary<Type, string> viewsLookup;

        public static Func<string, Type, object> PageFactory =
            (path, type) => BuildManager.CreateInstanceFromVirtualPath(path, type);

        private Type _type;

        public DefaultViewBroker(IDictionary<Type, string> lookup)
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
            object item = PageFactory(viewPath, typeof(ViewFor<ViewModel>));
            return (ViewFor<ViewModel>)item;
        }
    }
}