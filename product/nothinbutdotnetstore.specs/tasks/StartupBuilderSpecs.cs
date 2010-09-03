using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Extensions;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.tasks.startup;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.tasks
{
    public class StartupBuilderSpecs
    {
        public abstract class concern : Observes<StartupBuilder,
                                            DefaultStartupBuilder>
        {
        }

        [Subject(typeof(DefaultStartupBuilder))]
        public class when_created_with_only_the_type : concern
        {
            Establish c = () =>
            {
                the_command = an<StartupCommand>();
                factory = an<StartupCommandFactory>();
                factory.Stub(x => x.create_command_of(typeof(FakeStartupCommand))).Return(the_command);

                create_sut_using(() => new DefaultStartupBuilder(typeof(FakeStartupCommand), factory));
            };

            It should_create_the_command_using_the_factory = () =>
                sut.downcast_to<DefaultStartupBuilder>().command.ShouldEqual(the_command);

            static StartupCommand the_command;
            static StartupCommandFactory factory;
        }

        public abstract class concern_for_a_builder_that_has_an_existing_command : Observes<StartupBuilder,
                                                                                       DefaultStartupBuilder>
        {
            Establish c = () =>
            {
                command = the_dependency<Command>();
                factory = the_dependency<StartupCommandFactory>();
            };

            protected static StartupCommandFactory factory;
            protected static Command command;
        }

        [Subject(typeof(DefaultStartupBuilder))]
        public class when_following_with_another_command : concern_for_a_builder_that_has_an_existing_command
        {
            Establish c = () =>
            {
                startup_command = an<StartupCommand>();

                factory.Stub(x => x.create_command_of(typeof(FakeStartupCommand)))
                    .Return(startup_command);
            };

            Because b = () =>
                result = sut.followed_by<FakeStartupCommand>();

            It should_a_new_builder_to_allow_method_chaining = () =>
                result.ShouldBeAn<DefaultStartupBuilder>().command.ShouldBeAn<ChainedCommand>();

            static StartupBuilder result;
            static StartupCommand startup_command;
        }

        [Subject(typeof(DefaultStartupBuilder))]
        public class when_asked_to_finish_registration_of_startup_command :
            concern
        {
            Establish c = () =>
            {
                factory = an<StartupCommandFactory>();
                startup_command = the_dependency<Command>();
                second_command = an<StartupCommand>();
                factory.Stub(command_factory => command_factory.create_command_of(typeof(AnotherFakeStartupCommand))).
                    Return(second_command);

                create_sut_using(() => new DefaultStartupBuilder(startup_command,factory));
            };

            Because b = () =>
                sut.finish_by<AnotherFakeStartupCommand>();

            It should_run_all_of_the_commands = () =>
            {
                startup_command.received(x => x.run());
                second_command.received(x => x.run());
            };

            static StartupCommand second_command;
            static Command startup_command;
            static StartupCommandFactory factory;
        }

        public class FakeStartupCommand : StartupCommand
        {
            public void run()
            {
            }
        }

        class AnotherFakeStartupCommand : StartupCommand
        {
            public void run()
            {
            }
        }
    }
}