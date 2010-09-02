namespace nothinbutdotnetstore.infrastructure
{
    public interface Mapper
    {
        bool can_map<Input, Output>(Input input);
        Output map<Input, Output>(Input input);
    }
}