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
                AnslatorTay(Console.ReadLine());
                
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
        public static void AnslatorTay(string pig)
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
                VowelConcat(pig);
                Console.WriteLine("Vowel First!");
            }
            else
            {
                ConsConcat(pigArray, pig);
                Console.WriteLine("Consonant first!");
            }
        }
        public static void VowelConcat(string pig)
        {
            Console.WriteLine(pig + "way");
        }
        public static void ConsConcat(char[] pigArray, string pig)
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
                        continue;
                    }
                }
                //This is how we get out after only the first match
                if (indexNum > 0)
                {
                    continue;
                }
            }
            for (int i = 0; i == indexNum; i++)
            {
                holder = holder + pigArray[i];
            }
            
            final = pig.Substring(indexNum, pigLength);
            Console.WriteLine(final + holder + "ay");
        }
        
    }
}
