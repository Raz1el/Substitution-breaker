using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substitution_breaker.Genetic_algorithm;

namespace Substitution_breaker
{
    public class KeyManager : IPopulationManager<Key>
    {
        const int PopulationSize=1;

        DistributionData _data;
        string _text;
        HashSet<string> _oldKeys;
      



        public KeyManager(DistributionData data,string text)
        {
            _data = data;
            _text = text;
            _oldKeys = new HashSet<string>();
        }
        
        public Population<Key> CreatePopulation()
        {
            var solutions = BuildKeys();
           
            return new Population<Key>(solutions);
            
        }

        public Population<Key> Selection(Population<Key> population)
        {

            var solutions = population.Solutions;
          
            for (int i = 0; i < PopulationSize; i++)
            {
                var parent = solutions.ElementAt(i);
                var child = solutions.ElementAt(i).Evolve();
                if (child == parent)
                {
                    _oldKeys.Add(child.ToString());
                    solutions.Remove(parent);
                    while (_oldKeys.Contains(child.ToString()))
                    {
                        child = parent.Mutate();
                    }
                    solutions.Add(child);

                }
                else if (!solutions.Contains(child)&&!_oldKeys.Contains(child.ToString()))
                {
                    solutions.Add(child);
                }

            }
            var newSolutions = population.Solutions.OrderBy(x => x.FitnessFunction()).Take(PopulationSize);
            return new Population<Key>(new HashSet<ISolution<Key>>(newSolutions));
        }

        public HashSet<ISolution<Key>> BuildKeys()
        {

            var solutions = new HashSet<ISolution<Key>>();
            var substitution = new Dictionary<char, char>();
            var orderedLetterDistribution = _data.LettersDistribution.OrderBy(x => x.Value).Select(x => x.Key).ToArray();
            var orderedLetterDistributionSample = _data.LettersDistributionSample.OrderBy(x => x.Value).Select(x => x.Key).ToArray();
            for (int i = 0; i < _data.LettersDistribution.Count; i++)
            {
                substitution.Add(orderedLetterDistributionSample[i], orderedLetterDistribution[i]);
            }
            var key = new Key(substitution, _data);
            solutions.Add(key);
            ISolution<Key> newKey = key;

            for (int i = 0; i < PopulationSize; i++)
            {
                newKey = newKey.Mutate();
                solutions.Add(newKey);
            }
            return solutions;
        }

     
        
    }
}
