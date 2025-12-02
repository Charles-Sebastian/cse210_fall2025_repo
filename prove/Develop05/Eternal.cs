public class Eternal : Goal
{
    int _timesCompleted;

    public Eternal(string gN, string gD, int gV, int tC = 0) : base(gN, gD, gV)
    {
        _timesCompleted = tC;
    }
    
    public override int CompletGoal()
    {
        _timesCompleted += 1;
        return int.Parse(GetValue());
    }
    public override int CallType()
    {
        return 2;
    }
    public override string GetStatus()
    {
        return _timesCompleted.ToString();
    }
    public override void Display(int displayNumber, int displayType = 1)
    {
        Console.Write($"{displayNumber}. ");

        if (displayType == 1)
        {
            Console.Write($"[ ] ");
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