using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substitution_breaker
{
    public class Analyzer
    {
        private char[] _alphabet;
        public Language Language { get; }

        public Analyzer(Language language)
        {
            Language = language;
            _alphabet = AlphabetHelper.GetAlphabet(language);
        }

        public DistributionData Analyze(string text)
        {                 
            var data = new DistributionData(Language, CountOnegramms(text), CountBigramms(text));
            return data;
        }

        public Dictionary<char,double> CountOnegramms(string text)
        {
            var distribution = GetLettersDistributionBase(_alphabet);
            var iters = text.Length;
            for (int i = 0; i < text.Length; i++)
            {
                var letter=char.ToLower(text[i]);
                if (distribution.ContainsKey(letter))
                    distribution[letter]++;
                else iters--;
            }

            var result = new Dictionary<char, double>();
            var temp = Convert.ToDouble(iters);
            foreach (var item in distribution)
            {
                result.Add(item.Key, item.Value / temp);
            }
            return result;
        }

        private Dictionary<char,int> GetLettersDistributionBase(IList<char> alphabet)
        {
            var temp = new Dictionary<char, int>();
            foreach (var letter in alphabet)
            {
                temp[letter] = 0;
            }
            return temp;
        }

        public Dictionary<Tuple<char,char>,double> CountBigramms(string text)
        {
            var distribution = GetBigrammsDistributionBase(_alphabet);
            var iters = text.Length;
            for (int i = 0; i < text.Length-1; i++)
            {                
                var bigramm = new Tuple<char, char>(char.ToLower(text[i]), char.ToLower(text[i + 1]));
                if(distribution.ContainsKey(bigramm))
                    distribution[bigramm]++;
                else iters--;
            }

            var result = new Dictionary<Tuple<char, char>, double>();
            var temp = Convert.ToDouble(iters);
            foreach (var item in distribution)
            {
                result.Add(item.Key, item.Value / temp);
            }
            return result;
        }

        private Dictionary<Tuple<char,char>,int> GetBigrammsDistributionBase(IList<char> alphabet)
        {
            var bigramms = GetBigramms(_alphabet);
            var temp = new Dictionary<Tuple<char, char>, int>();
            foreach (var bigramm in bigramms)
            {
                temp[bigramm] = 0;
            }
            return temp;
        }

        private List<Tuple<char,char>> GetBigramms(IList<char> alphabet)
        {
            var bigramms = new List<Tuple<char, char>>(alphabet.Count * alphabet.Count);
            foreach (var letter in alphabet)
            {
                foreach (var anotherLetter in alphabet)
                {
                    var bigramm = new Tuple<char, char>(letter, anotherLetter);
                    bigramms.Add(bigramm);
                }
            }
            return bigramms;
        }
    }
}
