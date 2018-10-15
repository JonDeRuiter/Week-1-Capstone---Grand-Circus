using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_1_Pig_Latin
{
    class Program
    {
        static void Main(string[] args)
        {
            bool rerun, isWord;

            Console.WriteLine("Welcoem to the Pig Latin Translator!");
            do
            {
                Console.Write("Enter text to translate: ");
                string pigLatin = Console.ReadLine();
                //string [] wordArray = 
                isWord = WeedOut(pigLatin);
                if (isWord)
                {
                    pigLatin = AnslatorTay(pigLatin + " ");
                }
                Console.WriteLine(pigLatin);
                
                rerun = Continue();
            } while (rerun);
        }

        public static bool Continue()
        {
            bool run;
            Console.WriteLine("Do you want to translate another word? y/n");
            string answer = Console.ReadLine();
            answer = answer.ToLower();

            if (answer == "y")
            {
                run = true;
            }
            else if (answer == "n")
            {
                run = false;
            }
            else
            {
                Console.WriteLine("Sorry, I didn't understand that. Try again.");
                run = Continue();
            }
            return run;
        }
        public static string AnslatorTay(string pig)
        {
            bool firstLetter = false;
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

            //cleans whitespace off, brings it to lower, and puts it in a char array
            pig = pig.Trim();
            pig = pig.ToLower();
            char[] pigArray = pig.ToCharArray();
            int[] charIndex = new int [pig.Length];

            //Is the first leter a vowel?
            for (int i = 0; i < 5; i++)
            {
                if (pigArray[0] == vowels[i])
                {
                    firstLetter = true;
                    continue;
                }
            }
            if (firstLetter)
            {
                pig = VowelConcat(pig);
                return pig;
            }
            else
            {
                pig = ConsConcat(pigArray, pig);
                return pig;
            }
        }
        public static string VowelConcat(string pig)
        {
            pig = pig + "way";
            return pig;
        }
        public static string ConsConcat(char[] pigArray, string pig)
        {
            int indexNum = 0;
            string holder = "";
            string final;
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };


            int pigLength = pig.Length - 1;
            for (int i = 0; i < pig.Length; i++)
            {
                for (int i2 = 0; i2 < 5; i2++)
                {
                    if (vowels[i2] == pigArray[i])
                    {
                        indexNum = i;
                        break;
                    }
                }
                //This is how we get out after only the first match
                if (indexNum > 0)
                {
                    break;
                }
            }
            for (int i = 0; i < indexNum; i++)
            {
                holder = holder + pigArray[i];
            }
            final = pig.Substring(indexNum);
            return (final + holder + "ay");
        }
        public static bool WeedOut(string pig)
        {
            bool run = true;
            int counter = 0;
            char[] pigArray = pig.ToCharArray();
            char[] symbArray = {'~', '@', '#', '$', '%', '^', '&', '*', '(', ')', '+', '=', '[', ']', '{', '}', '|', '/', '<', '>', '-', '*', '_' };

            //Weeds out user entries that have numbers or symbols in them, forcing them to just print rather than go through the translator
            //With manually entering in the symbols in the array, it allowed me to leave punctuation out such that punctuation is allowed on the input string and contractions work
            for (int i = 0; i < pig.Length; i++)
            {
                for (int i2 = 0; i2 < symbArray.Length; i2++)
                {
                    if (pigArray[i] == symbArray[i2])
                    {
                        counter++;
                    }
                }
            }

            for (int i = 0; i < pig.Length; i++)
            {
                if (Char.IsDigit(pigArray[i]) || counter > 0)
                {
                    run = false;
                }
            }
                       
            return run;
        }
    }
}
