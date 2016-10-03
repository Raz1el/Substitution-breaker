using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substitution_breaker.Genetic_algorithm;

namespace Substitution_breaker
{
    public class KeyManager : IPopulationManager
    {
        DistributionData _data;


        public KeyManager(DistributionData data)
        {
            _data = data;
        }
        
        public Population CreatePopulation()
        {
            throw new NotImplementedException();
        }

        public Population Selection(Population population)
        {
            throw new NotImplementedException();
        }

        public Key BuildKey(string text)
        {
            throw new NotImplementedException();
        }
    }
}
