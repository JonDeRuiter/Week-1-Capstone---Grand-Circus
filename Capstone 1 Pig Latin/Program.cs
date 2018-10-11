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
            bool rerun;

            Console.WriteLine("Welcoem to the Pig Latin Translator!");
            do
            {
                Console.Write("Enter text to translate: ");
                string pigLatin = AnslatorTay(Console.ReadLine());
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
            string translated, partial, record;
            int firstVowel;
            //cleans whitespace off and brings it to lower
            pig = pig.Trim();
            pig = pig.ToLower();

            //finds first vowel - records it
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            
            int[] charIndex = new int [pig.Length]; 
            //compares each letter in the vowel array with each letter in the char array
            for (int i = 0; i < 5; i++)
            {
                charIndex[i] = pig.IndexOf(vowels[i]);
            }
            



            record = "p";

            //trims first sound

            //concats the final word

            partial = pig;
            translated = partial + record + "ay";

            return translated;
        }
    }
}
