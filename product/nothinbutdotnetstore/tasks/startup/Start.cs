using System;

namespace nothinbutdotnetstore.tasks.startup
{
    public static class Start
    {
        public static StartupBuilder by<T>(StartupCommandFactory command_factory) where T : StartupCommand {
            return new DefaultStartupBuilder(null,null,null);
        }
    }
}