namespace Substitution_breaker.Genetic_algorithm
{
    public interface IPopulationManager<T>
    {
        Population<T> CreatePopulation();
        Population<T> Selection(Population<T> population);
    }
}