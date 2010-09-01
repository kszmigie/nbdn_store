using nothinbutdotnetstore.model;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web
{
    public class ViewProducts : ApplicationCommand
    {
        CatalogBrowsingTasks catalog_browsing_tasks;
        Renderer renderer;

        public ViewProducts(CatalogBrowsingTasks catalog_browsing_tasks, Renderer renderer)
        {
            this.catalog_browsing_tasks = catalog_browsing_tasks;
            this.renderer = renderer;
        }

        public void process(Request request)
        {
            renderer.render(catalog_browsing_tasks.get_all_products_in(request.map<Department>()));
        }
    }
}