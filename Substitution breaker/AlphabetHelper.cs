using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substitution_breaker
{
    public static class AlphabetHelper
    {
        public static readonly char[] EnglishAlphabet = Enumerable.Range('a', 'z' - 'a' + 1)
                                                        .Select(n => (char)n)
                                                        .ToArray();

        public static readonly char[] RussianAlphabet = Enumerable.Range('а', 'я' - 'а' + 1)
                                                        .Select(n => (char)n)
                                                        .Union(new[] { 'ё' })
                                                        .ToArray();

        public static char[] GetAlphabet(Language language)
        {
            switch (language)
            {
                case Language.English:
                    return EnglishAlphabet;
                case Language.Russian:
                    return RussianAlphabet;
                default:
                    throw new NotImplementedException();
            }

        }
    }
}
