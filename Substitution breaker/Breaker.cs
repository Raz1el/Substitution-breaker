using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substitution_breaker.Genetic_algorithm;

namespace Substitution_breaker
{
    public class State : EventArgs
    {
        public int Progress { get;  }
        public string Status { get;  }

        public State(int progress,string status)
        {
            Progress = progress;
            Status = status;
        }

    }
    public class Breaker
    {
        double _successValue;
        Language _language;

        GeneticAlgorithm<Key> _geneticAlgorithm;
        KeyManager _keyManager;
        int _iterationsCount;
        int _populationSize;

        public int _progress;
        public string _status;

        public event EventHandler<State> StateChanged;


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
                _progress++;
                _status = solution.Fitness.ToString();
               if (StateChanged != null)
               {
                   StateChanged(this, new State(_progress, _status));
               }
          
                if (solution.Fitness < minFitness)
                {
                    minFitness = solution.Fitness;
                    bestKey = solution;
                }

                return x.GetSolution().Fitness < _successValue;
            }).GetSolution();
            _progress=0;
            _status = "";
            return new Tuple<Key, string>(bestKey,bestKey.Decrypt(text));

        }

        public Task<Tuple<Key, string>> FindKeyAsync(string text)
        {
            return Task.Run(() =>
            {
                var analyzer = new Analyzer(_language);
                var statisticalInfo = analyzer.Analyze(text);
                _keyManager = new KeyManager(statisticalInfo);
                _geneticAlgorithm = new GeneticAlgorithm<Key>(_keyManager);
                var minFitness = double.MaxValue;
                Key bestKey = null;
                _geneticAlgorithm.SolveProblem(_iterationsCount, (x) =>
                {
                    var solution = x.GetSolution();
                    _progress++;
                    _status = solution.Fitness.ToString();
                    if (StateChanged != null)
                    {
                        StateChanged(this, new State(_progress, _status));
                    }
                    if (solution.Fitness < minFitness)
                    {
                        minFitness = solution.Fitness;
                        bestKey = solution;
                    }

                    return x.GetSolution().Fitness < _successValue;
                }).GetSolution();
                _progress = 0;
                _status = "";
                return new Tuple<Key, string>(bestKey, bestKey.Decrypt(text));
            });
        }
    }
}
