﻿using System;
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


         
      




            var breaker = new Breaker(100,0.9,1,Language.English);
            var timer=new Stopwatch();
            timer.Start();
            var solutions = breaker.Decrypt
                (_text);
            timer.Stop();
            Console.WriteLine(timer.Elapsed);
            foreach (var solution in solutions)
            {
                Console.WriteLine("[FITNESS:"+solution.Key.Fitness+"] "+solution.Value);
                Console.WriteLine();
                Console.WriteLine("Хотите задать другие отображения? (Y/N)");
                var temp = Console.ReadLine();
                
                if(temp.Length>0 && temp.Length<2 && char.ToLower(temp[0])=='y')
                {
                    var changer = new ConsoleSolutionChanger(solution.Value);
                    changer.Start();
                }
                Console.Clear();
            }
            


        }
        static string _text1= "zphqaqpavqzmjmhmykzhmiqpsnpbhsimapprhmyzhmiqpsnpbhszlvqmyiuvppihszlvqmyiuvppimyizgkymyiupyqmhkyindmnzoqmgmyindqumlgkzznrpytjpsvpmizkfnqqynpymyiodmnipjpstqnmypndqrimjpviqrmyiiqqaqrkziqunpdurpndqripynjpslmvvhqlmszqklmyntpkpoqhjzpsvnpmlphamyjznprqkomzuprypyqhprykytodqyndqzsyikiynzdkyqkaklgqisahjzdpeqvmyikomvgqinpndqhkyqkvpmiqizkfnqqynpypbyshuqrykyqlpmvmyindqznrpytupzzzmkioqvvuvqzzmhmzpsvjpsvpmizkfnqqynpymyiodmnipjpstqnmypndqrimjpviqrmyiiqqaqrkziqunpdurpndqripynjpslmvvhqlmszqklmyntpkpoqhjzpsvnpmlphamyjznprqoqvvkbjpszqqhqmlphkyuqnnqrznqamzkiqmvpnpbhqyikiynmvpnpbhqyikqipyqbkznkzkrpyndqpndqrpbznqqvkbndqrktdnpyqipyntqnjpsndqyndqvqbnpyqokvvpdurpndqripynjpslmvvhqlmszqklmyntpkpoqhjzpsvnpmlphamyjznprq";
        static string _text = "pehjdziavahrazketakefakgayacaypzjpkefakgayjlvjprqyajllpsaalkgjkqilerqdptarksyqadzqujdktalqacakgqruehlztakgaadzqkleemrjrkgehfgpehjyalakkqdejdzqsqkryajlvallqzedkvjdkkemdevzedkrnajmqmdevxhrkvgjkpehyarjpqdfrenlajrarkenaonljqdqdfzedkkalliaujhraqkghykrzedkrnajmqmdevvgjkpehyakgqdmqdfqzedkdaazpehyyajredrzedkkalliaujhraqkghykrehyiaieyqarkgapujdtaqdcqkqdfthkreiajyajlkefakgayiqfglpsyqfgkadqdfjrvazqatekgphehjdzqvqkggajzqdipgjdzrqrqkjdzuypzedkrnajmqmdevxhrkvgjkpehyarjpqdfrenlajrarkenaonljqdqdfzedkkalliaujhraqkghykrzedkrnajmqmdevvgjkpehyakgqdmqdfqzedkdaazpehyyajredrzedkkalliaujhraqkghykrqkrjlladzqdfqfekkjrkennyakadzqdfvgevajyapehjdziaqujdraahrzpqdfjyavazedkrnajmqmdevxhrkvgjkpehyarjpqdfrenlajrarkenaonljqdqdfzedkkalliaujhraqkghykrzedkrnajmqmdevvgjkpehyakgqdmqdfqzedkdaazpehyyajredrzedkkalliaujhraqkghykrzedkkalliaujhraqkghykrqmdevvgjkpehjyarjpqdfrenlajrarkenaonljqdqdfzedkrnajmzedkrnajmzedkrnajmdeqmdevvgjkpehyakgqdmqdfjdzqzedkdaazpehyyajredrqmdevpehfeezqmdevpehfeezqmdevpehyajlfeezeg";
    }
}
