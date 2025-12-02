using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        bool run = true;
        string userInput;
        List<Goal> goals = new List<Goal>();
        int totalPoints = 0;
        Action action = new Action();

        while (run == true)
        {
            Console.WriteLine($"You have {totalPoints} points.");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    goals.Add(action.CreateGoal());
                    break;

                case "2":
                    action.DisplayGoals(goals, 1);
                    break;

                case "3":
                    action.SaveFile(goals);
                    break;

                case "4":
                    List<Goal> loadedGoals = action.LoadFile();
                    foreach (Goal goal in loadedGoals)
                    {
                        goals.Add(goal);
                        totalPoints += action.LoadPoints(goal);
                    }
                    break;

                case "5":
                    action.DisplayGoals(goals, 2);
                    Console.Write("Which goal did you accomplish: ");
                    string userIndex = Console.ReadLine();
                    int goalIndex = int.Parse(userIndex) - 1;

                    int addPoints = goals[goalIndex].CompletGoal();
                    totalPoints += addPoints;

                    Console.WriteLine($"Congratulations! You have earned {addPoints} points!");
                    Console.WriteLine($"You now have {totalPoints} points.");
                    break;

                case "6":
                    run = false;
                    break;
            }
        }
    }
}