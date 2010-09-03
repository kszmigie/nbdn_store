using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.infrastructure
{
    public static class EnumerableExtensions
    {
        public static void each<ItemToVisit>(this IEnumerable<ItemToVisit> items_to_visit, Visitor<ItemToVisit> visitor)
        {
            items_to_visit.each(visitor.visit);
        }

        public static void each<ItemToVisit>(this IEnumerable<ItemToVisit> items_to_visit, Action<ItemToVisit> visitor)
        {
            foreach(ItemToVisit item in items_to_visit) visitor(item);
        }
    }
}