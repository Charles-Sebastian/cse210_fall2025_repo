public class ReflectActivity : Activity
{
    private List<string> _reflectionPrompts = new List<string>();
    private List<string> _reflectionQuestions = new List<string>();
    private List<int> _usedPrompts = new List<int>();
    private List<int> _usedQuestions = new List<int>();

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
        _usedQuestions.Clear();

        if (_reflectionPrompts.Count == _usedPrompts.Count)
        {
            _usedPrompts.Clear();
        }

        Console.Clear();
        DisplayMessage(1);
        Console.WriteLine();
        DisplayMessage(2);
        Console.WriteLine();

        ObtainDuration();

        Console.Clear();
        Console.WriteLine("Getting ready...");
        RunAnimation();

        int prompt = 0;
        bool usedPrompt = true;

        while (usedPrompt == true)
        {
            prompt = RandomNumber(_reflectionPrompts.Count);

            if (_usedPrompts.Contains(prompt) == false)
            {
                usedPrompt = false;
            } 
        }
        _usedPrompts.Add(prompt);

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
        bool usedQuestion;

        while (DateTime.Now < endTime)
        {
            usedQuestion = true;
            while (usedQuestion == true)
            {
                question = RandomNumber(_reflectionQuestions.Count);

                if (_usedQuestions.Contains(question) == false)
                {
                    usedQuestion = false;
                }
                else if (_reflectionQuestions.Count == _usedQuestions.Count)
                {
                    _usedQuestions.Clear();
                    usedQuestion = false;
                }
            }
            _usedQuestions.Add(question);

            Console.Write($"> {_reflectionQuestions[question]} ");
            RunAnimation(endTime.ToString(), 15);
            Console.WriteLine();
        }

        DisplayMessage(3);
        Console.Clear();
    }
}