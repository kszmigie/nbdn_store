namespace nothinbutdotnetstore.web.core
{
    public interface ViewPathRegistry
    {
        void register_path_for<ViewModel>(string path);
        string get_path_for<ViewModel>();
    }
}