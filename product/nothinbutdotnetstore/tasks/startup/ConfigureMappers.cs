using System;
using System.Collections.Specialized;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.web;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureMappers : StartupCommand
    {
        StartupServices services;

        public ConfigureMappers(StartupServices services)
        {
            this.services = services;
        }

        public void run()
        {
            services.register_dependency_factory<Mapper<NameValueCollection, Department>>(() => new DepartmentMapper());
        }
    }
}