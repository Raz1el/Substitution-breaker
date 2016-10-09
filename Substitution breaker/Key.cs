using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Substitution_breaker.Genetic_algorithm;

namespace Substitution_breaker
{
    public class Key:ISolution<Key>
    {
        const int RandomSwapCount = 10;
        public DistributionData StatisticalInformation { get; set; }
        public Dictionary<char,char> Substitution { get; set; }
        public double Fitness { get { return FitnessFunction(); } }

        public Key(Dictionary<char,char> substitution,DistributionData statisticalInfo)
        {
            Substitution = substitution;
            StatisticalInformation = statisticalInfo;
       
        }

        public double FitnessFunction()
        {
            var result = 0.0;
            var temp = StatisticalInformation.BigramMatrixSample.ToArray();
            for (int i = 0; i < StatisticalInformation.BigramMatrix.Count; i++)
            {
                var cipherPair = temp[i].Key;
                var cleanPair = new Tuple<char, char>(Substitution[cipherPair.Item1], Substitution[cipherPair.Item2]);
                result += Math.Abs(StatisticalInformation.BigramMatrix[cipherPair] - StatisticalInformation.BigramMatrixSample[cleanPair]);
            }
            return result;
        }



        public string Decrypt(string text)
        {
            var stringBuilder=new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                stringBuilder.Append(Substitution[text[i]]);
            }
            return stringBuilder.ToString();
        }

        public ISolution<Key> Evolve()
        {
            var newSubstitution = new Dictionary<char, char>(Substitution);
            for (int i = 1; i < Substitution.Count - 1; i++)
            {
                for (int j = 0; j < Substitution.Count - i; j++)
                {
                    Swap(j, j + i, newSubstitution);
                    var newKey = new Key(newSubstitution, StatisticalInformation);
                    if (newKey.Fitness < Fitness)
                        return newKey;
                    else
                    {
                        Swap(j, i + j, newSubstitution);
                    }
                }
            }
            return this;
        }

        public ISolution<Key> Mutate()
        {

            var newSubstitution = new Dictionary<char, char>(Substitution);
            for (int i = 0; i < RandomSwapCount; i++)
            {
                var firstIndex = RandomGenerator.GetNumber(0, StatisticalInformation.LettersDistribution.Count - 1);
                var secondIndex = RandomGenerator.GetNumber(0, StatisticalInformation.LettersDistribution.Count - 1);
                while (secondIndex == firstIndex)
                {
                    secondIndex = RandomGenerator.GetNumber(0, StatisticalInformation.LettersDistribution.Count - 1);
                }
                var firstPair = newSubstitution.ElementAt(firstIndex);
                var secondPair = newSubstitution.ElementAt(secondIndex);
                newSubstitution[firstPair.Key] = secondPair.Value;
                newSubstitution[secondPair.Key] = firstPair.Value;
            }
            return new Key(newSubstitution, StatisticalInformation);
        }
        void Swap(int firstIndex,int secondIndex,Dictionary<char,char> substitution)
        {
            var firstPair = substitution.ElementAt(firstIndex);
            var secondPair = substitution.ElementAt(secondIndex);
            substitution[firstPair.Key] = secondPair.Value;
            substitution[secondPair.Key] = firstPair.Value;

        }

        public Key GetSolution()
        {
            return this;
        }

        public override bool Equals(object obj)
        {
            var key = (Key)obj;

            return ToString() == key.ToString();
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }


        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            foreach (var letter in StatisticalInformation.LettersDistribution.Keys)
            {
                stringBuilder.Append(Substitution[letter]);
            }
            return stringBuilder.ToString();
        }

    
    }
}
