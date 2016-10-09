using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substitution_breaker.Genetic_algorithm
{
    public class GeneticAlgorithm<T>
    {
        readonly IPopulationManager<T> _populationManager;


        public GeneticAlgorithm(IPopulationManager<T> populationManager)
        {
            _populationManager = populationManager;
        }
        public Population<T> SolveProblem(int iterations,Predicate<Population<T>> terminationCondition)
        {
            Population<T> population = _populationManager.CreatePopulation();
            for (int i = 0; i < iterations; i++)
            {
                population = _populationManager.Selection(population);

                Console.WriteLine(i.ToString() + " " +population.AverageFitness.ToString());
                if (terminationCondition(population))
                {
                    return population;
                }
            }
            return population;
        }
    }
}

