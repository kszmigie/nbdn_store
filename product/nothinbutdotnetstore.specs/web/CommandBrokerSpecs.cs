 using System.Collections.Generic;
 using System.Linq;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.core;
 using Machine.Specifications.DevelopWithPassion.Extensions;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
 {   
     public class CommandBrokerSpecs
     {
         public abstract class concern : Observes<CommandBroker,
                                             DefaultCommandBroker>
         {
        
         }

         [Subject(typeof(DefaultCommandBroker))]
         public class when_getting_a_command_for_a_request_and_it_has_the_command : concern
         {
             Establish c = () =>
             {
                 request = an<Request>();
                 command_that_can_process_the_request = an<RequestCommand>();
                 all_commands = new List<RequestCommand>();
                 command_that_can_process_the_request.Stub(command => command.can_handle(request)).Return(true);

                 Enumerable.Range(1,100).each(x => all_commands.Add(an<RequestCommand>()));
                 all_commands.Add(command_that_can_process_the_request);

                 provide_a_basic_sut_constructor_argument<IEnumerable<RequestCommand>>(all_commands);
             };

             Because b = () =>
                 result = sut.get_command_that_can_process(request);

             It should_return_the_command_that_can_process_the_request = () =>
                 result.ShouldEqual(command_that_can_process_the_request);

             static RequestCommand result;
             static RequestCommand command_that_can_process_the_request;
             static Request request;
             static IList<RequestCommand> all_commands;
         }

         [Subject(typeof(DefaultCommandBroker))]
         public class when_getting_a_command_for_a_request_and_it_does_not_have_the_command : concern
         {
             Establish c = () =>
             {
                 request = an<Request>();
                 all_commands = new List<RequestCommand>();

                 Enumerable.Range(1,100).each(x => all_commands.Add(an<RequestCommand>()));

                 provide_a_basic_sut_constructor_argument<IEnumerable<RequestCommand>>(all_commands);
             };

             Because b = () =>
                 result = sut.get_command_that_can_process(request);

             It should_return_a_missing_command_to_the_client = () =>
                 result.ShouldBeAn<MissingRequestCommand>();

             static RequestCommand result;
             static Request request;
             static IList<RequestCommand> all_commands;
         }
     }
 }
