public class Load
{
    private string _fileName = "";
    private string _dataType;
    private List<string> _loadedData = new List<string>();

    public Load(string dT)
    {
        _dataType = dT;
        ObtainFileName();
        if (_fileName.Length > 0)
        {
            LoadFile();
        }
        Console.Clear();
        if (_fileName.Length <= 0)
        {
            Console.WriteLine("ERROR: The file you have selected does not exist. Please make the file or move it into the right folder.");
            Console.WriteLine();
        }
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
    private void ObtainFileName()
    {
        string fileName = "";
        string charactersInvalid;
        bool valid = false;
        int noFileCount = 0;
        while (valid == false)
        {
            Console.Write("What is the name of the file you would like to load?(Note: Do not include the file extension) ");
            fileName = Console.ReadLine();

            charactersInvalid = ValidateFileName(fileName);
            if (charactersInvalid != "All Characters Valid")
            {
                Console.Write("Invalid Input - Your filename should not contain the following characters: ");
                foreach (char c in charactersInvalid)
                {
                    Console.Write($"\"{c}\", ");
                }
                Console.Write("\b \b");
                Console.Write("\b \b");
                Console.WriteLine();
                Console.WriteLine("Please re-enter your filename without those characters.");
            }
            else
            {
                fileName += ".txt";
                if (File.Exists(fileName) == true)
                {
                    valid = true;
                }
                else
                {
                    if (noFileCount < 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid Input: Could not find a file with that name. Please enter a valid file name.");
                        Console.WriteLine();
                        noFileCount += 1;
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
        
        _fileName = fileName;
    }
    private void LoadFile()
    {
        foreach (string l in File.ReadAllLines(_fileName))
        {
            if (_dataType == "login info")
            {
                if (l.Contains('|'))
                {
                    _loadedData.Add(l);
                }
            }
            else
            {
                if (l.Contains('|') == false)
                {
                    _loadedData.Add(l);
                }
            }
        }
    }
    public List<string> GetLoadedData()
    {
        Console.WriteLine("File loaded successfully.");
        Console.WriteLine();
        return _loadedData;
    }
}