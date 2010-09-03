using System;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.tasks;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewProductDetails : ApplicationCommand
    {
        private readonly CatalogBrowsingTasks _catalogBrowskingTasks;
        private readonly Renderer _renderer;

        public ViewProductDetails(CatalogBrowsingTasks catalogBrowskingTasks, Renderer renderer)
        {
            _catalogBrowskingTasks = catalogBrowskingTasks;
            _renderer = renderer;
        }

        public void process(Request request)
        {
            _renderer.render(_catalogBrowskingTasks.get_product_details(request.map<Product>().id));
        }
    }
}