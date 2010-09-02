 using System.Data;
 using System.Data.SqlClient;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure.containers;
 using nothinbutdotnetstore.infrastructure.containers.basic;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.infrastructure
 {   
     public class ContainerSpecs
     {
         public abstract class concern : Observes<Container,
                                             DefaultContainer>
         {
        
         }

         [Subject(typeof(DefaultContainer))]
         public class when_getting_an_dependency_and_it_has_the_resolver_for_that_dependency : concern
         {
             Establish c = () =>
             {
                 the_connection = new SqlConnection();
                 dependency_resolver = an<DependencyResolver>();
                 resolver_registry = the_dependency<ResolverRegistry>();

                 resolver_registry.Stub(x => x.get_resolver_to_create(typeof(IDbConnection))).Return(dependency_resolver);
                 dependency_resolver.Stub(x => x.create()).Return(the_connection);
             };

             Because b = () =>
                 result = sut.an<IDbConnection>();


             It should_return_the_created_dependency_to_the_client = () =>
                 result.ShouldEqual(the_connection);

             static IDbConnection result;
             static IDbConnection the_connection;
             static DependencyResolver dependency_resolver;
             static ResolverRegistry resolver_registry;
         }
     }
 }
