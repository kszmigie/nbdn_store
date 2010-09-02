using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.web.application
{//<a href=<%=Server.UrlEncode(Url.For(department))%>"?department=<%Server.UrlEncode(department.name)%>"><%=department.name%></a>
    public class Url
    {
        private static IEnumerable<Product> _productRepository;

        public Url(IEnumerable<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public static string For(Department department)
        {
            if (department.has_products)
            {
                return typeof(ViewProducts).Name + ".store?Department=" + department.name;
            }

            return typeof(ViewSubDepartments).Name + ".store?Department=" + department.name;
        }
    }
}