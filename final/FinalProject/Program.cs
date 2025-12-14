using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.VisualBasic;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        Console.Write("Press enter when ready to begin program: ");
        // string operation = Console.ReadLine();
        Console.WriteLine();

        Actions action = new Actions("Test");
    }
}