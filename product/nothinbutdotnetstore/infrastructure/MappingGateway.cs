namespace nothinbutdotnetstore.infrastructure
{
    public interface MappingGateway
    {
        Output map<Input, Output>(Input input);
        bool can_map<Input, Output>(Input input);
    }
}