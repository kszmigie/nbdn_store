using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.tasks.startup
{
    public class DefaultStartupBuilder : StartupBuilder
    {
        readonly StartupCommandFactory command_factory;
        public IEnumerable<Type> command_types_to_create { get; private set; }

        public DefaultStartupBuilder(IEnumerable<Type> types_to_create, StartupCommandFactory command_factory)
        {
            this.command_factory = command_factory;
            command_types_to_create = new List<Type>(types_to_create);
        }


        public StartupBuilder followed_by<T>() where T : StartupCommand
        {
            var all_command_types = new List<Type>(command_types_to_create);
            all_command_types.Add(typeof(T));
            return new DefaultStartupBuilder(all_command_types, this.command_factory);
        }

        public void finish_by<T>()
        {
            var commands = command_types_to_create.Select(type => command_factory.create_command_of(type));
            foreach (var command in commands)
            {
                command.run();
            }
        }
    }
}