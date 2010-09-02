using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultViewPathRegistry : ViewPathRegistry
    {
        IDictionary<Type, string> items = new Dictionary<Type, string>();

        public void register_path_for<ViewModel>(string path)
        {
            items.Add(typeof(ViewModel), path);
        }

        public string get_path_for<ViewModel>()
        {
            return items[typeof(ViewModel)];
        }
    }
}