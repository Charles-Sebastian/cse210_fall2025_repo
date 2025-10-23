using System.IO;
using System.IO.Enumeration;
using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic;
public class Journal
{
    List<string> _newEntries = new List<string>();
    List<string> _oldEntries = new List<string>();

    public void WriteEntry(List<string> prompts)
    {
        Entry entry = new Entry();

        foreach (string prompt in prompts)
        {
            entry._prompts.Add(prompt);
        }

        _newEntries.Add(entry.GetEntry());
    }
    public void DisplayEntries()
    {
        bool hasOldEntries = true;
        bool hasNewEntries = true;

        if (_oldEntries.Count > 0)
        {
            foreach (string oldEntry in _oldEntries)
            {
                Console.WriteLine(oldEntry);
            }
        }
        else
        {
            hasOldEntries = false;
        }

        if (_newEntries.Count > 0)
        {
            foreach (string newEntry in _newEntries)
            {
                Console.WriteLine(newEntry);
            }
        }
        else
        {
            hasNewEntries = false;
        }

        if (hasOldEntries == false && hasNewEntries == false)
        {
            Console.WriteLine("Journal has no entries to display");
        }
    }
    public void LoadEntries()
    {
        Operations operations = new Operations();
        operations.LoadFile();

        foreach (string entry in operations._extractedEntries)
        {
            _oldEntries.Add(entry);
        }
    }
    public void SaveEntries()
    {
        Operations operations = new Operations();

        string fileName = operations.GetFileName();

        foreach (string entry in _newEntries)
        {
            operations.SaveFile(fileName, entry);
        }
    }
}