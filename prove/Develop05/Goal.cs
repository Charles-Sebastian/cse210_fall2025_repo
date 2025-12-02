public abstract class Goal
{
    private string _goalName;
    private string _goalDescription;
    protected int _goalValue;

    public Goal(string gN, string gD, int gV)
    {
        _goalName = gN;
        _goalDescription = gD;
        _goalValue = gV;
    }

    public abstract int CompletGoal();
    public abstract int CallType();
    public abstract string GetStatus();
    public abstract void Display(int displayNumber, int displayType = 1);
    public string GetName()
    {
        return _goalName;
    }
    public string GetDescription()
    {
        return _goalDescription;
    }
    public virtual string GetValue(int operation = 0)
    {
        return _goalValue.ToString();
    }
}