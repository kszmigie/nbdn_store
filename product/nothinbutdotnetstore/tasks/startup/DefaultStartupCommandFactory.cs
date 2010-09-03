using System;
using System.Linq;

namespace nothinbutdotnetstore.tasks.startup
{
    public class DefaultStartupCommandFactory : StartupCommandFactory
    {
        StartupServices startup_services;

        public DefaultStartupCommandFactory(StartupServices startup_services)
        {
            this.startup_services = startup_services;
        }

        public StartupCommand create_command_of(Type type)
        {
            var constructor = type.GetConstructors().Single();
            var parameters = new object[] {startup_services};
            return (StartupCommand) constructor.Invoke(parameters);
        }
    }
}