namespace nothinbutdotnetstore.infrastructure
{
    public interface Visitor<ItemToVisit>
    {
        void visit(ItemToVisit item_to_visit);
    }
}