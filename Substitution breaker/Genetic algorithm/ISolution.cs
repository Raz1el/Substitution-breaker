using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substitution_breaker.Genetic_algorithm
{
    public interface ISolution<T>
    {
        double FitnessFunction();
        ISolution<T> Evolve();
        ISolution<T> Mutate();
        T GetSolution();
    }
}
