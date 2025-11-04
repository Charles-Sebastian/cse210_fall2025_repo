public class ReflectActivity : Activity
{
    private List<string> _reflectionPrompts = new List<string>();
    private List<string> _reflectionQuestions = new List<string>();

    public ReflectActivity(string activityName, List<string> animationSymbols, string startMessage, string congratsMessage, string endMessagePart1, string endMessagePart2, string activityDescription, List<string> reflectionPrompts, List<string> reflectionQuestions) : base(activityName, animationSymbols, startMessage, congratsMessage, endMessagePart1, endMessagePart2, activityDescription)
    {
        foreach (string propmt in reflectionPrompts)
        {
            _reflectionPrompts.Add(propmt);
        }
        foreach (string question in reflectionQuestions)
        {
            _reflectionQuestions.Add(question);
        }
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

        int prompt = RandomNumber(_reflectionPrompts.Count);

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {_reflectionPrompts[prompt]} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        CountDown(5);
        Console.Clear();

        DateTime endTime = CreateClock();
        int question = 0;

        while (DateTime.Now < endTime)
        {
            question = RandomNumber(_reflectionQuestions.Count);
            Console.Write($"> {_reflectionQuestions[question]} ");
            RunAnimation(endTime.ToString(), 15);
            Console.WriteLine();
        }

        DisplayMessage(3);
        Console.Clear();
    }
}