using System.Collections.Generic;
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

                    capable_mapper = an<Mapper>();
                    mappers = new [] {capable_mapper};
                    provide_a_basic_sut_constructor_argument(mappers);

                    capable_mapper.Stub(x => x.can_map<InputThing, OutputThing>(input_thing)).Return(true);
                    capable_mapper.Stub(x => x.map<InputThing, OutputThing>(input_thing)).Return(expected_result);
                };

            Because b = () =>
                result = sut.map<InputThing, OutputThing>(input_thing);

            It should_return_the_output_object = () =>
                result.ShouldEqual(expected_result);

            static OutputThing result;
            static OutputThing expected_result;
            static InputThing input_thing;
            static IEnumerable<Mapper> mappers;
            static Mapper capable_mapper;
        }

        [Subject(typeof(DefaultMappingGateway))]
        public class when_asked_to_map_an_invalid_input : concern
        {

            Establish c = () =>
                {
                    input_thing = new InputThing();

                    incapable_mapper = an<Mapper>();
                    mappers = new [] {incapable_mapper};
                    provide_a_basic_sut_constructor_argument(mappers);

                    incapable_mapper.Stub(x => x.can_map<InputThing, OutputThing>(input_thing)).Return(false);
                };

            Because b = () =>
                result = sut.can_map<InputThing, OutputThing>(input_thing);

            It should_indicate_that_mapping_is_not_possible= () =>
                result.ShouldEqual(false);

            static bool result;
            static InputThing input_thing;
            static IEnumerable<Mapper> mappers;
            static Mapper incapable_mapper;
        }

        class OutputThing
        {
        }
        class InputThing
        {
        }
    }
 }
