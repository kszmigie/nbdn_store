 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
 {   
     public class FrontControllerSpecs
     {
         public abstract class concern : Observes<FrontController,
                                             DefaultFrontController>
         {
        
         }

         [Subject(typeof(DefaultFrontController))]
         public class when_processing_a_request : concern
         {

             Establish c = () =>
             {
                 command_broker = the_dependency<CommandBroker>();
                 request = an<Request>();
                 command = an<RequestCommand>();

                 command_broker.Stub(x => x.get_command_that_can_process(request)).Return(command);
             };

             Because b = () =>
                 sut.process(request);


             It should_delegate_the_processing_to_the_command_that_can_process_the_request = () =>
                 command.received(x => x.process(request));

             static RequestCommand command;
             static Request request;
             static CommandBroker command_broker;
         }
     }
 }
