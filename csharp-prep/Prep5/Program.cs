using System;

class Program
{
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();
        return userName;

    }
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int userNumber = int.Parse(Console.ReadLine());
        return userNumber;
    }
    static int PromptUserBirthYear()
    {
        Console.Write("Please enter the year you were born: ");
        int userBirthYear = int.Parse(Console.ReadLine());
        return userBirthYear;
    }
    static int SquareNumber(int x)
    {
        int squaredNumber = x * x;
        return squaredNumber;
    }
    static int CalculateUserAge(int x)
    {
        int currentYear = DateTime.Now.Year;
        int userAge = currentYear - x;
        return userAge;
    }
    static void DisplayResult(string x, int y, int z)
    {
        Console.WriteLine($"{x}, the square of your number is {y}");
        Console.WriteLine($"{x}, you will turn {z} this year.");
    }
    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(userNumber);
        int userBirthYear = PromptUserBirthYear();
        int userAge = CalculateUserAge(userBirthYear);
        DisplayResult(userName, squaredNumber, userAge);
    }
}