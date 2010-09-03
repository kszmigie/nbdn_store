namespace nothinbutdotnetstore.tasks.startup
{
    public interface StartupBuilder
    {
        StartupBuilder followed_by<T>() where T :StartupCommand;
        void finish_by<T>();
    }
}