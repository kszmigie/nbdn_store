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
                     name_values[DepartmentMapper.name_tag] = "blah";
                 };

             Because b = () =>
                 result = sut.map(name_values);

             It should_return_a_valid_object_from_the_data = () =>
                 result.name.ShouldEqual("blah");

             static Department result;
             static NameValueCollection name_values;
         }
     }
 }
