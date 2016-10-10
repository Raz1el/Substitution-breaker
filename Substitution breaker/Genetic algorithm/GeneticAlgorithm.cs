using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substitution_breaker.Genetic_algorithm
{
    public class GeneticAlgorithm<T>
    {
        readonly ISolutionManager<T> _populationManager;


        public GeneticAlgorithm(ISolutionManager<T> populationManager)
        {
            _populationManager = populationManager;
        }
        public ISolution<T> SolveProblem(int iterations,Predicate<ISolution<T>> terminationCondition)
    
        {
            ISolution<T> solution = _populationManager.CreateSolution();
            for (int i = 0; i < iterations; i++)
            {
                solution = _populationManager.Selection(solution);
                Console.WriteLine(i + " " +solution.FitnessFunction());
                if (terminationCondition(solution))
                {
                    return solution;
                }
            }
            return solution;
        }
    }
}

