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
        double _successValue;
        Language _language;

        GeneticAlgorithm<Key> _geneticAlgorithm;
        KeyManager _keyManager;
        int _iterationsCount;
        int _populationSize;
        private int v;
        private Language english;

        public Breaker(int iterationsCount,double successValue,Language language)
        {
            _iterationsCount = iterationsCount;
            _successValue = successValue;
            _language = language;
        }

        public Breaker(int iterationsCount, Language language):this(iterationsCount,0,language)
        {
        }

        public Tuple<Key,string> FindKey(string text)
        {
            var analyzer=new Analyzer(_language);
            var statisticalInfo = analyzer.Analyze(text);
            _keyManager =new KeyManager(statisticalInfo);
            _geneticAlgorithm=new GeneticAlgorithm<Key> (_keyManager);
            var minFitness = double.MaxValue;
            Key bestKey = null;
           _geneticAlgorithm.SolveProblem(_iterationsCount, (x) =>
           {
                var solution = x.GetSolution();
               Console.WriteLine(solution.Fitness);
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
