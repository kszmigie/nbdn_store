using System.Collections.Generic;
using System.Web;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureFrontController : StartupCommand
    {
        StartupServices services;

        public ConfigureFrontController(StartupServices services)
        {
            this.services = services;
        }

        public void run()
        {
            services.register_dependency_factory<FrontController>(() => new DefaultFrontController(IOC.retrieve.an<CommandBroker>()));
            services.register_dependency_factory<CommandBroker>(() => new DefaultCommandBroker(IOC.retrieve.an<IEnumerable<RequestCommand>>()));
            services.register_dependency_factory<RequestFactory>(() => new DefaultRequestFactory(IOC.retrieve.an<MappingGateway>()));
            services.register_dependency_factory<ViewBroker>(() => new DefaultViewBroker(IOC.retrieve.an<DefaultViewPathRegistry>()));
            services.register_dependency_factory<Renderer>(() => new WebFormRenderer(IOC.retrieve.an<ViewBroker>()));
            services.register_dependency_factory<DefaultViewPathRegistry>(get_viewmappings);
            WebFormRenderer.retriever = () => HttpContext.Current;
        }

        static DefaultViewPathRegistry get_viewmappings()
        {
            var mappings = new DefaultViewPathRegistry();
            mappings.register_path_for<IEnumerable<Department>>("~/views/DepartmentBrowser.aspx");
            return mappings;
        }
    }
}