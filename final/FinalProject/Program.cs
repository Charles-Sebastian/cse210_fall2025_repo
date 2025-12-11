using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.VisualBasic;

class Program
{
    static void Main(string[] args)
    {
        Level1 test1 = new Level1(Console.ReadLine());

        Console.WriteLine(test1.GetEncryptedString());
    }
}