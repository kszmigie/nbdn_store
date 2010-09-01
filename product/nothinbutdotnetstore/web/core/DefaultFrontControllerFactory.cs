using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultFrontControllerFactory : FrontControllerFactory
    {

        //note - this should probably be in a seperate factory????
        private CommandBroker get_command_broker()
        {
            IList<RequestCommand> all_commands = get_available_commands();
            return new DefaultCommandBroker(all_commands);
        }

        private IList<RequestCommand> get_available_commands()
        {
            IList<RequestCommand> all_commands = new List<RequestCommand>();

            DefaultGateway default_gateway = new DefaultGateway();
            PageRenderer page_renderer = new DefaultPageRenderer();
            all_commands.Add(new DefaultRequestCommand(request => true, new ViewMainDepartments(default_gateway, page_renderer, @"~/views/DepartmentBrowser.aspx")));
            return all_commands;
        }

        public FrontController get_front_controller()
        {
            return new DefaultFrontController(get_command_broker());
        }
    }
}
