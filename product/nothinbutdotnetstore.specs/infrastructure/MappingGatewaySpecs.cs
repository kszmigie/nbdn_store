using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class MappingGatewaySpecs
    {
        public abstract class concern : Observes<MappingGateway,
                                            DefaultMappingGateway>
        {
        }

        [Subject(typeof(DefaultMappingGateway))]
        public class when_asked_to_map_a_valid_input_to_an_output : concern
        {
            Establish c = () =>
            {
                input_thing = new InputThing();
                expected_result = new OutputThing();
                mapper_registry = the_dependency<MapperRegistry>();
                var mapper = new MyMapper<InputThing, OutputThing>(expected_result);

                mapper_registry.Stub(x => x.get_mapper_to_map<InputThing, OutputThing>()).Return(mapper);
            };

            Because b = () =>
                result = sut.map<InputThing, OutputThing>(input_thing);

            It should_map_the_input_using_the_appropriate_mapper = () =>
                result.ShouldEqual(expected_result);

            static OutputThing result;
            static OutputThing expected_result;
            static InputThing input_thing;
            static MapperRegistry mapper_registry;
        }

        class MyMapper<Input, Output> : Mapper<Input, Output>
        {
            Output the_result;

            public MyMapper(Output the_result)
            {
                this.the_result = the_result;
            }

            public Output map(Input input)
            {
                return the_result;
            }
        }

        class OutputThing
        {
        }

        class InputThing
        {
        }
    }
}