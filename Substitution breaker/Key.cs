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

        public Key(Dictionary<char,char> substitution,DistributionData statisticalInfo):this(substitution,statisticalInfo,-1)
        {

        }
        Key(Dictionary<char, char> substitution, DistributionData statisticalInfo,double fitness)
        {
            Substitution = substitution;
            StatisticalInformation = statisticalInfo;
            _fitness = fitness;
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


            var firstCharImage = Substitution[firstChar];
            var secondCharImage = Substitution[secondChar];


          

            var pair1 = new Tuple<char, char>(firstChar, firstChar);
            var oldPair1 = new Tuple<char, char>(firstCharImage, firstCharImage);
            var newPair1 = new Tuple<char, char>(secondCharImage, secondCharImage);

            var pair2 = new Tuple<char, char>(secondChar, secondChar);
            var oldPair2 = new Tuple<char, char>(secondCharImage, secondCharImage);
            var newPair2 = new Tuple<char, char>(firstCharImage, firstCharImage);


            var pair1Value = StatisticalInformation.BigrammMatrix[pair1];
            var pair2Value = StatisticalInformation.BigrammMatrix[pair2];
            var oldPair1ValueSample = StatisticalInformation.BigrammMatrixSample[oldPair1];
            var oldPair2ValueSample = StatisticalInformation.BigrammMatrixSample[oldPair2];
            var newPair1ValueSample = StatisticalInformation.BigrammMatrixSample[newPair1];
            var newPair2ValueSample = StatisticalInformation.BigrammMatrixSample[newPair2];

            result += Math.Abs(pair1Value - newPair1ValueSample);
            result -= Math.Abs(pair1Value - oldPair1ValueSample);
            result += Math.Abs(pair2Value - newPair2ValueSample);
            result -= Math.Abs(pair2Value - oldPair2ValueSample);




            pair1 = new Tuple<char, char>(firstChar, secondChar);
            oldPair1 = new Tuple<char, char>(firstCharImage, secondCharImage);
            newPair1 = new Tuple<char, char>(secondCharImage, firstCharImage);

            pair2 = new Tuple<char, char>(secondChar, firstChar);
            oldPair2 = new Tuple<char, char>(secondCharImage, firstCharImage);
            newPair2 = new Tuple<char, char>(firstCharImage, secondCharImage);




            pair1Value = StatisticalInformation.BigrammMatrix[pair1];
            pair2Value = StatisticalInformation.BigrammMatrix[pair2];
            oldPair1ValueSample = StatisticalInformation.BigrammMatrixSample[oldPair1];
            oldPair2ValueSample = StatisticalInformation.BigrammMatrixSample[oldPair2];
            newPair1ValueSample = StatisticalInformation.BigrammMatrixSample[newPair1];
            newPair2ValueSample = StatisticalInformation.BigrammMatrixSample[newPair2];

            result += Math.Abs(pair1Value - newPair1ValueSample);
            result -= Math.Abs(pair1Value - oldPair1ValueSample);
            result += Math.Abs(pair2Value - newPair2ValueSample);
            result -= Math.Abs(pair2Value - oldPair2ValueSample);

            char currentChar,currentCharImage;



            for (int i = 0; i < StatisticalInformation.Alphabet.Length; i++)
            {

                currentChar = StatisticalInformation.Alphabet[i];
                currentCharImage = Substitution[StatisticalInformation.Alphabet[i]];

                if (currentChar == firstChar|| currentChar==secondChar)
                {
                    continue;
                }


                pair1 = new Tuple<char, char>(firstChar, currentChar);
                oldPair1 = new Tuple<char, char>(firstCharImage, currentCharImage);
                newPair1 = new Tuple<char, char>(secondCharImage, currentCharImage);

                pair2 = new Tuple<char, char>(secondChar, currentChar);
                oldPair2 = new Tuple<char, char>(secondCharImage, currentCharImage);
                newPair2 = new Tuple<char, char>(firstCharImage, currentCharImage);


                pair1Value = StatisticalInformation.BigrammMatrix[pair1];
                pair2Value = StatisticalInformation.BigrammMatrix[pair2];
                oldPair1ValueSample = StatisticalInformation.BigrammMatrixSample[oldPair1];
                oldPair2ValueSample = StatisticalInformation.BigrammMatrixSample[oldPair2];
                newPair1ValueSample = StatisticalInformation.BigrammMatrixSample[newPair1];
                newPair2ValueSample = StatisticalInformation.BigrammMatrixSample[newPair2];


                result += Math.Abs(pair1Value - newPair1ValueSample);
                result -= Math.Abs(pair1Value - oldPair1ValueSample);
                result += Math.Abs(pair2Value - newPair2ValueSample);
                result -= Math.Abs(pair2Value - oldPair2ValueSample);






                pair1 = new Tuple<char, char>(currentChar, firstChar);
                oldPair1 = new Tuple<char, char>(currentCharImage, firstCharImage);
                newPair1 = new Tuple<char, char>(currentCharImage, secondCharImage);

                pair2 = new Tuple<char, char>(currentChar, secondChar);
                oldPair2 = new Tuple<char, char>(currentCharImage, secondCharImage);
                newPair2 = new Tuple<char, char>(currentCharImage, firstCharImage);


                pair1Value = StatisticalInformation.BigrammMatrix[pair1];
                pair2Value = StatisticalInformation.BigrammMatrix[pair2];
                oldPair1ValueSample = StatisticalInformation.BigrammMatrixSample[oldPair1];
                oldPair2ValueSample = StatisticalInformation.BigrammMatrixSample[oldPair2];
                newPair1ValueSample = StatisticalInformation.BigrammMatrixSample[newPair1];
                newPair2ValueSample = StatisticalInformation.BigrammMatrixSample[newPair2];


                result += Math.Abs(pair1Value - newPair1ValueSample);
                result -= Math.Abs(pair1Value - oldPair1ValueSample);
                result += Math.Abs(pair2Value - newPair2ValueSample);
                result -= Math.Abs(pair2Value - oldPair2ValueSample);

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
                        return new Key(Substitution, StatisticalInformation,fitness);
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
