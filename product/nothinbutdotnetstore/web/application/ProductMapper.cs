using System;
using System.Collections.Specialized;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.web.application
{
    public class ProductMapper : Mapper<NameValueCollection,Product>
    {
        public static string id_tag = "product_id";


        public Product map(NameValueCollection input)
        {
            return new Product() {id = Convert.ToInt32(input[id_tag])};
        }
    }
}