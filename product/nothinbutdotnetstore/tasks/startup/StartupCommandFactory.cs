using System;

namespace nothinbutdotnetstore.tasks.startup
{
    public interface StartupCommandFactory
    {
        StartupCommand create_command_of(Type type);
    }
}