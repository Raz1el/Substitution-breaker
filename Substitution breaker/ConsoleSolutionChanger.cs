using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substitution_breaker
{
    public class ConsoleSolutionChanger
    {
        private Changer _changer;
        public ConsoleSolutionChanger(string text)
        {
            _changer = new Changer (text);
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("Какие буквы и как будем изменять?(вводить через пробел в виде буква1>буква2");
                var instructions = Console.ReadLine();
                var parsedInstructions = ParseInstructions(instructions);
                foreach (var instruction in parsedInstructions)
                {
                    _changer.Swap(instruction.Key, instruction.Value);
                }
                var newSolution = _changer.GetSolution();
                Console.WriteLine();
                Console.WriteLine("NEW SOLUTION");
                Console.WriteLine(newSolution);
                Console.WriteLine();
                Console.WriteLine("Y, чтобы задать новые инструкции, либо что-угодно, чтобы выйти");
                var isExit = Console.ReadLine();
                if(isExit.Length==1 && char.ToLower(isExit[0]) == 'y') { continue; }
                break;
            }
        }

        private KeyValuePair<char,char>[] ParseInstructions(string instructions)
        {
            var splitted = instructions.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var parsed = new KeyValuePair<char, char>[splitted.Length];
            for (int i = 0; i < splitted.Length; i++)
            {
                parsed[i] = new KeyValuePair<char, char>(splitted[i][0], splitted[i][2]);
            }
            return parsed;
        }
    }
}
