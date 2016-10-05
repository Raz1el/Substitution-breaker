using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substitution_breaker.Genetic_algorithm;

namespace Substitution_breaker
{
    public class Breaker
    {
        GeneticAlgorithm<Key> _geneticAlgorithm;
        KeyManager _keyManager;
        int _iterationsCount;

        public Breaker(int iterationsCount)
        {
            _iterationsCount = iterationsCount;
        }


        public Dictionary<Key,string> Decrypt(string text)
        {
            var analyzer=new Analyzer();
            var statisticalInfo = analyzer.Analyze(text);
            _keyManager =new KeyManager(statisticalInfo);
            _geneticAlgorithm=new GeneticAlgorithm<Key> (_keyManager);
            var possibleKeys=_geneticAlgorithm.SolveProblem(_iterationsCount, x => false).Solutions.Select(x=>x.GetSolution());
            return possibleKeys.ToDictionary(possibleKey => possibleKey, possibleKey => possibleKey.Decrypt());

        }
    }
}
