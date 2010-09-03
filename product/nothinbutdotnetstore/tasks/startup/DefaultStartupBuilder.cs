using System;
using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.tasks.startup
{
    public class DefaultStartupBuilder : StartupBuilder
    {
        public StartupCommandFactory command_factory;
        public Command command;

        public DefaultStartupBuilder(Command command_to_run,Type first_command_type, StartupCommandFactory command_factory)
        {
            this.command_factory = command_factory;
        }


        public StartupBuilder followed_by<T>() where T : StartupCommand
        {
            throw new NotImplementedException();
        }

        public void finish_by<T>()
        {
            command.run();
        }

        Command append<T>()
        {
            throw new NotImplementedException();
        }


    }
}