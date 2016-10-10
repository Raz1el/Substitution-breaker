namespace Substitution_breaker.Genetic_algorithm
{
    public interface ISolutionManager<T>
    {
        ISolution<T> CreateSolution();
        ISolution<T> Selection(ISolution<T> population);
    }
}