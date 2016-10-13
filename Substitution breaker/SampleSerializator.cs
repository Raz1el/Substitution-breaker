using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Substitution_breaker
{
    public class SampleSerializator
    {
        private static string _path = string.Format("{0}\\samples\\",GetCurrentDirectory());
        private static string _defaultOneframmsFileNameEnding = "Onegramms.txt";
        private static string _defaultBigrammsFileNameEnding = "Bigramms.txt";

        private string _onegrammsFileName;
        private string _bigrammsFileName;

        public Language Language { get; }

        public SampleSerializator(Language language)
        {
            Language = language;
            _onegrammsFileName = language.ToString() + _defaultOneframmsFileNameEnding;
            _bigrammsFileName = language.ToString() + _defaultBigrammsFileNameEnding;
        }

        public Dictionary<char,double> GetOnegramms()
        {
            var stream = new StreamReader(_path + _onegrammsFileName);
            var distribution = new Dictionary<char, double>();
            using (stream)
            {
                do
                {
                    var line = stream.ReadLine();
                    var onegramm = ParseOnegramm(line);
                    distribution.Add(onegramm.Key, onegramm.Value);
                } while (!stream.EndOfStream);
            }
            return distribution;
        }

        public Dictionary<Tuple<char,char>,double> GetBigramms()
        {
            var stream = new StreamReader(_path + _bigrammsFileName);
            var distribution = new Dictionary<Tuple<char, char>, double>();
            using (stream)
            {
                do
                {
                    var line = stream.ReadLine();
                    var bigramm = ParseBigramm(line);
                    distribution.Add(bigramm.Key, bigramm.Value);
                } while (!stream.EndOfStream);
            }
            return distribution;
        }

        public void SetOnegramms(Dictionary<char, double> distribution)
        {
            var stream = new StreamWriter(_path + _onegrammsFileName);
            using (stream)
            {
                foreach (var item in distribution)
                {
                    var line = item.Key + " " + item.Value;
                    stream.WriteLine(line);
                }
            }
        }

        public void SetBigramms(Dictionary<Tuple<char, char>, double> distribution)
        {
            var stream = new StreamWriter(_path + _bigrammsFileName);
            using (stream)
            {
                foreach (var item in distribution)
                {
                    var line = item.Key.Item1.ToString()+item.Key.Item2.ToString() + " " + item.Value;
                    stream.WriteLine(line);
                }
            }
        }

        private static KeyValuePair<char,double> ParseOnegramm(string text)
        {
            var splitted = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return new KeyValuePair<char, double>(splitted[0][0], double.Parse(splitted[1]));
        }

        private static KeyValuePair<Tuple<char,char>,double> ParseBigramm(string text)
        {
            var splitted = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return new KeyValuePair<Tuple<char, char>, double>(Tuple.Create(splitted[0][0], splitted[0][1]), double.Parse(splitted[1]));
        }

        private static string GetCurrentDirectory()
        {
            var directory = Environment.CurrentDirectory;
            if (directory.EndsWith("Release"))
            {
                directory = directory.Remove(directory.Length - 12);
            }
            else
            {
                directory = directory.Remove(directory.Length - 10);
            }

            return directory;
        }

    }
}
