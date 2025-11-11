public class ListActivity : Activity
{
    private List<string> _listPrompts = new List<string>();
    private List<int> _usedPrompts = new List<int>();

    public ListActivity(string activityName, List<string> animationSymbols, string startMessage, string congratsMessage, string endMessagePart1, string endMessagePart2, string activityDescription, List<string> listPrompts, bool runTest = false) : base(activityName, animationSymbols, startMessage, congratsMessage, endMessagePart1, endMessagePart2, activityDescription, runTest)
    {
        foreach (string prompt in listPrompts)
        {
            _listPrompts.Add(prompt);
        }
    }

    public void RunActivity()
    {
        if (_listPrompts.Count == _usedPrompts.Count)
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
            prompt = RandomNumber(_listPrompts.Count);

            if (_usedPrompts.Contains(prompt) == false)
            {
                usedPrompt = false;
            } 
        }
        _usedPrompts.Add(prompt);

        Console.WriteLine("List as many responses to the following prompt as you can:");
        Console.WriteLine($"--- {_listPrompts[prompt]} ---");
        Console.Write("You may begin in: ");
        CountDown(5);
        Console.WriteLine();

        DateTime endTime = CreateClock();
        int countResponses = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            countResponses += 1;
        }
        Console.WriteLine($"You listed {countResponses} items!");

        DisplayMessage(3);
        Console.Clear();
    }
}