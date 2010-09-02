 using System;
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

         [Subject(typeof(DefaultContainer))]
         public class when_getting_a_dependency_by_type_and_the_resolver_can_create_it : concern
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
                 result = sut.an(typeof(IDbConnection));


             It should_return_the_created_dependency_to_the_client = () =>
                 result.ShouldEqual(the_connection);

             static object result;
             static IDbConnection the_connection;
             static DependencyResolver dependency_resolver;
             static ResolverRegistry resolver_registry;
         }

         [Subject(typeof(DefaultContainer))]
         public class when_getting_a_dependency_and_the_resolver_for_that_dependency_throws_an_error : concern
         {
             Establish c = () =>
             {
                 dependency_resolver = an<DependencyResolver>();
                 inner_exception = new Exception();
                 resolver_registry = the_dependency<ResolverRegistry>();

                 resolver_registry.Stub(x => x.get_resolver_to_create(typeof(IDbConnection))).Return(dependency_resolver);
                 dependency_resolver.Stub(x => x.create()).Throw(inner_exception);
             };

             Because b = () =>
                 catch_exception(() => sut.an<IDbConnection>());


             It should_throw_a_dependency_creation_exception_with_access_to_the_necessary_information = () =>
             {
                 var exception = exception_thrown_by_the_sut.ShouldBeAn<DependencyCreationException>();
                 exception.InnerException.ShouldEqual(inner_exception);
                 exception.type_that_could_not_be_created.ShouldEqual(typeof(IDbConnection));
             };

             static DependencyResolver dependency_resolver;
             static ResolverRegistry resolver_registry;
             static Exception inner_exception;
         }

         [Subject(typeof(DefaultContainer))]
         public class when_getting_a_dependency_and_the_resolver_cannot_be_found : concern
         {
             Establish c = () =>
             {
                 dependency_resolver = an<DependencyResolver>();
                 inner_exception = new Exception();
                 resolver_registry = the_dependency<ResolverRegistry>();

                 resolver_registry.Stub(x => x.get_resolver_to_create(typeof(IDbConnection))).Return(null);
             };

             Because b = () =>
                 catch_exception(() => sut.an<IDbConnection>());


             It should_throw_a_dependency_resolver_not_found_exception_with_access_to_the_necessary_information = () =>
             {
                 var exception = exception_thrown_by_the_sut.ShouldBeAn<DependencyResolverNotFoundException>();
                 exception.type_for_which_resolver_not_found.ShouldEqual(typeof(IDbConnection));
             };

             static DependencyResolver dependency_resolver;
             static ResolverRegistry resolver_registry;
             static Exception inner_exception;
         }
     }
 }
