using System;
using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public class ControllerDispatcher : IHttpHandler
    {
        private readonly RequestFactory request_factory;
        private readonly FrontController front_controller;

        public ControllerDispatcher(RequestFactory request_factory, FrontController front_controller)
        {
            this.request_factory = request_factory;
            this.front_controller = front_controller;
        }

        public void ProcessRequest(HttpContext context)
        {
            front_controller.process(request_factory.create_from(context));
        }

        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }
    }
}