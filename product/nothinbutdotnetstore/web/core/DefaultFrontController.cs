namespace nothinbutdotnetstore.web.core
{
    public class DefaultFrontController : FrontController
    {
        CommandBroker command_broker;

        public DefaultFrontController(CommandBroker command_broker)
        {
            this.command_broker = command_broker;
        }

        public void process(Request request)
        {
            command_broker.get_command_that_can_process(request)
                .process(request);
        }
    }
}