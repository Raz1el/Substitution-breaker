using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substitution_breaker.Genetic_algorithm
{
    public interface ISolution
    {
        double FitnessFunction();
        ISolution Crossover(ISolution otherSolution);
        ISolution Mutation();
    }
}
