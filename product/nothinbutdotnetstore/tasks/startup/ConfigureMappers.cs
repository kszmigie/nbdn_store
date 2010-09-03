using System;
using System.Collections.Specialized;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.web;
using nothinbutdotnetstore.web.application;

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
            services.register_dependency_factory<Mapper<NameValueCollection, Product >>(() => new ProductMapper());
        }
    }
}