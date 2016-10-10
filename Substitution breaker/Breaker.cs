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
        const double DefaultSuccesValue = 0.95;

        double _successValue;
        Language _language;

        GeneticAlgorithm<Key> _geneticAlgorithm;
        KeyManager _keyManager;
        int _iterationsCount;
        int _populationSize;



        public Breaker(int iterationsCount,double successValue,Language language)
        {
            _iterationsCount = iterationsCount;
            _successValue = successValue;
            _language = language;
        }

     


        public Tuple<Key,string> FindKey(string text)
        {
            var analyzer=new Analyzer();
            var statisticalInfo = analyzer.Analyze(text,_language);
            _keyManager =new KeyManager(statisticalInfo);
            _geneticAlgorithm=new GeneticAlgorithm<Key> (_keyManager);
            var minFitness = double.MaxValue;
            Key bestKey = null;
           _geneticAlgorithm.SolveProblem(_iterationsCount, (x) =>
            {
                var solution = x.GetSolution();
                if (solution.Fitness < minFitness)
                {
                    minFitness = solution.Fitness;
                    bestKey = solution;
                }

                return x.GetSolution().Fitness < _successValue;
            }).GetSolution();
            return new Tuple<Key, string>(bestKey,bestKey.Decrypt(text));

        }

     
    }
}
