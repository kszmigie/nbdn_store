using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;

namespace nothinbutdotnetstore.specs
{
    public class MessageGeneratorSpecs
    {
        public abstract class concern : Observes<MessageGenerator>
        {
        }

        [Subject(typeof(MessageGenerator))]
        public class when_a_message_is_sent : concern
        {
            static string result;

            Because b = () =>
                result = sut.say_back_message("blah");

            It should_send_back_the_message_it_was_told = () =>
                result.ShouldEqual("blah");
        }
    }
}