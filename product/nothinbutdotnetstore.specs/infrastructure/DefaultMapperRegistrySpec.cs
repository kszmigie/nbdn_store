 using System;
 using System.Collections.Generic;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.specs.infrastructure
 {   
     public class MapperRegistrySpec
     {
         public abstract class concern : Observes<MapperRegistry,DefaultMapperRegistry>
         {
        
         }

         [Subject(typeof(DefaultMapperRegistry))]
         public class when_mapper_is_requested_for_inputtype : concern
         {
             private Establish c = () =>
                                       {
                                           expected_mapper = an<Mapper<int, string>>();
                                           mappers_collection = new Dictionary<Type, Dictionary<Type, object>>();
                                           subDict = new Dictionary<Type,object>();
                                           subDict.Add(typeof(string),expected_mapper);
                                           mappers_collection.Add(typeof (int), subDict);
                                           provide_a_basic_sut_constructor_argument(mappers_collection);
                                       };
             private Because b = () =>  mapper = sut.get_mapper_to_map<int,string>();


             private It should_return_proper_mapper = () => mapper.ShouldEqual(expected_mapper);
             
             static Dictionary<Type, Dictionary<Type, object>> mappers_collection;
             static Dictionary<Type, object> subDict;
             private static Mapper<int,string> mapper;
             private static Mapper<int,string> expected_mapper;
         }
     }
 }
