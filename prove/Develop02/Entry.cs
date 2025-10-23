using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

public class Entry
{
    public List<string> _prompts = new List<string>();

    public string GetRandPrompt()
    {
        Random randomGenerator = new Random();

        int randomPrompt = randomGenerator.Next(1, _prompts.Count);
        string prompt = _prompts[randomPrompt];

        return prompt;
    }
    public string GetEntry()
    {
        string prompt = GetRandPrompt();
        string dateTime = DateTime.Now.ToString();
        string entry;

        Console.Write($"{prompt} ");
        entry = dateTime + " >>> " + prompt + " - " + Console.ReadLine();
        return entry;

    }
}