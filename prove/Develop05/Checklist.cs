using System.Buffers;
using System.Net;

public class Checklist : Goal
{
    private int _timesCompleted;
    private int _timesToComplete;
    private int _completionBonus;

    public Checklist(string gN, string gD, int gV, int cB, int tTC, int tC = 0) : base(gN, gD, gV)
    {
        _timesCompleted = tC;
        _timesToComplete = tTC;
        _completionBonus = cB;
    }

    public override int CompletGoal()
    {
        _timesCompleted += 1;
        int goalValue = int.Parse(GetValue());

        if (_timesCompleted < _timesToComplete)
        {
            return goalValue;
        }
        else if (_timesCompleted == _timesToComplete)
        {
            return _completionBonus + goalValue;
        }
        else
        {
            return 0;
        }
    }
    public override int CallType()
    {
        return 3;
    }
    public override string GetStatus()
    {
        return $"{_timesToComplete}||{_timesCompleted}";
    }
    public override void Display(int displayNumber, int displayType)
    {
        char status;
        if (_timesCompleted >= _timesToComplete)
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
            Console.WriteLine($" ({GetDescription()}) -- Currently completed: {_timesCompleted}/{_timesToComplete}");
        }
        else
        {
            Console.WriteLine();
        }
    }
    public int GetBonus()
    {
        return _completionBonus;
    }
    public override string GetValue(int operation = 0)
    {
        if (operation == 0)
        {
            return _goalValue.ToString();
        }
        else
        {
            return $"{_goalValue}||{_completionBonus}";
        }
    }
}