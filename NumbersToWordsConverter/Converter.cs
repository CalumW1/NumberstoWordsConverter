using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToWordsConverter
{
    class Converter
    {
        private Dictionary dictionary = new Dictionary();
        public void userInput()
        {
            Console.Write("Please enter a number between 0 and 9999: ");
            string number = Console.ReadLine();

            // check user input to make sure a number has been entered
            if (int.TryParse(number, out int value))
            {
                if (number.Length == 1)
                {
                    Console.WriteLine(OneDigitNumber(number));
                    Console.ReadLine();
                    userInput();
                }
                else if (number.Length == 2)
                {
                    Console.WriteLine(TwoDigitNumber(number));
                    Console.ReadLine();
                    userInput();
                }
                else if (number.Length == 3)
                {
                    Console.WriteLine(ThreeDigitNumber(number));
                    Console.ReadLine();
                    userInput();
                }
                else if (number.Length == 4)
                {
                    Console.WriteLine(FourDigitNumber(number));
                    Console.ReadLine();
                    userInput();
                }
            }
            // if false print error message and restart the process.
            Console.WriteLine("Please enter a valid number (press enter to continue)");
            Console.ReadLine();
            userInput();
        }

        public string OneDigitNumber(string inputNumber)
        {
            // Case 1: numbers from 0 to 9 
            string results;
            foreach (KeyValuePair<string, string> word in dictionary.onesDictionary)
            {
                if (dictionary.onesDictionary.TryGetValue(inputNumber, out results))
                {
                    // Console.WriteLine("{0}", results);
                    return results;
                }
            }
            return "";
        }


        public string TwoDigitNumber(string inputNumber)
        {
            // Case 1: 11 - 19
            // Case 2: Multiples of 10; 10 - 90
            // Case 3: Combination of 10s and single digits; EXAMPLE 23
            string results;
            foreach (KeyValuePair<string, string> word in dictionary.tensDictionary)
            {
                // check for numbers between 10-19 and multiples of ten.
                if (dictionary.tensDictionary.TryGetValue(inputNumber, out results))
                {
                    return results;
                }
                else
                {
                    var list = new List<string>();

                    // if the number doesn't end in a 0 combine the tens and ones dictionary to return the word. 

                    // split the number into two parts, tens and ones; 
                    char[] splitnumber = inputNumber.ToCharArray();

                    string tensnumber = splitnumber[0].ToString().PadRight(splitnumber.Length, '0');

                    // find the tens wording
                    if (dictionary.tensDictionary.TryGetValue(tensnumber, out results))
                    {
                        list.Add(results);
                    }

                    // find the ones word
                    if (dictionary.onesDictionary.TryGetValue(splitnumber[1].ToString(), out results))
                    {
                        list.Add(results);
                    }

                    // return output
                    return list[0].ToString() + " " +  list[1].ToString();
                }
            }
            return "";
        }

        public string ThreeDigitNumber(string inputNumber)
        {
            // Case 1: multiples of 100; 
            // Case 2: Multiples of 100 with multiples of 10; Example 110. 
            // Case 3: Combination of all three; 

            // convert multiples of 100 into words; 
            char[] splitnumber = inputNumber.ToCharArray();
            string results;
            var hundredslist = new List<string>();

            // check the thrid digit for a zero
            if (splitnumber[1].ToString() == "0" && splitnumber[2].ToString() == "0")
            {
                if (dictionary.onesDictionary.TryGetValue(splitnumber[0].ToString(), out results))
                {
                    return results + " hundred";
                }
            }
            // example 102 
            else if (splitnumber[1].ToString() == "0")
            {
                

                for (int i = 0; i < splitnumber.Length; i++)
                {
                    if (splitnumber[i].ToString() != "0")
                    {
                        if (dictionary.onesDictionary.TryGetValue(splitnumber[i].ToString(), out results))
                        {
                            hundredslist.Add(results);
                        }
                    }
                }
                return hundredslist[0].ToString() + " hundred and " + hundredslist[1].ToString();
            }
            // if there are no zero's 
            else
            {
                // get the hundreds unit
                if (dictionary.onesDictionary.TryGetValue(splitnumber[0].ToString(), out results))
                {
                    hundredslist.Add(results);
                }

                // call 10s function to return the last 2 numbers 
                string join = splitnumber[1].ToString() + splitnumber[2].ToString();

                // use the two digit helper functions
                hundredslist.Add(TwoDigitNumber(join));
               
                return hundredslist[0].ToString() + " hundred and " +  hundredslist[1].ToString();
            }
            return results;
        }

        public string FourDigitNumber(string inputNumber)
        {
            // Case 1: multiples of a Thousand
            // Case 2: multiples of a Thousand and one digit, EXAMPLE: 1001 
            // Case 3: multiples of a thousand and two digits, EXAMPLE: 1012
            // Case 4: multiples of a thousand and three digits, EXAMPLE: 1233

            // split the number up into individual characters;
            char[] numberArray = inputNumber.ToCharArray();
            string results;

            // create a new list to save words too; 
            var thousandslist = new List<string>();

            if (numberArray[1].ToString() == "0" && numberArray[2].ToString() == "0" && numberArray[3].ToString() == "0")
            {
                if (dictionary.onesDictionary.TryGetValue(numberArray[0].ToString(), out results))
                {
                    return results + " Thousand";
                }
            }
            // Case 2: multiples of a Thousand and one digit, EXAMPLE: 1001
            else if (numberArray[1].ToString() == "0" && numberArray[2].ToString() == "0")
            {
                for(int i = 0; i < numberArray.Length; i++)
                {
                    // if the character in the number is not equal to zero then search dictonary and add to the list.
                    if(numberArray[i].ToString() != "0")
                    {
                        if (dictionary.onesDictionary.TryGetValue(numberArray[i].ToString(), out results))
                        {
                           thousandslist.Add(results);
                        }
                    }
                }
                return thousandslist[0].ToString() + " Thousand and " + thousandslist[1].ToString();
            }
            else if(numberArray[1].ToString() == "0")
            {
                if (dictionary.onesDictionary.TryGetValue(numberArray[0].ToString(), out results))
                {
                    thousandslist.Add(results);
                }
                // use two digit function to return the wording. 
                thousandslist.Add(TwoDigitNumber(numberArray[2].ToString() + numberArray[3].ToString()));

                return thousandslist[0].ToString() + " Thousand and " + thousandslist[1].ToString();
            }
            else
            {
                if (dictionary.onesDictionary.TryGetValue(numberArray[0].ToString(), out results))
                {
                    thousandslist.Add(results);
                }
                // use three digit function to return the wording. 
                thousandslist.Add(ThreeDigitNumber(numberArray[1].ToString() + numberArray[2].ToString() + numberArray[3].ToString()));

                return thousandslist[0].ToString() + " Thousand " + thousandslist[1].ToString();
            }

            return results;
        }
    }
}
