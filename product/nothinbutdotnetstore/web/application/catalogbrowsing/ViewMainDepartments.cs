using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewMainDepartments : ApplicationCommand
    {
        CatalogBrowsingTasks catalog_browsing_tasks;
        Renderer renderer;

        public ViewMainDepartments(CatalogBrowsingTasks catalog_browsing_tasks, Renderer renderer)
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