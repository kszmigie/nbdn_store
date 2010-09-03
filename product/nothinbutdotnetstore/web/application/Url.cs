using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.web.application
{//<a href=<%=Server.UrlEncode(Url.For(department))%>"?department=<%Server.UrlEncode(department.name)%>"><%=department.name%></a>
    public class Url
    {
        private static IEnumerable<Product> _productRepository;
        private static string default_extension = ".store?";

        public Url(IEnumerable<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public static string For(Department department)
        {
            string query_string = DepartmentMapper.id_tag + "=" + department.id;
            if (department.has_products)
            {
                return typeof (ViewProducts).Name + default_extension + query_string;
            }
            return typeof (ViewSubDepartments).Name + default_extension + query_string;
        }
                
        public static string For(Product product)
        {
         
            string query_string = ProductMapper.id_tag + "=" + product.id;
            return (typeof (ViewProductDetails)).Name + default_extension + query_string;
        }

    }
}