 using System;
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
           

            private Establish c = () =>
                                  {
                                      context = ObjectMother.create_http_context();
                                      input_model = an<InputModel>();

                                      var mapping_gateway = the_dependency<MappingGateway>();
                                      mapping_gateway.Stub(m => m.map<NameValueCollection, InputModel>(context.Request.Params)).Return(input_model);
                                  };
            
            private Because b = () =>
                request = sut.create_from(context);

            private It should_return_a_default_request_with_the_correct_input_model = () =>
                input_model.ShouldEqual(request.map<InputModel>());

            private static HttpContext context;
            private static InputModel input_model;
            private static Request request;


            public interface InputModel
            {
            } 
        }
    }
}
