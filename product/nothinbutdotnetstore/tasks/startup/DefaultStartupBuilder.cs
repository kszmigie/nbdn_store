using System;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.tasks.startup
{
    public class DefaultStartupBuilder : StartupBuilder
    {
        public StartupCommandFactory command_factory;
        public Command command;

        public DefaultStartupBuilder(Type type, StartupCommandFactory command_factory)
            : this(command_factory.create_command_of(type), command_factory)
        {
        }

        public DefaultStartupBuilder(Command command_to_run, StartupCommandFactory command_factory)
        {
            this.command_factory = command_factory;
            this.command = command_to_run;
        }

        public StartupBuilder followed_by<T>() where T : StartupCommand
        {
            return new DefaultStartupBuilder(combine_with(typeof(T)), command_factory);
        }

        public void finish_by<T>()
        {
            combine_with(typeof(T)).run();
        }

        Command combine_with(Type command_type)
        {
            return new ChainedCommand(command, command_factory.create_command_of(command_type));
        }
    }
}