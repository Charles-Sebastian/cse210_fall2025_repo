public class Simple : Goal
{
    private bool _complete;

    public Simple(string gN, string gD, int gV, bool c = false) : base(gN, gD, gV)
    {
        _complete = c;
    }

    public override int CompletGoal()
    {
        _complete = true;
        return int.Parse(GetValue());
    }
    public override int CallType()
    {
        return 1;
    }
    public override string GetStatus()
    {
        return _complete.ToString();
    }
    public override void Display(int displayNumber, int displayType = 1)
    {
        char status;
        if (_complete == true)
        {
            status = 'x';
        }
        else
        {
            status = ' ';
        }

        Console.Write($"{displayNumber}. ");

        if (displayType == 1)
        {
            Console.Write($"[{status}] ");
        }

        Console.Write($"{GetName()}");

        if (displayType == 1)
        {
            Console.WriteLine($" ({GetDescription()})");
        }
        else
        {
            Console.WriteLine();
        }
    }
}