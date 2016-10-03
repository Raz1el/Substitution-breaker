namespace Substitution_breaker.Genetic_algorithm
{
    public interface IPopulationManager
    {
        Population CreatePopulation();
        Population Selection(Population population);
    }
}