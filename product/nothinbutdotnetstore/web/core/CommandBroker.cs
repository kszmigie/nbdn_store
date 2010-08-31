namespace nothinbutdotnetstore.web.core
{
    public interface CommandBroker
    {
        RequestCommand get_command_that_can_process(Request request);
    }
}