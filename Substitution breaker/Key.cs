using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substitution_breaker.Genetic_algorithm;

namespace Substitution_breaker
{
    public class Key:ISolution
    {
        public DistributionData StatisticalInformation { get; set; }
        public Dictionary<char,char> Substitution { get; set; }



        public double FitnessFunction()
        {
            throw new NotImplementedException();
        }

        public ISolution Crossover(ISolution otherSolution)
        {
            throw new NotImplementedException();
        }

        public ISolution Mutation()
        {
            throw new NotImplementedException();
        }

        public string Decrypt(string text)
        {
            foreach (var key in Substitution.Keys)
            {
                text.Replace(key, Substitution[key]);
            }
            return text;
        }
    }
}
