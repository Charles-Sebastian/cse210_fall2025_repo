using System.Security.Claims;

public class Save
{
    private List<string> _dataToSave = new List<string>();
    private string _fileName;

    public Save(List<string> dTS)
    {
        _dataToSave = dTS;
        Console.Clear();
        ObtainFileName();
        SaveToFile();
    }

    private string ValidateFileName(string fN)
    {
        List<char> invalidCharacters = ['\\', '/', ':', '*', '?', '\"', '<', '>', '|', '!', '@', '#', '$', '%', '^', '&', '(', ')', '+', '=', '[', ']', '{', '}', '\'', ',', ';', '~', '`', ' ', '.'];
        string charactersInvalid = "";
        bool containsInvalid = false;

        foreach (char c in fN)
        {
            if (invalidCharacters.Contains(c))
            {
                charactersInvalid += c.ToString();
                containsInvalid = true;
            }
        }

        if (containsInvalid == true)
        {
            return charactersInvalid;
        }
        else
        {
            return "All Characters Valid";
        }
    }
    private bool ValidateContainedData()
    {
        string userInput = "";
        bool valid = false;
        while (valid == false)
        {
            Console.Write("-- Is the data in the file the same encryption type as the data you wish to save? ");
            userInput = Console.ReadLine().ToLower();
            if ((userInput == "no") == false && (userInput == "yes") == false)
            {
                Console.WriteLine();
                Console.WriteLine("Invalid Input - Input needs to be yes or no.");
                Console.WriteLine();
            }
            else
            {
                valid = true;
            }
        }

        if (userInput == "yes")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void ObtainFileName()
    {
        string editFile = "";
        string overwriteFile;
        string ensureOverwite;
        string charactersInvalid;
        string fileName = "";
        bool ran = false;
        bool valid;
        bool done = false;
        while (done == false)
        {
            valid = false;
            if (ran == true)
            {
                ran = false;
                Console.Write("-- Please provide a different filename.");
                if (editFile == "yes")
                {
                    Console.Write("-- If you want to use an existing file, the data you wish to save must be the same encryption type as the data in the file.");
                }
            }

            editFile = "";
            overwriteFile = "";
            ensureOverwite = "";

            while (valid == false)
            {
                while (fileName == "")
                {
                    Console.Write("-- What would you like the name of your save file to be?(Note: Do not include the file extension) ");
                    fileName = Console.ReadLine();
                }

                charactersInvalid = ValidateFileName(fileName);
                if (charactersInvalid != "All Characters Valid")
                {
                    Console.WriteLine();
                    Console.Write("Invalid Input - Your filename contains the following characters which cause issues: ");
                    Console.WriteLine();
                    foreach (char c in charactersInvalid)
                    {
                        Console.Write($"\"{c}\", ");
                    }
                    Console.Write("\b \b");
                    Console.Write("\b \b");
                    Console.WriteLine();
                    Console.WriteLine("-- Please re-enter your filename without those characters.");
                    fileName = "";
                }
                else
                {
                    fileName += ".txt";
                    valid = true;
                }
            }

            if (File.Exists(fileName))
            {
                while ((editFile == "no") == false && (editFile == "yes") == false)
                {
                    Console.Write("-- A file with this name already exists. Do you wish to add this data to the file? ");
                    editFile = Console.ReadLine().ToLower();

                    if ((editFile == "no") == false && (editFile == "yes") == false)
                    {
                        Console.WriteLine("-- Invalid Input - Input needs to be yes or no.");
                    }
                }

                if (editFile == "yes")
                {
                    ran = true;
                    _fileName = fileName;
                    done = ValidateContainedData();
                }
                else
                {
                    while ((overwriteFile == "no") == false && (overwriteFile == "yes") == false)
                    {
                        Console.WriteLine("-- Do you wish to overwrite this file? ");
                        overwriteFile = Console.ReadLine().ToLower();

                        if ((overwriteFile == "no") == false && (overwriteFile == "yes") == false)
                        {
                            Console.WriteLine("-- Invalid Input - Input needs to be yes or no.");
                        }
                    }
                }

                if (overwriteFile == "yes")
                {
                    while((ensureOverwite == "no") == false && (ensureOverwite == "yes") == false)
                    {
                        Console.WriteLine("-- Are you sure that you want to overwrite the file? This will erase the existing file and create a new one of the same name. Any data not save elsewhere will be lost. ");
                        ensureOverwite = Console.ReadLine().ToLower();

                        if ((ensureOverwite == "no") == false && (ensureOverwite == "yes") == false)
                        {
                            Console.WriteLine("-- Invalid Input - Input needs to be yes or no.");
                        }
                    }

                    if (ensureOverwite == "yes")
                    {
                        File.Create(fileName).Close();
                        done = true;
                    }
                    else
                    {
                        ran = true;
                    }
                }
            }
            else
            {
                File.Create(fileName).Close();
                _fileName = fileName;
                done = true;
            }
        }
    }
    private void SaveToFile()
    {
        foreach (string d in _dataToSave)
        {
            File.AppendAllText(_fileName, d + Environment.NewLine);
        }

        Console.Clear();
        Console.WriteLine("File saved successfully.");
        Console.WriteLine();
    }
}