using System.Collections.Specialized;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.web;
using nothinbutdotnetstore.web.application.catalogbrowsing.stubs;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureServiceLayer : StartupCommand
    {
        StartupServices services;

        public ConfigureServiceLayer(StartupServices services)
        {
            this.services = services;
        }

        public void run()
        {
            services.register_dependency_factory<CatalogBrowsingTasks>(() => new DefaultCatalogBrowsingTasks(IOC.retrieve.an<Repository>()));
            Repository the_repository = new StubRepository();
            services.register_dependency_factory<Repository>(() => the_repository);
        }
    }
}