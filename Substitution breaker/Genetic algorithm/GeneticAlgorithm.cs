using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substitution_breaker.Genetic_algorithm
{
    public class GeneticAlgorithm
    {
        readonly IPopulationManager _populationManager;


        public GeneticAlgorithm(IPopulationManager populationManager)
        {
            _populationManager = populationManager;
        }
        public Population SolveProblem(int iterations,Predicate<Population> terminationCondition)
        {
            Population population = _populationManager.CreatePopulation();
            for (int i = 0; i < iterations; i++)
            {
                population = _populationManager.Selection(population);
                if (terminationCondition(population))
                    return population;
            }
            return population;
        }
    }
}

