namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public static class ConstructorSelectionStrategies
    {
        public static ConstructorSelectionStrategy Greedy = new GreedyConstructorSelectionStrategy();
    }
}