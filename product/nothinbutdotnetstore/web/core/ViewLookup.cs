using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core
{
    public class ViewLookup
    {
        Dictionary<Type, string> items = new Dictionary<Type, string>();


        public void Add(Type view_type, string view_page)
        {
            items.Add(view_type, view_page);
        }

        public string this[Type type]
        {
            get { return items[type]; }
        }
    }
}