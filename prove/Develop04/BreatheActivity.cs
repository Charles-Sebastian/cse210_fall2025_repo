public class BreatheActivity : Activity
{
    private int _breatheLegnth;

    public BreatheActivity(string activityName, List<string> animationSymbols, string startMessage, string congratsMessage, string endMessagePart1, string endMessagePart2, string activityDescription, int breatheLegnth) : base(activityName, animationSymbols, startMessage, congratsMessage, endMessagePart1, endMessagePart2, activityDescription)
    {
        _breatheLegnth = breatheLegnth;
    }

    public void RunActivity()
    {
        Console.Clear();
        DisplayMessage(1);
        Console.WriteLine();
        DisplayMessage(2);
        Console.WriteLine();

        ObtainDuration();

        Console.Clear();
        Console.WriteLine("Getting ready...");
        RunAnimation();

        DateTime endTime = CreateClock();

        int breatheMessage = 0;
        List<string> breatheMessages = ["Breath in...", "Now breathe out..."];

        while (DateTime.Now < endTime)
        {
            TimeSpan remaningTime = endTime - DateTime.Now;
            int secondsLeft = (int)remaningTime.TotalSeconds;

            while (secondsLeft >= 1)
            {
                Console.Write(breatheMessages[breatheMessage]);

                if (secondsLeft >= _breatheLegnth)
                {
                    CountDown(_breatheLegnth);
                }
                else
                {
                    CountDown(secondsLeft);
                }

                if (breatheMessage == 0)
                {
                    breatheMessage = 1;
                }
                else
                {
                    breatheMessage = 0;
                    Console.WriteLine();
                }

                Console.WriteLine();
                remaningTime = endTime - DateTime.Now;
                secondsLeft = (int)remaningTime.TotalSeconds;
            }
        }

        DisplayMessage(3);
        Console.Clear();
    }   
}