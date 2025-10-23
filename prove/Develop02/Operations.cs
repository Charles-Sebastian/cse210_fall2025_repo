using System.IO.Enumeration;

public class Operations
{
    public List<string> _extractedEntries = new List<string>();

    public string GetFileName()
    {
        Console.Write("What is your journal file name?(Please include the .txt file extension) ");
        string fileName = Console.ReadLine();

        return fileName;
    }
    public void LoadFile()
    {
        string fileName = GetFileName();
        foreach (string line in File.ReadAllLines(fileName))
        {
            _extractedEntries.Add(line.ToString());
        }
    }
    public void SaveFile(string fileName, string entry)
    {
        File.AppendAllText(fileName, entry + Environment.NewLine);
    }
}