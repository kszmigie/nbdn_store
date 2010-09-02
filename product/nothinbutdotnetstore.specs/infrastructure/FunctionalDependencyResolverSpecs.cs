using System;
using System.Data;
using System.Data.SqlClient;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers.basic;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class FunctionalDependencyResolverSpecs
    {
        public abstract class concern : Observes<DependencyResolver,
                                            FunctionalDependencyResolver>
        {
        }

        [Subject(typeof(FunctionalDependencyResolver))]
        public class when_creating_an_dependency : concern
        {
            Establish c = () =>
            {
                the_connection = new SqlConnection();
                provide_a_basic_sut_constructor_argument<Func<object>>(() => the_connection);
            };

            Because b = () =>
                result = sut.create();

            It should_return_the_dependency_created_by_the_factory = () =>
                result.ShouldEqual(the_connection);

            static object result;
            static IDbConnection the_connection;
        }
    }
}