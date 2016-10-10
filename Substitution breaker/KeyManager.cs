using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substitution_breaker.Genetic_algorithm;

namespace Substitution_breaker
{
    public class KeyManager : ISolutionManager<Key>
    {


        DistributionData _data;
        HashSet<string> _oldKeys;
      



        public KeyManager(DistributionData data)
        {
            _data = data;
            _oldKeys = new HashSet<string>();
        }
        
        public ISolution<Key> CreateSolution()
        {
           
            return BuildKey();
            
        }

        public ISolution<Key> Selection(ISolution<Key> solution)
        {
            var parent = solution;
            var child = parent.Evolve();
            var childString = child.ToString();
            var parentString = parent.ToString();
            if (childString==parentString|| _oldKeys.Contains(childString))
            {
                while (_oldKeys.Contains(childString))
                {
                    child = parent.Mutate();
                    childString = child.ToString();
                }
            }
            _oldKeys.Add(childString);
            return child;
        }

        public ISolution<Key> BuildKey()
        {
            var substitution = new Dictionary<char, char>();
            var orderedLetterDistribution = _data.LettersDistribution.OrderBy(x => x.Value).Select(x => x.Key).ToArray();
            var orderedLetterDistributionSample = _data.LettersDistributionSample.OrderBy(x => x.Value).Select(x => x.Key).ToArray();
            for (int i = 0; i < _data.LettersDistribution.Count; i++)
            {
                substitution.Add(orderedLetterDistributionSample[i], orderedLetterDistribution[i]);
            }
           return new Key(substitution, _data);
        }

     
        
    }
}
