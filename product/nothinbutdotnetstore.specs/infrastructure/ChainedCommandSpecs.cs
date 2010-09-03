using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class ChainedCommandSpecs
    {
        public abstract class concern : Observes<Command,
                                            ChainedCommand>
        {
        }

        [Subject(typeof(ChainedCommand))]
        public class when_run : concern
        {
            Establish c = () =>
            {
                first_command = an<Command>();
                second_command = an<Command>();
                create_sut_using(() => new ChainedCommand(first_command, second_command));
            };

            Because b = () =>
                sut.run();

            It should_run_the_first_and_second_command = () =>
            {
                first_command.received(x => x.run());
                second_command.received(x => x.run());
            };

            static Command first_command;
            static Command second_command;
        }
    }
}