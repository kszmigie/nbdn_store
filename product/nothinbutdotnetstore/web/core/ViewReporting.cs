using System;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;

namespace nothinbutdotnetstore.web.core
{
    public class ViewReporting : ApplicationCommand
    {
         CatalogBrowsingTasks catalog_browsing_tasks;
        Renderer renderer;

        public ViewReporting(CatalogBrowsingTasks catalog_browsing_tasks, Renderer renderer)
        {
            this.catalog_browsing_tasks = catalog_browsing_tasks;
            this.renderer = renderer;
        }

        public void process(Request request)
        {
            renderer.render(catalog_browsing_tasks.get_all_departments());
        }
    }
}