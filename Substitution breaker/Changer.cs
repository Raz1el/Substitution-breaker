using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substitution_breaker
{
    public class Changer
    {
        private string _text;
        private readonly char _tempchar = '$';
        public Changer(string text)
        {
            _text = text;
        }

        public void Swap(char before, char after)
        {
            _text = _text.Replace(before, _tempchar);
            _text = _text.Replace(after, before);
            _text = _text.Replace(_tempchar, after);
        }


        public string GetSolution()
        {
            return _text;
        }

    }
}
