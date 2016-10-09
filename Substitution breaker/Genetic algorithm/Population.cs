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

        double _averageFitness;
        public double AverageFitness
        {
            get
            {
                if (_averageFitness == 0)
                {
                    var res = 0.0;
                    foreach (var solution in Solutions)
                    {
                        res += solution.FitnessFunction();
                    }
                    return res/Solutions.Count;
                }
                else
                {
                    return _averageFitness;
                }
            }
            set { _averageFitness = value; }
        } 


        public Population(HashSet<ISolution<T>> solutions)
        {
            Solutions = solutions;
            _averageFitness = 0;
        }

     
    }
}
