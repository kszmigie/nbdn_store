using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultCommandBroker : CommandBroker
    {
        IEnumerable<RequestCommand> all_commands;

        public DefaultCommandBroker():this(new StubSetOfCommands())
        {
        }

        public DefaultCommandBroker(IEnumerable<RequestCommand> all_commands)
        {
            this.all_commands = all_commands;
        }

        public RequestCommand get_command_that_can_process(Request request)
        {
            return all_commands.FirstOrDefault(x => x.can_handle(request)) ??
                new MissingRequestCommand();
        }
    }
}