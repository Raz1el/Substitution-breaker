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
         var gramms1 = SampleSerializator.GetOnegramms();
           var gramms2 = SampleSerializator.GetBigramms();
          

            var breaker=new Breaker(100);
            var solutions = breaker.Decrypt
                (@"pehjdziavahrazketakefakgayacaypzjpkefakg
ayjlvjprqyajllpsaalkgjkqilerqdptarksyqadzqujdkta
lqacakgqruehlztakgaadzqkleemrjrkgehfgpehjyalakk
qdejdzqsqkryajlvallqzedkvjdkkemdevzedkrnajmq
mdevxhrkvgjkpehyarjpqdfrenlajrarkenaonljqdqdf
zedkkalliaujhraqkghykrzedkrnajmqmdevvgjkpehy
akgqdmqdfqzedkdaazpehyyajredrzedkkalliaujhra
qkghykrehyiaieyqarkgapujdtaqdcqkqdfthkreiajyajlke
fakgayiqfglpsyqfgkadqdfjrvazqatekgphehjdzqvqkgg
ajzqdipgjdzrqrqkjdzuypzedkrnajmqmdevxhrkvgjkpe
hyarjpqdfrenlajrarkenaonljqdqdfzedkkalliaujhraqkg
hykrzedkrnajmqmdevvgjkpehyakgqdmqdfqzedkdaa
zpehyyajredrzedkkalliaujhraqkghykrqkrjlladzq
dfqfekkjrkennyakadzqdfvgevajyapehjdziaqujdraahrzpq
dfjyavazedkrnajmqmdevxhrkvgjkpehyarjpqdfrenlajrarke
naonljqdqdfzedkkalliaujhraqkghykrzedkrnajmqmdevvgjk
pehyakgqdmqdfqzedkdaazpehyyajredrzedkkalliaujhraqk
ghykrzedkkalliaujhraqkghykrqmdevvgjkpehjyarjpqdfrenla
jrarkenaonljqdqdfzedkrnajmzedkrnajmzedkrnajmdeqmde
vvgjkpehyakgqdmqdfjdzqzedkdaazpehyyajredrqmdevpeh
feezqmdevpehfeezqmdevpehyajlfeezeg
zphqaqpavqzmjmhmykzhmiqpsnpbhsi
mapprhmyzhmiqpsnpbhszlvqmyiuvppihszlvq
myiuvppimyizgkymyiupyqmhkyindmn
zoqmgmyindqumlgkzznrpytjpsvpmizkfnqqynpymyi
odmnipjpstqnmypndqrimjpviqrmyiiqqaqrkziqunpdurpn
dqripynjpslmvvhqlmszqklmyntpkpo
qhjzpsvnpmlphamyjznprqkomzup
rypyqhprykytodqyndqzsyikiynzdkyqkaklgqisahjzdpeqvm
yikomvgqinpndqhkyqkvpmiqizkfnqqynpypb
yshuqrykyqlpmvmyindqznrpytupzzzmkioqvvu
vqzzmhmzpsvjpsvpmizkfnqqynpymyiodmnipjp
stqnmypndqrimjpviqrmyiiqqaqrkziqunpdurpnd
qripynjpslmvvhqlmszqklmyntpkpoqhjzpsvnpmlpha
myjznprqoqvvkbjpszqqhqmlphkyuqnnqrznqamzkiqmvpnpbh
qyikiynmvpnpbhqyikqipyqbkznkzkrpyndqpndqrpb
znqqvkbndqrktdnpyqipyntqnjpsndqyndqvqbnpyqo
kvvpdurpndqripynjpslmvvhqlmszqklmyntpkpoq
hjzpsvnpmlphamyjznprq");
        }
    }
}
