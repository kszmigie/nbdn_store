namespace nothinbutdotnetstore.web.core
{
    public interface ViewBroker
    {
        ViewFor<ViewModel> get_view_for<ViewModel>();
    }
}