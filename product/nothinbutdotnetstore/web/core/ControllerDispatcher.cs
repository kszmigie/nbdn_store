using System.Web;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.web.core
{
    public class ControllerDispatcher : IHttpHandler
    {
        RequestFactory request_factory;
        FrontController front_controller;

        public ControllerDispatcher() : this(IOC.retrieve.an<RequestFactory>(),
                                             IOC.retrieve.an<FrontController>())
        {
        }

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
            get { return true; }
        }
    }
}