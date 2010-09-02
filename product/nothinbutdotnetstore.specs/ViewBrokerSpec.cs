using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class ViewBrokerSpec
    {
        public abstract class concern : Observes<ViewBroker,
                                            DefaultViewBroker>
        {
        }

        [Subject(typeof(DefaultViewBroker))]
        public class when_view_for_type_is_requested : concern
        {
            Establish c = () =>
            {
                expected_view = new DefaultViewFor<int>();
                default_views_path_registry = new DefaultViewPathRegistry();
                default_views_path_registry.register_path_for<int>("blah");
                provide_a_basic_sut_constructor_argument(default_views_path_registry);

                Func<string, Type, object> FakePageFactory =
                    (path, type) =>
                    {
                        requested_path = path;
                        requested_model = type;
                        return ((object) expected_view);
                    };
                change(() => DefaultViewBroker.page_factory).to(FakePageFactory);
            };

            Because b = () =>
                result = sut.get_view_for<int>();

            It should_return_correct_view = () =>
                result.ShouldBe(typeof(ViewFor<int>));

            static ViewFor<int> result;
            static ViewFor<int> expected_view;
            static DefaultViewPathRegistry default_views_path_registry;
            static string requested_path;
            static Type requested_model;
        }
    }
}