using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substitution_breaker
{
    public enum Language { Russian,English}
    public class DistributionData
    {

        public Dictionary<char,double> LettersDistribution { get; set; }
        public Dictionary<char, double> LettersDistributionSample { get; set; }

        public Dictionary<Tuple<char,char>, double> BigrammMatrix { get; set; }
        public Dictionary<Tuple<char, char>, double> BigrammMatrixSample { get; set; }


        public KeyValuePair<Tuple<char, char>, double>[] BigrammArray { get; set; }
        public KeyValuePair<Tuple<char, char>, double>[] BigrammArraySample { get; set; }

        public char[] Alphabet { get;  }

        public DistributionData(Language language, Dictionary<char, double> onegramms, Dictionary<Tuple<char, char>, double> bigramms)
        {
            Alphabet=AlphabetHelper.GetAlphabet(language);
            var sampleSerializator = new SampleSerializator(language);
            LettersDistributionSample = sampleSerializator.GetOnegramms();
            BigrammMatrixSample = sampleSerializator.GetBigramms();
            LettersDistribution = onegramms;
            BigrammMatrix = bigramms;
            BigrammArray = BigrammMatrix.ToArray();
            BigrammArraySample = BigrammMatrixSample.ToArray();
        }




       
    }
}
