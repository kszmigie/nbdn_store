using System.Web;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs.web
{
    public class RequestFactorySpecs
    {
        public abstract class concern : Observes<RequestFactory,
                                            DefaultRequestFactory>
        {

        }

        [Subject(typeof(DefaultRequestFactory))]
        public class when_creating_request : concern
        {
            Establish c = () =>
                context = ObjectMother.create_http_context();

            Because b = () =>
                request = sut.create_from(context);

            private It should_return_the_default_request = () =>
                request.ShouldBeOfType<DefaultRequest>();
            
            private static Request request;
            private static HttpContext context;
        }
    }
}
