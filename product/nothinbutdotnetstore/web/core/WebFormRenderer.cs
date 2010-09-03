using System;

namespace nothinbutdotnetstore.web.core
{
    public class WebFormRenderer : Renderer
    {
        ViewBroker view_broker;

        public static HttpContextRetriever retriever = () =>
                                                           {
                                                               throw new NotImplementedException(
                                                                   "You need to set this at configuration time");
                                                           };


        public WebFormRenderer(ViewBroker view_broker)
        {
            this.view_broker = view_broker;
        }

        public void render<ViewModel>(ViewModel view_model)
        {
            var view = view_broker.get_view_for<ViewModel>();
            view.model = view_model;
            view.ProcessRequest(retriever());
        }
    }
}