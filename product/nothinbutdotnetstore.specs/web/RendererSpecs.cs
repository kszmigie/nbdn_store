 using System.Web;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.specs.utility;
 using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
 {   
     public class RendererSpecs
     {
         public abstract class concern : Observes<Renderer,
                                             WebFormRenderer>
         {
        
         }

         [Subject(typeof(WebFormRenderer))]
         public class when_rendering_a_view_model : concern
         {
             Establish c = () =>
             {
                 view_broker = the_dependency<ViewBroker>();
                 view_for = an<ViewFor<int>>();
                 the_context = ObjectMother.create_http_context();

                 view_broker.Stub(x => x.get_view_for<int>()).Return(view_for);

                 the_retriever = () => the_context;
                 change(() => WebFormRenderer.retriever).to(the_retriever);
             };

             Because b = () =>
                 sut.render(model);

             It should_locate_the_view_that_can_render_the_view_model = () =>
                 view_broker.received(x => x.get_view_for<int>());

             It should_populate_the_model_on_the_view = () =>
                 view_for.model.ShouldEqual(model);

             It should_tell_the_view_to_process_the_context = () =>
                 view_for.received(x => x.ProcessRequest(the_context));
  


  

             static ViewBroker view_broker;
             static int model = 23;
             static ViewFor<int> view_for;
             static HttpContext the_context;
             static HttpContextRetriever the_retriever;
         }
     }

 }
