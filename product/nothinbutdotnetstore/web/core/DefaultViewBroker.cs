using System;
using System.Web.Compilation;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultViewBroker : ViewBroker
    {
        ViewPathRegistry views_path_registry;

        public static Func<string, Type, object> page_factory =
            (path, type) => BuildManager.CreateInstanceFromVirtualPath(path, type);


        public DefaultViewBroker(ViewPathRegistry path_registry)
        {
            views_path_registry = path_registry;
        }

        public ViewFor<ViewModel> get_view_for<ViewModel>()
        {
            var item = page_factory(views_path_registry.get_path_for<ViewModel>(), typeof(ViewFor<ViewModel>));
            return (ViewFor<ViewModel>) item;
        }
    }
}