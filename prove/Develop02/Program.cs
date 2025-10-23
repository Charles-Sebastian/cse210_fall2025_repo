using System;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        static void WriteInJournal()
        {
            Journal journal = new();

            List<string> prompts =
            [
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?",
                "What was one thing I learned today?",
                "What is one goal that I have to make tomorrow better?",
                "What is one thing I can improve in my life?"
            ];
            
            List<string> actions = ["Write", "Display", "Load", "Save", "Quit"];
            bool run = true;

            Console.WriteLine("Welcome to journal program!!");

            while (run == true)
            {
                string message;
                bool validInput = true;
                message = "Please select one of the following choices:";

                do
                {
                    int i = 1;

                    if (validInput == false)
                    {
                        message = "Invalid Input - Please enter a number 1 through 5 or action name to select an action";
                    }

                    Console.WriteLine(message);

                    foreach (string action in actions)
                    {
                        Console.WriteLine($"{i}. {action}");

                        i += 1;
                    }

                    Console.Write("What would you like to do? ");
                    string userAction = Console.ReadLine();

                    int userActionNum = 0;
                    try
                    {
                        userActionNum = int.Parse(userAction);
                    }
                    catch (Exception)
                    {

                    }

                    if (userActionNum == 1 || userAction == "Write")
                    {
                        journal.WriteEntry(prompts);
                        validInput = true;
                    }
                    else if (userActionNum == 2 || userAction == "Display")
                    {
                        journal.DisplayEntries();
                        validInput = true;
                    }
                    else if (userActionNum == 3 || userAction == "Load")
                    {
                        journal.LoadEntries();
                        validInput = true;
                    }
                    else if (userActionNum == 4 || userAction == "Save")
                    {
                        journal.SaveEntries();
                        validInput = true;
                    }
                    else if (userActionNum == 5 || userAction == "Quit")
                    {
                        run = false;
                        validInput = true;
                    }
                    else
                    {
                        validInput = false;
                    }
                }
                while (validInput == false);

            }
        }

        WriteInJournal();
    }
}