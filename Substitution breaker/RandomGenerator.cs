using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substitution_breaker
{
    public class RandomGenerator
    {
        static Random _rnd=new Random();
        public static int GetNumber(int lowerBound,int upperBound)
        {
            if (lowerBound >= upperBound)
            {
                throw new ArgumentException("oops...");
            }
            return _rnd.Next(lowerBound, upperBound);
        }
    }
}
