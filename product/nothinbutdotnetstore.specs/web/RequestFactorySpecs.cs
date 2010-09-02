using System.Collections.Specialized;
using System.Web;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class RequestFactorySpecs
    {
        public abstract class concern : Observes<RequestFactory,
                                            DefaultRequestFactory>
        {
        }

        [Subject(typeof(DefaultRequestFactory))]
        public class when_creating_a_request_from_an_http_context : concern
        {
            Establish c = () =>
            {
                context = ObjectMother.create_http_context()
                    .with_payload_value("sdfsdf", 23)
                    .with_url_value("http://localhost/blah.store");
            };

            Because b = () =>
                request = sut.create_from(context);

            It should_return_a_default_request_with_the_correct_payload = () =>
                request.ShouldBeAn<DefaultRequest>()
                       .payload.ShouldEqual(context.Request.Params);

            It should_return_the_application_command_name_parsed_from_url = () =>
                request.application_command_name.ShouldEqual("blah.store");

            static HttpContext context;
            static Request request;

        }
    }
}