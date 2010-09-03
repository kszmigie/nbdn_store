 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.model;
 using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.specs.web
 {   
     public class UrlSpecs
     {
         public abstract class concern : Observes<Url>
         {
        
         }

         [Subject(typeof(Url))]
         
         public class when_constructing_url_for_product : concern
         {
             private Establish c = () =>
                                       {
                                           product = an<Product>();
                                           product.id = 1;
                                           
                                       };

             private Because b = () =>
                                     {
                                         result = Url.For(product);
                                     };

             private It should_return_valid_url = () => result.ShouldEqual("productdetails.aspx?product_id=99");
             private static string result;
             private static Product product;
         }
     }
 }
