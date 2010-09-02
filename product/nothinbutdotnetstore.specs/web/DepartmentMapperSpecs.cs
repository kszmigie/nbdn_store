 using System.Collections.Specialized;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure;
 using nothinbutdotnetstore.model;
 using nothinbutdotnetstore.web;

namespace nothinbutdotnetstore.specs.web
 {   
     public class DepartmentMapperSpecs
     {
         public abstract class concern : Observes<Mapper<NameValueCollection, Department>,
                                             DepartmentMapper>
         {
        
         }

         [Subject(typeof(DepartmentMapper))]
         public class when_mapping_an_object_from_a_valid_input: concern
         {

             Establish c = () =>
                 {
                     name_values = new NameValueCollection();
                     name_values[DepartmentMapper.id_tag] = "123";
                 };

             Because b = () =>
                 result = sut.map(name_values);

             It should_return_a_valid_object_from_the_data = () =>
                 result.id.ShouldEqual(123);

             static Department result;
             static NameValueCollection name_values;
         }
     }
 }
