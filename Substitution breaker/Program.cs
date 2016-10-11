using System;
using System.Collections.Generic;
using System.Diagnostics;
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





            string line;
            using (StreamReader reader=new StreamReader("text.txt"))
            {
                line = reader.ReadToEnd().ToLower();
            }

            var breaker = new Breaker(100,Language.English);
            var timer=new Stopwatch();
            timer.Start();
            var solution = breaker.FindKey
                (line);
            timer.Stop();
            Console.WriteLine(timer.Elapsed);

            Console.WriteLine("[FITNESS:" + solution.Item1.Fitness + "] " + solution.Item2);
            Console.WriteLine();
            Console.WriteLine("Хотите задать другие отображения? (Y/N)");
            var temp = Console.ReadLine();

            if (temp.Length > 0 && temp.Length < 2 && char.ToLower(temp[0]) == 'y')
            {
                var changer = new ConsoleSolutionChanger(solution.Item2);
                changer.Start();
            }
            Console.Clear();
            
            


        }
        static string _text1= "zphqaqpavqzmjmhmykzhmiqpsnpbhsimapprhmyzhmiqpsnpbhszlvqmyiuvppihszlvqmyiuvppimyizgkymyiupyqmhkyindmnzoqmgmyindqumlgkzznrpytjpsvpmizkfnqqynpymyiodmnipjpstqnmypndqrimjpviqrmyiiqqaqrkziqunpdurpndqripynjpslmvvhqlmszqklmyntpkpoqhjzpsvnpmlphamyjznprqkomzuprypyqhprykytodqyndqzsyikiynzdkyqkaklgqisahjzdpeqvmyikomvgqinpndqhkyqkvpmiqizkfnqqynpypbyshuqrykyqlpmvmyindqznrpytupzzzmkioqvvuvqzzmhmzpsvjpsvpmizkfnqqynpymyiodmnipjpstqnmypndqrimjpviqrmyiiqqaqrkziqunpdurpndqripynjpslmvvhqlmszqklmyntpkpoqhjzpsvnpmlphamyjznprqoqvvkbjpszqqhqmlphkyuqnnqrznqamzkiqmvpnpbhqyikiynmvpnpbhqyikqipyqbkznkzkrpyndqpndqrpbznqqvkbndqrktdnpyqipyntqnjpsndqyndqvqbnpyqokvvpdurpndqripynjpslmvvhqlmszqklmyntpkpoqhjzpsvnpmlphamyjznprq";
        static string _text = "pehjdziavahrazketakefakgayacaypzjpkefakgayjlvjprqyajllpsaalkgjkqilerqdptarksyqadzqujdktalqacakgqruehlztakgaadzqkleemrjrkgehfgpehjyalakkqdejdzqsqkryajlvallqzedkvjdkkemdevzedkrnajmqmdevxhrkvgjkpehyarjpqdfrenlajrarkenaonljqdqdfzedkkalliaujhraqkghykrzedkrnajmqmdevvgjkpehyakgqdmqdfqzedkdaazpehyyajredrzedkkalliaujhraqkghykrehyiaieyqarkgapujdtaqdcqkqdfthkreiajyajlkefakgayiqfglpsyqfgkadqdfjrvazqatekgphehjdzqvqkggajzqdipgjdzrqrqkjdzuypzedkrnajmqmdevxhrkvgjkpehyarjpqdfrenlajrarkenaonljqdqdfzedkkalliaujhraqkghykrzedkrnajmqmdevvgjkpehyakgqdmqdfqzedkdaazpehyyajredrzedkkalliaujhraqkghykrqkrjlladzqdfqfekkjrkennyakadzqdfvgevajyapehjdziaqujdraahrzpqdfjyavazedkrnajmqmdevxhrkvgjkpehyarjpqdfrenlajrarkenaonljqdqdfzedkkalliaujhraqkghykrzedkrnajmqmdevvgjkpehyakgqdmqdfqzedkdaazpehyyajredrzedkkalliaujhraqkghykrzedkkalliaujhraqkghykrqmdevvgjkpehjyarjpqdfrenlajrarkenaonljqdqdfzedkrnajmzedkrnajmzedkrnajmdeqmdevvgjkpehyakgqdmqdfjdzqzedkdaazpehyyajredrqmdevpehfeezqmdevpehfeezqmdevpehyajlfeezeg";
    }
}
