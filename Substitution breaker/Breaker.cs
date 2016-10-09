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

        const int DefaultPopulationSize=1;
        const double DefaultSuccesValue = 0.95;

        double _successValue;
        Language _language;

        GeneticAlgorithm<Key> _geneticAlgorithm;
        KeyManager _keyManager;
        int _iterationsCount;
        int _populationSize;



        public Breaker(int iterationsCount,double successValue, int populationSize,Language language)
        {
            _iterationsCount = iterationsCount;
            _successValue = successValue;
            _populationSize = populationSize;
            _language = language;
        }

     


        public Dictionary<Key,string> Decrypt(string text)
        {
            var analyzer=new Analyzer();
            var statisticalInfo = analyzer.Analyze(text,_language);
            _keyManager =new KeyManager(statisticalInfo,text,_populationSize);
            _geneticAlgorithm=new GeneticAlgorithm<Key> (_keyManager);
            var possibleKeys = _geneticAlgorithm.SolveProblem(_iterationsCount, x => x.AverageFitness < _successValue).Solutions.Select(x => x.GetSolution());
            return possibleKeys.ToDictionary(possibleKey => possibleKey, possibleKey => possibleKey.Decrypt(text));

        }

     
    }
}
