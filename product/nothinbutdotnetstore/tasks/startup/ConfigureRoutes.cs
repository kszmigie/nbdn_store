using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.application.catalogbrowsing.stubs;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureRoutes : StartupCommand
    {
        StartupServices services;

        public ConfigureRoutes(StartupServices services)
        {
            this.services = services;
        }

        public void run()
        {
            services.register_dependency_factory<IEnumerable<RequestCommand>>(get_commands);
        }

        static object get_commands()
        {
            var commands = new List<RequestCommand>();
            commands.Add(new DefaultRequestCommand(r => r.application_command_name == "ViewMainDepartments.store",
                                                   new ViewMainDepartments(IOC.retrieve.an<CatalogBrowsingTasks>(),
                                                                           IOC.retrieve.an<Renderer>())));
            commands.Add(new DefaultRequestCommand(r => r.application_command_name == "ViewSubDepartments.store",
                                                   new ViewSubDepartments(IOC.retrieve.an<CatalogBrowsingTasks>(),
                                                                          IOC.retrieve.an<Renderer>())));
            return commands;
        }
    }
}