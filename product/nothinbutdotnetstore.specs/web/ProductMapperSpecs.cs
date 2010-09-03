 using System.Collections.Specialized;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure;
 using nothinbutdotnetstore.model;
 using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.specs.web
 {   
     public class ProductMapperSpecs
     {
         public abstract class concern : Observes<Mapper<NameValueCollection,Product>,
                                             ProductMapper>
         {
        
         }

         [Subject(typeof(ProductMapper))]
         public class when_mapping_product_id_from_input : concern
         {
             private Establish c = () =>
                                       {
                                           expected_result = new Product() {id = 13}; 
                                           
                                           param_collection = new NameValueCollection();
                                           param_collection.Add(ProductMapper.id_tag, expected_result.id.ToString());
                                           
                                       };
             private Because b = () => result = sut.map(param_collection);
                                 

             private It should_return_valid_id = () => result.id.ShouldEqual(expected_result.id);
             private static Product expected_result;
             private static Product result;
             private static NameValueCollection param_collection;
         }
     }
 }
