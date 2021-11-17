﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToWordsConverter
{
    class Dictionary
    {
        public Dictionary<string, string> onesDictionary = new Dictionary<string, string>() {
                { "1", "One" },
                { "2", "Two" },
                { "3", "Three" },
                { "4", "Four" },
                { "5", "Five" },
                { "6", "Six" },
                { "7", "Seven" },
                { "8", "Eight" },
                { "9", "Nine" },
                { "0", "Zero"}
        };

        public Dictionary<string, string> tensDictionary = new Dictionary<string, string>() {
                { "10", "Ten" },
                { "11", "Eleven" },
                { "12", "Twelve" },
                { "13", "Thirteen" },
                { "14", "Fourteen" },
                { "15", "Fifteen" },
                { "16", "Sixteen" },
                { "17", "Seventeen" },
                { "18", "Eighteen" },
                { "19", "Nineteen" },
                { "20", "Twenty" },
                { "30", "Thirty" },
                { "40", "Fourty" },
                { "50", "Fifty" },
                { "60", "Sixty" },
                { "70", "Seventy" },
                { "80", "Eighty" },
                { "90", "Ninety" },
        };
    }
}
