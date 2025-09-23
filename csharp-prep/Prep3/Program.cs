using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1,101);

        Console.WriteLine($"What is the magic number? {magicNumber}");

        int userGuess;

        do
        {
            Console.Write($"What is your guess? ");
            userGuess = int.Parse(Console.ReadLine());

            if (userGuess == magicNumber)
            {
                Console.WriteLine("You guessed it!!");
            }
            else if (userGuess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("Higher");
            }
        } while (userGuess != magicNumber);
    }
}