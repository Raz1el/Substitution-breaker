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
            var line1 = @"Ò❮ÐÚ❰Ø➪❰➚➮ÐßÝÙ❰Ð➷ÖÐ➬❐➪❰Ð➪❰ß❮➘❒Þ❐➮➚ß➚❐➪ÖÝ❰ß➚❮➶➚Ï➚ÖÐÞÒ❮ÐØÞ➴ß❰Þ❰➘Ü❮Ð❰➱Þ➴➚Ô➚ÔÚÜÞ❐➮➚ß➹➮➪➶Þ➱➮Ú➚➶Þ➱➮➚❰Û➮➪➮ÐØÞßÐßÙ❐➪❰ÔÞÖØ➪ÙÛ➚ßÐßÜ➪Ù➶❮➚Ú❰➮ÞÞ❰Ø➘➷Ð➪❰ÝÙ❰ÐÔÞ➪❰➪ÔÞÐ➶❮Þ➷Þ❒➚➪ØÝ➱ÐÚ❰Ù➱Ý❰➮Þ❐➪❮➮Þ❰ÞÔÛßÞ❐Ï➪❮ÐÞ❐ØÞ❐➪ÔÐÐ➮➮ÐÐ➷➱Ð❰Þ❐Ð➹➶ÛÚÖÐ❮ÐÖÞ❮➪➮➮➘➴ØÞ➱ÖÐÖÔÝÚ❒➚Ö➮Û➱ÞÚÖÐÞØ➚➮ÞÏ➪Ù❰❐Þ❐Ø❐Þ➪➱➚ÖÐ❰➪Ü➹➹➶ÛÚÖÐÔÞ❒Û➱➪➮➹➶❮➪ØÐ❐✃➚➷ÒÝÜÖÐ➱➪❮❰❐➘➴➷ÞÔÞØÒÔÐÖÖÐ❰ÞÏ❰Þ➱➚❮❒➪Ù❰Þß➚Ò❮ÝÜÖÐ❰ÞÏ❰ÞÜÞÒ➮➪Ù➶ÐÙÐ➮➮ÐÐ➷➱Ð❰Þ❐ÐßÞÒØÐ➹➮ÞÏÛÚ❒ØÝ➪➪➶❮➚➷ÞØÐ❒➚Ö➮ÛßÐ❒➪❰Ù➹❐➚Ù➚❰➮Ð❐ÞÔÞÙß➪Ï❰Þ➶ÞÏ➪Ù❰➚Ï❰ÞÚ➮ÞÙ❰ÛÏ❰ÞÙ❐ÞÜÞØÐ➶❮➪Ø➱➚ÔÞ➴ÒÞÙ❰Û➪➴ÙØÝØÞÏßÞ➴❐❮Ýß➪➚❐Þ❰❐Þ✃ÔÐÞ❰ß➚➮Ý❐➶Þß❮➘❐ÐÔÞ❐➮➚➱Ð❰➪ÔÛ➮Þ❐ÖÒÔ➹➮ÝÔÐ➮Ð➱➪➮➹➪➴ÒÞ❐Þ❮Ú❰➘ÔÛØÐ➮❰ÝØ➚ß❰Þ❐ÐÔÐÙ❰❮Ð➮➚➬➘ÐØÐÞ❰❐➪ÏÐ➪❰➹Ð➮➮ÐÐ➷➱Ð❰Þ❐Ð➱ÝÖÐ";
            var sss = line1.Select(n => (Char) (n + 848));
            var sample374 = "ЯРЯЩЮФЮЙАИЯЮЕВЫБКЫЙЮЪШЭКЭЦИРЪЛЯЭЩББТЮНБЯАЖЙБФБИИЮГВДОЯЭЙЮФЫЬЮЕИБИРНЭКЭЮВЮЯЮЕЙЮЕЙИЮТЮИБШБФБИЯЮТШРЯЮИПАКЫЩЯРМАИБВБПРФЫИЮПОЮШЭКАЙЮБЕИБОИРЩЛБОБГВЮЕШЭШЮНЮТЮЕИБШРФЫИБЕВЮЩЙЮОНБОЫЯРЯАТНРЪОШБОАИРЯЭЩОРЖЦРЗЛБОРБОЯНДМЮЛИАЯАЛБЦЭОЯАНВАПАЦРЮТНРШЮЕЯОЮОДЬНРОЙЮЕАФАФЪЬЮЛИАЯГИБВЮЙИЪАВЮЙИАОЫИБИРШЮЯРЯЩЛБОФЮЦШБЩЫАЯРЯЬБЩВНАЪОИЮЮОШДЖРБОЭЩОРФЮБОБФЮРВНЮЖЮМАБШЭЙРЪОЩЙЭОИЮЛБНИЮОЮФЫЯЮЛПБНРЮЛШЮЛБФРРИИРРЖЙРОЮЛРГВЫЪЦРНРЦЮНБИИДЕШЮЙЦРЦФЭЪМАЦИЫЙЮЪЦРЮШАИЮПБЩОЛЮЛШЛЮБЙАЦРОБЬГГВЫЪЦРФЮМЫЙБИГВНБШРЛКАЖТЭЬЦРЙБНОЛДЕЖЮФЮШТФРЦЦРОЮПОЮЙАНМБЩОЮЯАТНЭЬЦРОЮПОЮЬЮТИБЩВРЩРИИРРЖЙРОЮЛРЯЮТШРГИЮПЫЪМШЭББВНАЖЮШРМАЦИЫЯРМБОЩГЛАЩАОИРЛЮФЮЩЯБПОЮВЮПБЩОАПОЮЪИЮЩОЫПОЮЩЛЮЬЮШРВНБШЙАФЮЕТЮЩОЫБЕЩШЭШЮПЯЮЕЛНЭЯБАЛЮОЛЮКФРЮОЯАИЭЛВЮЯНДЛРФЮЛИАЙРОБФЫИЮЛЦТФГИЭФРИРЙБИГБЕТЮЛЮНЪОДФЫШРИОЭШАЯОЮЛРФРЩОНРИАЗДРШРЮОЛБПРБОГРИИРРЖЙРОЮЛРЙЭЦР";
            char t = (char)((int)'❐' + 848);
            foreach (var item in sss)
            {
                if (item == 10912)
                {
                    Console.Write('Л');
                    continue;
                }
                if (item == 11015)
                {
                    Console.Write('Ж');
                    continue;
                }
                if (item == 11006)
                {
                    Console.Write('И');
                    continue;
                }
                if (item == 10976)
                {
                    Console.Write('Ё');
                    continue;
                }
                if (item == 10986)
                {
                    Console.Write('А');
                    continue;
                }
                if (item == 10914)
                {
                    Console.Write('М');
                    continue;
                }
                if (item == 10944)
                {
                    Console.Write('О');
                    continue;
                }
                if (item == 10835)
                {
                    Console.Write('К');
                    continue;
                }
                if(item==11004) { Console.Write('З');
                    continue;
                }
                if (item == 11009)
                {
                    Console.Write('Й');
                    continue;
                }
                if (item == 11017)
                {
                    Console.Write('Г');
                    continue;
                }
                if (item == 11012)
                {
                    Console.Write('Е');
                    continue;
                }
                if (item == 11014)
                {
                    Console.Write('В');
                    continue;
                }
                if (item == 11002)
                {
                    Console.Write('Б');
                    continue;
                }
                if (item == 10942)
                {
                    Console.Write('Н');
                    continue;
                }
                if (item == 10984)
                {
                    Console.Write('Д');
                    continue;
                }
               
                Console.Write(item);
            }
            Console.ReadKey();
            string line = _rustext;
            //using (StreamReader reader=new StreamReader("text.txt"))
            //{
            //    line = reader.ReadToEnd().ToLower();
            //}

            var breaker = new Breaker(1000,Language.Russian);
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

        static string _rustext = "ЯРЯЩЮфЮйАИЯЮЕВЫБКЫЙЮЪШЭКЭЦИРЪЛЯЭЩББТЮНБЯАЖЙБФБИИЮГВДОЯЭЙЮФЫЬЮЕИБИРНЭКЭЮВЮЯЮЕЙЮЕЙИЮТЮИБШБФБИЯЮТШРЯЮИПАКЫЩЯРМАИБВБПРФЫИЮПОЮШЭКАЙЮБЕИБОИРЩЛБОБГВЮЕШЭШЮНЮТЮЕИБШРФЫИБЕВЮЩЙЮОНБОЫЯРЯАтнръошбоаиряэщоржцрзлборбОЯНДМЮЛИАЯАЛБЦЭОЯАНВАПАЦРЮТНРШЮЕЯОЮОДЬНРОЙЮЕАФАФЪЬЮЛИАЯГИБВЮЙИЪАВЮЙИАОЫИБИРШЮЯРЯЩЛБОФЮЦШБЩЫАЯРЯЬБЩВНАЪОИЮЮОШДЖРБОЭЩОРФЮБОБФЮРВНЮЖЮМАБШЭЙРЪОЩЙЭОИЮЛБНИЮОЮФЫЯЮЛПБНРЮЛШЮЛБФРРИИРРЖЙРОЮЛРГВЫЪЦРНРЦЮНБИИДЕШЮЙЦРЦФЭЪМАЦИЫЙЮЪЦРЮШАИЮПБЩОЛЮЛШЛЮБЙАЦРОБЬГГВЫЪЦРФЮМЫЙБИГВНБШРЛКАЖТЭЬЦРЙБНОЛДЕЖЮФЮШТФРЦЦРОЮПОЮЙАНМБЩОЮЯАТНЭЬЦРОЮПОЮЬЮТИБЩВРЩРИИРРЖЙРОЮЛРЯЮТШРГИЮПЫЪМШЭББВНАЖЮШРМАЦИЫЯРМБОЩГЛАЩАОИРЛЮФЮЩЯБПОЮВЮПБЩОАПОЮЪИЮЩОЫПОЮЩЛЮЬЮШРВНБШЙАФЮЕТЮЩОЫБЕЩШЭШЮПЯЮЕЛНЭЯБАЛЮОЛЮКФРЮОЯАИЭЛВЮЯНДЛРФЮЛИАЙРОБФЫИЮЛЦТФГИЭФРИРЙБИГБЕТЮЛЮНЪОДФЫШРИОЭШАЯОЮЛРФРЩОНРИАЗДРШРЮОЛБПРБОГРИИРРЖЙРОЮЛРЙЭЦР".ToLower();
        static string _text1= "zphqaqpavqzmjmhmykzhmiqpsnpbhsimapprhmyzhmiqpsnpbhszlvqmyiuvppihszlvqmyiuvppimyizgkymyiupyqmhkyindmnzoqmgmyindqumlgkzznrpytjpsvpmizkfnqqynpymyiodmnipjpstqnmypndqrimjpviqrmyiiqqaqrkziqunpdurpndqripynjpslmvvhqlmszqklmyntpkpoqhjzpsvnpmlphamyjznprqkomzuprypyqhprykytodqyndqzsyikiynzdkyqkaklgqisahjzdpeqvmyikomvgqinpndqhkyqkvpmiqizkfnqqynpypbyshuqrykyqlpmvmyindqznrpytupzzzmkioqvvuvqzzmhmzpsvjpsvpmizkfnqqynpymyiodmnipjpstqnmypndqrimjpviqrmyiiqqaqrkziqunpdurpndqripynjpslmvvhqlmszqklmyntpkpoqhjzpsvnpmlphamyjznprqoqvvkbjpszqqhqmlphkyuqnnqrznqamzkiqmvpnpbhqyikiynmvpnpbhqyikqipyqbkznkzkrpyndqpndqrpbznqqvkbndqrktdnpyqipyntqnjpsndqyndqvqbnpyqokvvpdurpndqripynjpslmvvhqlmszqklmyntpkpoqhjzpsvnpmlphamyjznprq";
        static string _text = "pehjdziavahrazketakefakgayacaypzjpkefakgayjlvjprqyajllpsaalkgjkqilerqdptarksyqadzqujdktalqacakgqruehlztakgaadzqkleemrjrkgehfgpehjyalakkqdejdzqsqkryajlvallqzedkvjdkkemdevzedkrnajmqmdevxhrkvgjkpehyarjpqdfrenlajrarkenaonljqdqdfzedkkalliaujhraqkghykrzedkrnajmqmdevvgjkpehyakgqdmqdfqzedkdaazpehyyajredrzedkkalliaujhraqkghykrehyiaieyqarkgapujdtaqdcqkqdfthkreiajyajlkefakgayiqfglpsyqfgkadqdfjrvazqatekgphehjdzqvqkggajzqdipgjdzrqrqkjdzuypzedkrnajmqmdevxhrkvgjkpehyarjpqdfrenlajrarkenaonljqdqdfzedkkalliaujhraqkghykrzedkrnajmqmdevvgjkpehyakgqdmqdfqzedkdaazpehyyajredrzedkkalliaujhraqkghykrqkrjlladzqdfqfekkjrkennyakadzqdfvgevajyapehjdziaqujdraahrzpqdfjyavazedkrnajmqmdevxhrkvgjkpehyarjpqdfrenlajrarkenaonljqdqdfzedkkalliaujhraqkghykrzedkrnajmqmdevvgjkpehyakgqdmqdfqzedkdaazpehyyajredrzedkkalliaujhraqkghykrzedkkalliaujhraqkghykrqmdevvgjkpehjyarjpqdfrenlajrarkenaonljqdqdfzedkrnajmzedkrnajmzedkrnajmdeqmdevvgjkpehyakgqdmqdfjdzqzedkdaazpehyyajredrqmdevpehfeezqmdevpehfeezqmdevpehyajlfeezeg";
    }
}
