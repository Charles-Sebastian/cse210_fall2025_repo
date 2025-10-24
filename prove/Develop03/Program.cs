using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        List<string> scriptures = new List<string>();
        List<string> refScript = new List<string>();
        List<string> words = new List<string>();

        void ExtractScriptures()
        {
            foreach (string line in File.ReadAllLines("scriptures.txt"))
            {
                scriptures.Add(line);
            }
        }

        void SelectScripture()
        {
            bool validInput = false;
            int userInputInt = 0;
            string reference = "";
            string scripture = "";

            do
            {
                Console.WriteLine("Would you like to provide your own scripture or have one selected for you?");
                Console.WriteLine("1. Provide my own");
                Console.WriteLine("2. Select one for me");
                Console.Write("Please enter the number for your selection: ");
                string userInput = Console.ReadLine();

                try
                {
                    userInputInt = int.Parse(userInput);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Input - Entry was not an integer");
                }

                if (userInputInt == 1 || userInputInt == 2)
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid Input - Number must be 1 or 2");
                    Thread.Sleep(5000);
                }

                Console.Clear();
            } while (validInput == false);

            if (userInputInt == 1)
            {
                Thread.Sleep(2000);
                Console.WriteLine("Please enter the reference for your scripture in this format: Book Chapter:First Verse-Second Verse (i.e. Psalms 3:20-21)");
                reference = Console.ReadLine();

                Console.WriteLine("Please enter the content of your scripture. Do not include verse numbers even if it spans multiple verses.");
                scripture = Console.ReadLine();

                Thread.Sleep(1000);
                Console.Clear();
            }
            else
            {
                Random random = new Random();
                int scriptureIndex = random.Next(1, scriptures.Count + 1) - 1;

                int delimiter = scriptures[scriptureIndex].IndexOf("||");

                reference = scriptures[scriptureIndex].Substring(0, delimiter);
                scripture = scriptures[scriptureIndex].Substring(delimiter + 2);
            }

            refScript.Add(reference);
            refScript.Add(scripture);
        }

        void GenerateWords()
        {
            string scripture = refScript[1];
            words.AddRange(scripture.Split(' '));
        }

        void Memorize()
        {
            Scripture scripture = new Scripture(refScript[0], words);
            int iteration = 1;
            bool run = true;
            string moreWords = "";

            do
            {
                moreWords = scripture.Display(iteration);
                Console.Write("Press enter to continue or type 'quit' to finish: ");

                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "quit")
                {
                    run = false;
                }
                else
                {
                    Console.Clear();
                    scripture.Hide();
                    iteration += 1;

                    if (moreWords == "done")
                    {
                        run = false;
                    }
                }
            } while (run == true);
        }

        ExtractScriptures();
        SelectScripture();
        GenerateWords();
        Memorize();
    }
}