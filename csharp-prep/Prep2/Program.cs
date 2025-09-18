using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        int gradePercentage = int.Parse(Console.ReadLine());

        string gradeLetter;

        if (gradePercentage >= 90)
        {
            gradeLetter = "A"; ;
        }
        else if (gradePercentage >= 80)
        {
            gradeLetter = "B";
        }
        else if (gradePercentage >= 70)
        {
            gradeLetter = "C";
        }
        else if (gradePercentage >= 60)
        {
            gradeLetter = "D";
        }
        else
        {
            gradeLetter = "F";
        }

        Console.WriteLine($"Your letter grade is {gradeLetter}.");

        if (gradePercentage >= 70)
        {
            Console.WriteLine("You passed!!! Congratulations!!!!");
        }
        else
        {
            Console.WriteLine("You failed. Work hard and you'll do better next time");
        }

    }
}