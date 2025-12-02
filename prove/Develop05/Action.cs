using System.Drawing;
using System.Net;

public class Action
{
    public Action()
    {

    }

    public void SaveFile(List<Goal> goals)
    {
        string line;

        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();
        File.Create(fileName).Close();

        foreach (Goal goal in goals)
        {
            
            line = $"{goal.CallType()}||{goal.GetName()}||{goal.GetDescription()}||{goal.GetValue(1)}||{goal.GetStatus()}";
            File.AppendAllText(fileName, line + Environment.NewLine);
        }
    }
    public List<Goal> LoadFile()
    {
        List<Goal> goals = new List<Goal>();
        Goal goal = null;
        string[] goalInfo = null;

        Console.Write("What is the filename for the goal file? ");
        foreach (string line in File.ReadAllLines(Console.ReadLine()))
        {
            goalInfo = line.Split("||");

            if (goalInfo[0] == "1")
            {
                goal = new Simple(goalInfo[1], goalInfo[2], int.Parse(goalInfo[3]), bool.Parse(goalInfo[4]));
            }
            else if (goalInfo[0] == "2")
            {
                goal = new Eternal(goalInfo[1], goalInfo[2], int.Parse(goalInfo[3]), int.Parse(goalInfo[4]));
            }
            else if (goalInfo[0] == "3")
            {
                goal = new Checklist(goalInfo[1], goalInfo[2], int.Parse(goalInfo[3]), int.Parse(goalInfo[4]), int.Parse(goalInfo[5]), int.Parse(goalInfo[6]));
            }

            goals.Add(goal);
        }

        return goals;
    }
    public Goal CreateGoal()
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("Which type of goal would you like to create? ");
        string goalType = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string goalName = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string goalDescription = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        string userValue = Console.ReadLine();
        int goalValue = int.Parse(userValue);

        Goal goal = null;

        if (goalType == "1")
        {
            goal = new Simple(goalName, goalDescription, goalValue);
        }
        else if (goalType == "2")
        {
            goal = new Eternal(goalName, goalDescription, goalValue);
        }
        else if (goalType == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            string userCompletion = Console.ReadLine();
            int goalCompletion = int.Parse(userCompletion);

            Console.Write("What is the bonus for accomplishing it that many times? ");
            string userBonus = Console.ReadLine();
            int goalBonus = int.Parse(userBonus);

            goal = new Checklist(goalName, goalDescription, goalValue, goalBonus, goalCompletion);
        }

        return goal;
    }
    public void DisplayGoals(List<Goal> goals, int displayType)
    {
        int index = 1;
        foreach (Goal goal in goals)
        {
            goal.Display(index, displayType);
            index += 1;
        }
    }
    public int LoadPoints(Goal goal)
    {
        int type = goal.CallType();
        string status = goal.GetStatus();
        string value = goal.GetValue(1);
        int points = 0;

        if (type == 1)
        {
            bool simpleComplete = bool.Parse(status);
            if (simpleComplete == true)
            {
                points = int.Parse(value);
            }
        }
        else if (type == 2)
        {
            int eternalComplete = int.Parse(status);
            points = int.Parse(value) * eternalComplete;
        }
        else
        {
            string[] statusInfo = status.Split("||");
            string[] pointInfo = value.Split("||");

            if (statusInfo[1] == statusInfo[0])
            {
                points = (int.Parse(pointInfo[0]) * int.Parse(statusInfo[1])) + int.Parse(pointInfo[1]);
            }
            else
            {
                points = int.Parse(pointInfo[0]) * int.Parse(statusInfo[1]);
            }
        }
        
        return points;
    }
}