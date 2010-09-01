using System.Web.UI;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultViewFor<Model> : Page,ViewFor<Model>
    {
        public Model model { get; set; }
    }
}