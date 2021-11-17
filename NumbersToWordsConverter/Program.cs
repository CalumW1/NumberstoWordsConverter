using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToWordsConverter
{
    class Program
    {
        private Dictionary dictionary = new Dictionary();
        static void Main(string[] args)
        {
            var covert = new Converter();
            covert.userInput();
        }
    }
}
