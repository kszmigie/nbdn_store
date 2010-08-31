namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequestCommand : RequestCommand
    {
        RequestCriteria criteria;
        ApplicationCommand application_command;

        public DefaultRequestCommand(RequestCriteria criteria, ApplicationCommand application_command)
        {
            this.criteria = criteria;
            this.application_command = application_command;
        }

        public void process(Request request)
        {
            application_command.process(request);
        }

        public bool can_handle(Request request)
        {
            return criteria(request);
        }
    }
}