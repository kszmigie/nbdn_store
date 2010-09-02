using System.Collections.Specialized;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class RequestSpecs
    {
        public abstract class concern : Observes<Request,
                                            DefaultRequest>
        {
        }

        [Subject(typeof(DefaultRequest))]
        public class when_mapping_an_input_model : concern
        {
            Establish c = () =>
            {
                the_model = new TheInputModel();
                payload = new NameValueCollection();
                mapping_gateway = the_dependency<MappingGateway>();

                provide_a_basic_sut_constructor_argument(payload);
                provide_a_basic_sut_constructor_argument("blah");

                mapping_gateway.Stub(x => x.map<NameValueCollection,TheInputModel>(payload)).Return(the_model);
            };

            Because b = () =>
                result = sut.map<TheInputModel>();

            It should_return_the_input_model_mapped_from_the_payload = () =>
                result.ShouldEqual(the_model);

            static TheInputModel result;
            static TheInputModel the_model;
            static NameValueCollection payload;
            static MappingGateway mapping_gateway;
        }

        [Subject(typeof(DefaultRequest))]
        public class when_asked_for_a_application_command_name : concern
        {
            Establish c = () =>
            {
                provide_a_basic_sut_constructor_argument("blah");
            };

            Because b = () =>
                result = sut.application_command_name;

            It should_provide_the_application_command_name = () =>
                result.ShouldEqual("blah");

            static string result;
        }



        public class TheInputModel
        {
        }
    }
}