using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substitution_breaker.Genetic_algorithm;

namespace Substitution_breaker
{
    public class KeyManager : IPopulationManager<Key>
    {
        DistributionData _data;


        public KeyManager(DistributionData data)
        {
            _data = data;
        }
        
        public Population<Key> CreatePopulation()
        {
            throw new NotImplementedException();
        }

        public Population<Key> Selection(Population<Key> population)
        {
            throw new NotImplementedException();
        }

        public Key BuildKey(string text)
        {
            throw new NotImplementedException();
        }
    }
}
