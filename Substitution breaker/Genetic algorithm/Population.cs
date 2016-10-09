using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substitution_breaker.Genetic_algorithm
{
    public class Population<T>
    {
       public HashSet<ISolution<T>> Solutions { get; set; }


        public double AverageFitness
        {
            get
            {
                var res = 0.0;
                foreach (var solution in Solutions)
                {
                    res += solution.FitnessFunction();
                }
                return res/Solutions.Count;
            }
        } 


        public Population(HashSet<ISolution<T>> solutions)
        {
            Solutions = solutions;
        }

        public void Add(ISolution<T> newSolution)
        {
            Solutions.Add(newSolution);
        }
    }
}
