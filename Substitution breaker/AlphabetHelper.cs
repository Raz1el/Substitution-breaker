using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substitution_breaker
{
    public static class AlphabetHelper
    {
        public static readonly char[] EnglishAlphabet = Enumerable.Range('a', 'z' - 'a' + 1).Select(n => (char)n).ToArray();

        public static char[] GetAlphabet(Language language)
        {
            switch (language)
            {
                case Language.English:
                    return EnglishAlphabet;
                default:
                    throw new NotImplementedException();
            }

        }
    }
}
