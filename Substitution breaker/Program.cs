using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Substitution_breaker
{
    class Program
    {
        
        static void Main(string[] args)
        {
         //var gramms1 = SampleSerializator.GetOnegramms();
         //  var gramms2 = SampleSerializator.GetBigramms();


         
      




            var breaker = new Breaker(1500);
            var solutions = breaker.Decrypt
                (_text);
            foreach (var solution in solutions)
            {
                Console.WriteLine("[FITNESS:"+solution.Key.Fitness+"] "+solution.Value);
                Console.ReadKey();
                Console.Clear();
            }

        }
        static string _text= "pehjdziavahrazketakefakgayacaypzjpkefakgayjlvjprqyajllpsaalkgjkqilerqdptarksyqadzqujdktalqacakgqruehlztakgaadzqkleemrjrkgehfgpehjyalakkqdejdzqsqkryajlvallqzedkvjdkkemdevzedkrnajmqmdevxhrkvgjkpehyarjpqdfrenlajrarkenaonljqdqdfzedkkalliaujhraqkghykrzedkrnajmqmdevvgjkpehyakgqdmqdfqzedkdaazpehyyajredrzedkkalliaujhraqkghykrehyiaieyqarkgapujdtaqdcqkqdfthkreiajyajlkefakgayiqfglpsyqfgkadqdfjrvazqatekgphehjdzqvqkggajzqdipgjdzrqrqkjdzuypzedkrnajmqmdevxhrkvgjkpehyarjpqdfrenlajrarkenaonljqdqdfzedkkalliaujhraqkghykrzedkrnajmqmdevvgjkpehyakgqdmqdfqzedkdaazpehyyajredrzedkkalliaujhraqkghykrqkrjlladzqdfqfekkjrkennyakadzqdfvgevajyapehjdziaqujdraahrzpqdfjyavazedkrnajmqmdevxhrkvgjkpehyarjpqdfrenlajrarkenaonljqdqdfzedkkalliaujhraqkghykrzedkrnajmqmdevvgjkpehyakgqdmqdfqzedkdaazpehyyajredrzedkkalliaujhraqkghykrzedkkalliaujhraqkghykrqmdevvgjkpehjyarjpqdfrenlajrarkenaonljqdqdfzedkrnajmzedkrnajmzedkrnajmdeqmdevvgjkpehyakgqdmqdfjdzqzedkdaazpehyyajredrqmdevpehfeezqmdevpehfeezqmdevpehyajlfeezeg";
    }
}
