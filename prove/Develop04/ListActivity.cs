public class ListActivity : Activity
{
    private List<string> _listPrompts = new List<string>();

    public ListActivity(string activityName, List<string> animationSymbols, string startMessage, string congratsMessage, string endMessagePart1, string endMessagePart2, string activityDescription, List<string> listPrompts) : base(activityName, animationSymbols, startMessage, congratsMessage, endMessagePart1, endMessagePart2, activityDescription)
    {
        foreach (string prompt in listPrompts)
        {
            _listPrompts.Add(prompt);
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

        int prompt = RandomNumber(_listPrompts.Count);

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