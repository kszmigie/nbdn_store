using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public interface PageRenderer
    {
        void Render(Request request, string path, object view_model);
    }
}