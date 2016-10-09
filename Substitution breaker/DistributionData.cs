using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substitution_breaker
{
    public class DistributionData
    {

        public Dictionary<char,double> LettersDistribution { get; set; }
        public Dictionary<char, double> LettersDistributionSample { get; set; }

        public Dictionary<Tuple<char,char>, double> BigramMatrix { get; set; }
        public Dictionary<Tuple<char, char>, double> BigramMatrixSample { get; set; }

        public DistributionData()
        {
            LettersDistributionSample = SampleSerializator.GetOnegramms();
            BigramMatrixSample = SampleSerializator.GetBigramms();

            
          
        }

       
    }
}
