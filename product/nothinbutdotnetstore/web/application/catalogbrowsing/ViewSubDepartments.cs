using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewSubDepartments : ApplicationCommand
    {
        CatalogBrowsingTasks catalog_browsing_tasks;
        Renderer renderer;

        public ViewSubDepartments():this(new StubCatalogBrowsingTasks(),new WebFormRenderer())
        {

        }

        public ViewSubDepartments(CatalogBrowsingTasks catalog_browsing_tasks, Renderer renderer)
        {
            this.catalog_browsing_tasks = catalog_browsing_tasks;
            this.renderer = renderer;
        }

        public void process(Request request)
        {
            renderer.render(catalog_browsing_tasks.get_sub_departments(request.departmentname));
        }
    }
}