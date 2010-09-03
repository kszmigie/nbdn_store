using System;

namespace nothinbutdotnetstore.tasks.startup
{
    public static class Start
    {
        public static StartupBuilder by<T>() where T : StartupCommand {
            return new DefaultStartupBuilder(new Type[0], null);
        }
    }
}