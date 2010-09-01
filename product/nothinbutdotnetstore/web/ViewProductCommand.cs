using nothinbutdotnetstore.model;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web
{
    public class ViewProductCommand : ApplicationCommand
    {

            CatalogBrowsingTasks catalog_browsing_tasks;
            Renderer renderer;

            public ViewProductCommand():this(new StubCatalogBrowsingTasks(),new WebFormRenderer())
            {
            }


        public ViewProductCommand(CatalogBrowsingTasks catalog_browsing_tasks, Renderer renderer)
        {
            this.catalog_browsing_tasks = catalog_browsing_tasks;
            this.renderer = renderer;
        }

        public void process(Request request)
        {
            renderer.render(catalog_browsing_tasks.get_dept_products(request.map<Department>()));
        }

    }
}