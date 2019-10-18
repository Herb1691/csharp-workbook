using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_PigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            /*******************************************
             * Will need an array of vowels
             * An Array of numbers for error checking
             * using String.indexOfAny(Char[])
             *******************************************/

            char[] numbers = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

            List<string> words = new List<string>();
            
            // Ask for user input
            Console.Write("Please enter a word: ");
            string userWord = Console.ReadLine();
            userWord.Trim();

            // Check length
            int wordLength = userWord.Length;
            int totalWords = 0;

            // Loop through string to determine if there are
            // any numbers.  If there are numbers, return
            // invalid word and either close the application
            // or prompt the user to try again.
            if (userWord.IndexOfAny(numbers) != -1)
            {
                Console.WriteLine("Not a valid word!");
                Console.Read();
            }
            //else
            //{
            //    Console.WriteLine("Good Word!");
            //    Console.Read();
            //}
            // Remove any punctuations

            // Loop through each character in the string
            // and search for spaces, if a space is found
            // and we haven't reached the end of the string
            // check to see if the next character is a space
            // repeat until end of string.  If next character
            // is NOT a space but another character, record
            // current location and store previous word for
            // processing.

            // Remove any punctuations and put it in our new variable
            string results = PrepareWords(userWord);
            //Console.WriteLine(results);
            //Console.ReadLine();

            // Pass in our results into the PigLatinize() function
            // to be translated into Pig Latin.
            string finalResults = PigLatinizer(results);

            Console.WriteLine(finalResults.Trim());
            Console.ReadLine();

            //int startingPos = 0;

            //for (int w = 0; w < result.Length; w++)
            //{
            //    if (Char.IsWhiteSpace(result[w]))
            //    {
            //        if (Char.IsWhiteSpace(result[w - 1]))
            //        {

            //        }
            //        else
            //        {
            //            words.Add(result.Substring(startingPos, w - 1));
            //            startingPos = w + 1;
            //        }
            //    }
            //}
            //int counter = 0;
            //string final = "";
            //foreach (string word in words)
            //{
            //    final = final + words[counter] + " ";
            //    counter++;
            //}

            //final.Trim();

            //Console.WriteLine(final);
            //Console.ReadLine();
        }

        static string PrepareWords( string userWords )
        {
            List<char> punct = new List<char>();
            int count = 0;
            string result = "";

            int wordLength = userWords.Length;

            for (int i = 0; i < wordLength; i++)
            {
                if (Char.IsPunctuation(userWords[i]))
                {
                    punct.Add(userWords[i]);
                    count++;
                    //userWord = userWord.Trim(userWord[i]);
                    //Console.WriteLine(userWord);
                    //Console.ReadLine();
                }

                if (i == (wordLength - 1))
                {
                    char[] charPunct = new char[count];
                    for (int c = 0; c < count; c++)
                    {
                        charPunct[c] = punct[c];
                    }

                    string[] newWords = userWords.Split();

                    foreach (string word in newWords)
                    {
                        result = result + word.Trim(charPunct) + " ";
                    }

                    result = result.Trim();
                }
            }
            return result;
        }

        static string PigLatinizer(string translate)
        {
            string translated = "";
            string[] words = translate.Split();
            char[] vowels = { 'a', 'e', 'i', 'o', 'u',
                       'A', 'E', 'I', 'O', 'U' };
            char[] sometimesY = { 'y', 'Y' };
            bool firstLetterIsVowel = false;
            bool lastLetterIsVowel = false;

            foreach (string word in words)
            {
                foreach (char vowel in vowels)
                {
                    if (word[0] == vowel)
                    {
                        firstLetterIsVowel = true;

                        foreach (char lastVowel in vowels)
                        {
                            if (word[word.Length - 1] == lastVowel)
                            {
                                lastLetterIsVowel = true;
                                break;
                            }
                            else
                                lastLetterIsVowel = false;
                        }

                        if (!lastLetterIsVowel)
                        {
                            foreach (char yVowel in sometimesY)
                            {
                                if (word[word.Length - 1] == yVowel)
                                {
                                    lastLetterIsVowel = true;
                                    break;
                                }
                                else
                                    lastLetterIsVowel = false;
                            }
                        }
                        break;
                    }
                    else
                        firstLetterIsVowel = false;
                }

                if (firstLetterIsVowel)
                {
                    if (lastLetterIsVowel)
                    {
                        translated = translated + word.Trim() + "yay" + " ";
                    }
                    else
                        translated = translated + word.Trim() + "ay" + " ";
                }
                else
                {
                    int start = 1;
                    int end = word.Length - 1;
                    int location;

                    // if statement returns -1 if no vowel is present and skips statement
                    if (word.IndexOfAny(vowels, start, end) != -1)
                    {
                        location = word.IndexOfAny(vowels, start, end);
                        string moving = "";
                        for (int r = 0; r < location; r++)
                        {
                            moving = moving + word[r];
                        }
                        string newWord = word.Remove(0, location) + moving;
                        translated = translated + newWord.Trim() + "ay" + " ";
                    }
                    else if (word.IndexOfAny(sometimesY, start, end) != -1)
                    {
                        location = word.IndexOfAny(sometimesY, start, end);
                        string moving = "";
                        for (int r = 0; r < location; r++)
                        {
                            moving = moving + word[r];
                        }
                        string newWord = word.Remove(0, location) + moving;
                        translated = translated + newWord.Trim() + "ay" + " ";
                    }
                    else
                        translated = translated + word.Trim() + "ay" + " ";
                }
            }
            return translated;
        }
    }
}
