using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK_1
{
    internal class StringReverse
    {
        public string[] SplitText(string text)
        {
            return text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public string Reverse(string text)
        {
            string _result = "";
            string[] _splited = SplitText(text);

            Array.Reverse(_splited);

            foreach (string s in _splited) _result += $"{s} ";

            return _result;
        }
    }
}
