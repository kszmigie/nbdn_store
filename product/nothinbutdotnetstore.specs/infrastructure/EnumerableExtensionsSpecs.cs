using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class EnumerableExtensionsSpecs
    {
        public abstract class concern : Observes
        {
        }

        [Subject(typeof(EnumerableExtensions))]
        public class when_visiting_each_item_in_a_sequence : concern
        {
            Establish c =
                () => { items_to_visit = new List<ItemToVisit>(Enumerable.Range(1, 100).Select(x => an<ItemToVisit>())); };

            Because b = () =>
                EnumerableExtensions.each(items_to_visit, x => x.visit());

            It should_run_the_visitor_against_each_item = () =>
            {
                foreach (var item in items_to_visit)
                {
                    item.received(x => x.visit());
                }
            };

            static IEnumerable<ItemToVisit> items_to_visit;
        }

        public interface ItemToVisit
        {
            void visit();
        }
    }
}