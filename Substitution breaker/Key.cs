using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Substitution_breaker.Genetic_algorithm;

namespace Substitution_breaker
{
    public class Key:ISolution<Key>
    {
        public DistributionData StatisticalInformation { get; set; }
        public Dictionary<char,char> Substitution { get; set; }
        public string Text { get; set; }

        public Key(string text,DistributionData statisticalInfo)
        {
            Text = text;
            StatisticalInformation = statisticalInfo;
            Substitution=new Dictionary<char, char>();
            var orderedLetterDistribution = StatisticalInformation.LettersDistribution.OrderBy(x => x.Value).Select(x=>x.Key).ToArray();
            var orderedLetterDistributionSample = StatisticalInformation.LettersDistributionSample.OrderBy(x => x.Value).Select(x => x.Key).ToArray();
            for (int i = 0; i < StatisticalInformation.LettersDistribution.Count; i++)
            {
                Substitution.Add(orderedLetterDistributionSample[i],orderedLetterDistribution[i]);
            }
        }

        public double FitnessFunction()
        {
            throw new NotImplementedException();
        }


        public string Decrypt()
        {
            foreach (var key in Substitution.Keys)
            {
                Text.Replace(key, Substitution[key]);
            }
            return Text;
        }

        public ISolution<Key> Crossover(ISolution<Key> otherSolution)
        {
            throw new NotImplementedException();
        }

        public ISolution<Key> Mutation()
        {
            throw new NotImplementedException();
        }

        public Key GetSolution()
        {
            return this;
        }
    }
}
