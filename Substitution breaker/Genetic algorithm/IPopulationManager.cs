namespace Substitution_breaker.Genetic_algorithm
{
    public interface IPopulationManager
    {
        Population CreatePopulation();
        Population Selection(Population population);
        ISolution Crossover(ISolution firstSolution, ISolution secondSolution);
        ISolution Mutation(ISolution solution);
    }
}