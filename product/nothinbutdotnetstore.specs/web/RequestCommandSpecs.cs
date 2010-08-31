using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs.web
{
    public class RequestCommandSpecs
    {
        public abstract class concern : Observes<RequestCommand,
                                            DefaultRequestCommand>
        {
        }

        [Subject(typeof(DefaultRequestCommand))]
        public class when_determinining_if_it_can_handle_a_request : concern
        {
            Establish c = () =>
            {
                request = an<Request>();
                provide_a_basic_sut_constructor_argument<RequestCriteria>(request1 => true);
            };

            Because b = () =>
                result = sut.can_handle(request);

            It should_make_the_determination_by_using_its_request_criteria = () =>
                result.ShouldBeTrue();

            static bool result;
            static Request request;
        }

        [Subject(typeof(DefaultRequestCommand))]
        public class when_processing_the_request : concern
        {
            Establish c = () =>
            {
                request = an<Request>();
                provide_a_basic_sut_constructor_argument<RequestCriteria>(request1 => true);
                application_command = the_dependency<ApplicationCommand>();
            };

            Because b = () =>
                sut.process(request);

            It should_use_the_application_specific_command_to_process_the_request = () =>
                application_command.received(x => x.process(request));


            static Request request;
            static ApplicationCommand application_command;
        }
    }
}