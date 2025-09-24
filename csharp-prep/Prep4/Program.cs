using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        bool collectData = true;
        int sum = 0;
        int greatestNumber = 0;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        do
        {
            Console.Write("Enter number: ");
            int userNumber = int.Parse(Console.ReadLine());

            if (userNumber == 0)
            {
                collectData = false;
            }
            else
            {
                numbers.Add(userNumber);
            }

            if (userNumber > greatestNumber)
            {
                greatestNumber = userNumber;
            }
        } while (collectData);

        foreach (int number in numbers)
        {
            sum = sum + number;
        }

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {sum / numbers.Count}");
        Console.WriteLine($"The largest number is: {greatestNumber}");
    }
}