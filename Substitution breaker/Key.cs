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

        private double _fitness;

        public double Fitness
        {
            get
            {
                if (_fitness < 0)
                    _fitness = FitnessFunction();
                return _fitness;
            }
        }

        public Key(Dictionary<char,char> substitution,DistributionData statisticalInfo)
        {
            Substitution = substitution;
            StatisticalInformation = statisticalInfo;
            _fitness = -1;

        }

        public double FitnessFunction()
        {
            var result = 0.0;
            for (int i = 0; i < StatisticalInformation.BigrammMatrix.Count; i++)
            {
                var cipherPair = StatisticalInformation.BigrammArray[i].Key;
                var cleanPair = new Tuple<char, char>(Substitution[cipherPair.Item1], Substitution[cipherPair.Item2]);
                result += Math.Abs(StatisticalInformation.BigrammMatrix[cipherPair] - StatisticalInformation.BigrammMatrixSample[cleanPair]);
            }
            return result;
        }

        double FastFitnessFunction(char firstChar,char secondChar)
        {
            var result = Fitness;


            var pair1 = new Tuple<char, char>(firstChar, firstChar);
            var oldPair1 = new Tuple<char, char>(Substitution[firstChar], Substitution[firstChar]);
            var newPair1 = new Tuple<char, char>(Substitution[secondChar], Substitution[secondChar]);

            var pair2 = new Tuple<char, char>(secondChar, secondChar);
            var oldPair2 = new Tuple<char, char>(Substitution[secondChar], Substitution[secondChar]);
            var newPair2 = new Tuple<char, char>(Substitution[firstChar], Substitution[firstChar]);

            result += Math.Abs(StatisticalInformation.BigrammMatrix[pair1] - StatisticalInformation.BigrammMatrixSample[newPair1]);
            result -= Math.Abs(StatisticalInformation.BigrammMatrix[pair1] - StatisticalInformation.BigrammMatrixSample[oldPair1]);

            result += Math.Abs(StatisticalInformation.BigrammMatrix[pair2] - StatisticalInformation.BigrammMatrixSample[newPair2]);
            result -= Math.Abs(StatisticalInformation.BigrammMatrix[pair2] - StatisticalInformation.BigrammMatrixSample[oldPair2]);




            pair1 = new Tuple<char, char>(firstChar, secondChar);
            oldPair1 = new Tuple<char, char>(Substitution[firstChar], Substitution[secondChar]);
            newPair1 = new Tuple<char, char>(Substitution[secondChar], Substitution[firstChar]);

            pair2 = new Tuple<char, char>(secondChar, firstChar);
            oldPair2 = new Tuple<char, char>(Substitution[secondChar], Substitution[firstChar]);
            newPair2 = new Tuple<char, char>(Substitution[firstChar], Substitution[secondChar]);

            result += Math.Abs(StatisticalInformation.BigrammMatrix[pair1] - StatisticalInformation.BigrammMatrixSample[newPair1]);
            result -= Math.Abs(StatisticalInformation.BigrammMatrix[pair1] - StatisticalInformation.BigrammMatrixSample[oldPair1]);

            result += Math.Abs(StatisticalInformation.BigrammMatrix[pair2] - StatisticalInformation.BigrammMatrixSample[newPair2]);
            result -= Math.Abs(StatisticalInformation.BigrammMatrix[pair2] - StatisticalInformation.BigrammMatrixSample[oldPair2]);


            for (int i = 0; i < StatisticalInformation.Alphabet.Length; i++)
            {
                if (StatisticalInformation.Alphabet[i] == firstChar|| StatisticalInformation.Alphabet[i]==secondChar)
                {
                    continue;
                }

                pair1 = new Tuple<char, char>(firstChar, StatisticalInformation.Alphabet[i]);
                oldPair1 = new Tuple<char, char>(Substitution[firstChar],Substitution[StatisticalInformation.Alphabet[i]]);
                newPair1 = new Tuple<char, char>(Substitution[secondChar], Substitution[StatisticalInformation.Alphabet[i]]);

                pair2 = new Tuple<char, char>(secondChar, StatisticalInformation.Alphabet[i]);
                oldPair2 = new Tuple<char, char>(Substitution[secondChar],Substitution[StatisticalInformation.Alphabet[i]]);
                newPair2 = new Tuple<char, char>(Substitution[firstChar], Substitution[StatisticalInformation.Alphabet[i]]);

                result +=Math.Abs(StatisticalInformation.BigrammMatrix[pair1] -StatisticalInformation.BigrammMatrixSample[newPair1]);
                result -= Math.Abs(StatisticalInformation.BigrammMatrix[pair1] -StatisticalInformation.BigrammMatrixSample[oldPair1]);

                result +=Math.Abs(StatisticalInformation.BigrammMatrix[pair2] -StatisticalInformation.BigrammMatrixSample[newPair2]);
                result -=Math.Abs(StatisticalInformation.BigrammMatrix[pair2] -StatisticalInformation.BigrammMatrixSample[oldPair2]);






                pair1 = new Tuple<char, char>( StatisticalInformation.Alphabet[i], firstChar);
                oldPair1 = new Tuple<char, char>(Substitution[StatisticalInformation.Alphabet[i]], Substitution[firstChar]);
                newPair1 = new Tuple<char, char>(Substitution[StatisticalInformation.Alphabet[i]], Substitution[secondChar]);

                pair2 = new Tuple<char, char>( StatisticalInformation.Alphabet[i], secondChar);
                oldPair2 = new Tuple<char, char>( Substitution[StatisticalInformation.Alphabet[i]], Substitution[secondChar]);
                newPair2 = new Tuple<char, char>( Substitution[StatisticalInformation.Alphabet[i]], Substitution[firstChar]);

                result += Math.Abs(StatisticalInformation.BigrammMatrix[pair1] - StatisticalInformation.BigrammMatrixSample[newPair1]);
                result -= Math.Abs(StatisticalInformation.BigrammMatrix[pair1] - StatisticalInformation.BigrammMatrixSample[oldPair1]);

                result += Math.Abs(StatisticalInformation.BigrammMatrix[pair2] - StatisticalInformation.BigrammMatrixSample[newPair2]);
                result -= Math.Abs(StatisticalInformation.BigrammMatrix[pair2] - StatisticalInformation.BigrammMatrixSample[oldPair2]);

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
            for (int i = 1; i < Substitution.Count - 1; i++)
            {
                for (int j = 0; j < Substitution.Count - i; j++)
                {
                    var fitness = FastFitnessFunction(StatisticalInformation.Alphabet[j],
                        StatisticalInformation.Alphabet[j + i]);
                    if (fitness < Fitness)
                    {
                        Swap(j, j + i, Substitution);
                        return new Key(Substitution, StatisticalInformation);
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
                Swap(firstIndex,secondIndex,newSubstitution);
            }
            return new Key(newSubstitution, StatisticalInformation);
        }
        void Swap(int firstIndex,int secondIndex,Dictionary<char,char> substitution)
        {
            var tmp = substitution[StatisticalInformation.Alphabet[firstIndex]];
            substitution[StatisticalInformation.Alphabet[firstIndex]]= substitution[StatisticalInformation.Alphabet[secondIndex]];
            substitution[StatisticalInformation.Alphabet[secondIndex]] = tmp;

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
            for (int i = 0; i < StatisticalInformation.Alphabet.Length; i++)
            {
                stringBuilder.Append(Substitution[StatisticalInformation.Alphabet[i]]);
            }
            return stringBuilder.ToString();
        }

    
    }
}
