using System;
using System.Collections.Generic;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewMainDepartments : ApplicationCommand
    {
        private readonly DefaultGateway default_gateway;
        private readonly PageRenderer renderer;
        private readonly string page_path;

        public ViewMainDepartments(DefaultGateway default_gateway, PageRenderer renderer, string page_path)
        {
            this.default_gateway = default_gateway;
            this.renderer = renderer;
            this.page_path = page_path;
        }

        public void process(Request request)
        {
            var departments = default_gateway.get_all_departments();
            renderer.Render(request, page_path, departments);
        }
    }
}