using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.basic;
using Rhino.Mocks;
using System.Linq;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class AutomaticDependencyResolverSpecs
    {
        public abstract class concern : Observes<DependencyResolver,
                                            AutomaticDependencyResolver>
        {
        }

        [Subject(typeof(AutomaticDependencyResolver))]
        public class when_creating_a_dependency_that_has_other_dependencies : concern
        {
            Establish c = () =>
            {
                the_container = the_dependency<Container>();
                constructor_selection_strategy = the_dependency<ConstructorSelectionStrategy>();
                provide_a_basic_sut_constructor_argument(typeof(MyDependencyWithOtherDependencies));

                the_connection = new SqlConnection();
                the_command = an<IDbCommand>();
                the_reader = an<IDataReader>();

                the_constructor =
                    typeof(MyDependencyWithOtherDependencies).GetConstructors().OrderByDescending(
                        x => x.GetParameters().Count()).First();


                the_container.Stub(x => x.an(typeof(IDbConnection))).Return(the_connection);
                the_container.Stub(x => x.an(typeof(IDbCommand))).Return(the_command);
                the_container.Stub(x => x.an(typeof(IDataReader))).Return(the_reader);

                constructor_selection_strategy.Stub(x => x.get_applicable_constructor_on(typeof(MyDependencyWithOtherDependencies))).Return(the_constructor);
            };

            Because b = () =>
                result = sut.create();


            It should_return_the_dependency_with_all_of_its_dependencies_provided = () =>
            {
                var item = result.ShouldBeAn < MyDependencyWithOtherDependencies >();
                item.connection.ShouldEqual(the_connection);
                item.command.ShouldEqual(the_command);
                item.reader.ShouldEqual(the_reader);
            };

            static object result;
            static IDbConnection the_connection;
            static IDbCommand the_command;
            static IDataReader the_reader;
            static Container the_container;
            static ConstructorSelectionStrategy constructor_selection_strategy;
            static ConstructorInfo the_constructor;
        }
    }

    public class MyDependencyWithOtherDependencies
    {
        public IDbConnection connection;
        public IDataReader reader;
        public IDbCommand command;

        public MyDependencyWithOtherDependencies(IDbConnection connection, IDataReader reader, IDbCommand command)
        {
            this.connection = connection;
            this.reader = reader;
            this.command = command;
        }

        public MyDependencyWithOtherDependencies(IDbConnection connection, IDataReader reader)
        {
            this.connection = connection;
            this.reader = reader;
        }
    }
}