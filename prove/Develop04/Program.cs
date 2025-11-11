using System;

class Program
{
    // To go above and beyond I made it so that each propmt will only be used once per session unless all propmts are used.
    // For the reflection activity, each question will only be asked once each time you do the reflection activity until all questions have been used.
    static void Main(string[] args)
    {
        List<string> activityDescriptions =
        [
            "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area"
        ];

        List<string> reflectionPrompts =
        [
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        ];

        List<string> reflectionQuestions =
        [
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        ];

        List<string> listPrompts =
        [
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        ];

        List<string> animationSymbols = ["|", "/", "-", "\\"];

        List<string> messages =
        [
            "Welcome to the ",
            "Well done!!",
            "You have completed another ",
            " seconds of "
        ];

        List<string> activities = ["Breathing Activity", "Reflecting Activity", "Listing Activity"];

        bool run = true;
        bool validInput = false;
        string userInput;
        int action = 0;

        BreatheActivity breatheActivity = new BreatheActivity(activities[0], animationSymbols, messages[0], messages[1], messages[2], messages[3], activityDescriptions[0], 5);
        ReflectActivity reflectActivity = new ReflectActivity(activities[0], animationSymbols, messages[0], messages[1], messages[2], messages[3], activityDescriptions[0], reflectionPrompts, reflectionQuestions);
        ListActivity listActivity = new ListActivity(activities[0], animationSymbols, messages[0], messages[1], messages[2], messages[3], activityDescriptions[0], listPrompts);


        while (run == true)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Menu Options:");
                Console.WriteLine("1. Start breathing activity");
                Console.WriteLine("2. Start reflecting activity");
                Console.WriteLine("3. Start listing activity");
                Console.WriteLine("4. Quit");
                Console.Write("Select a choice from the menu: ");

                userInput = Console.ReadLine();

                try
                {
                    if (userInput == "test")
                    {
                        action = -1;
                    }
                    else
                    {
                       action = int.Parse(userInput); 
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Input - Please enter the number of the activity you would like to do.");
                    Console.WriteLine();
                    validInput = false;
                }

                if ((action > 0 && action <= 4) || (userInput == "test"))
                {
                    validInput = true;
                }
                else if (action > 0 || action < 0)
                {
                    Console.WriteLine("Invalid Input - Number entered must be 1, 2, 3, or 4.");
                    Console.WriteLine();

                    validInput = false;
                }
            } while (validInput == false);

            if (action == 1)
            {
                breatheActivity.RunActivity();
            }
            else if (action == 2)
            {
                reflectActivity.RunActivity();
            }
            else if (action == 3)
            {
                listActivity.RunActivity();
            }
            else if (userInput == "test")
            {
                
            }
            else
            {
                run = false;
            }
        }
    }
}