namespace nothinbutdotnetstore.web.core
{
    public interface Renderer
    {
        void render<ViewModel>(ViewModel view_model);
    }
}