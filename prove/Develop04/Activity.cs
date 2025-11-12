using System.Net.WebSockets;

public class Activity
{
    private string _activityName;
    private int _activityDuration;
    private List<string> _animationSymbols = new List<string>();
    private string _startMessage;
    private string _activityDescription;
    private string _congratsMessage;
    private List<string> _endMessage = new List<string>();

    public Activity(string activityName, List<string> animationSymbols, string startMessage, string congratsMessage, string endMessagePart1, string endMessagePart2, string activityDescription)
    {
        _activityName = activityName;
        foreach (string s in animationSymbols)
        {
            _animationSymbols.Add(s);
        }
        _startMessage = startMessage + activityName;
        _activityDescription = activityDescription;
        _congratsMessage = congratsMessage;
        _endMessage.Add(endMessagePart1);
        _endMessage.Add(endMessagePart2);
    }

    public void DisplayMessage(int messageType)
    {
        if (messageType == 1)
        {
            Console.WriteLine(_startMessage);
        }
        else if (messageType == 2)
        {
            Console.WriteLine(_activityDescription);
        }
        else if (messageType == 3)
        {
            Console.WriteLine(_congratsMessage);
            RunAnimation();
            Console.WriteLine($"{_endMessage[0]}{_activityDuration}{_endMessage[1]}{_activityName}.");
            RunAnimation();
        }
        else
        {
            Console.WriteLine("Invalid Message Type");
        }
    }
    public int ObtainDuration()
    {
        Console.Write("How long, in seconds, would you like for your session? ");

        string userInput = "";
        int duration = 0;
        bool validInput = false;

        do
        {
            userInput = Console.ReadLine();

            try
            {
                duration = int.Parse(userInput);
                validInput = true;
            }
            catch (Exception)
            {
                Console.Write("Invalid Input - Please enter an integer for how long you would like your session: ");
            }

        } while (validInput == false);

        _activityDuration = duration;

        return duration;
    }
    public void RunAnimation(string killTime = null, int runTime = 0)
    {
        if (runTime == 0)
        {
            Random random = new Random();
            runTime = random.Next(3, 11);
        }
        Animation animation = new Animation(_animationSymbols);
        animation.LoadingAnimation(runTime, killTime);
    }
    public DateTime CreateClock()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_activityDuration);
        return endTime;
    }
    public void CountDown(int duration)
    {
        for (int i = duration; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
    public int GetDuration()
    {
        return _activityDuration;
    }
    public int RandomNumber(int upperLimit, int lowerLimit = 0)
    {
        Random random = new Random();
        int randomNum = random.Next(lowerLimit, upperLimit);
        return randomNum;
    }
}