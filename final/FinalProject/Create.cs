public class Create
{
    private string _dataType;
    private int _level;
    private List<string> _encryptedData = new List<string>();
    private string _formattedEncryptedData;
    private List<string> _errorMessage = new List<string> {"Invalid Input - Input needs to be at least 11 characters long including spaces.", "Invalid Input - Input contains symbols the program can't handle. Please remove these symbols: "};
    private const int MESSAGE_LENGTH_INDEX = 0;
    private const int MESSAGE_SYM_INDEX = 1;
    private List<string> _loginInfoPrompts = new List<string> {"-- What site is the login information for? Note: If the site name is shorter than 11 characters just add a random character to make it 11 characters long. ", "-- What is the username you will be encrypting? ", "-- What is the password used with this username? "};
    private List<string> _userInputs = new List<string>();

    public Create(string dT, int l)
    {
        _dataType = dT;
        _level = l;

        Console.Clear();
        Console.WriteLine("All further inputs must be at least 11 characters long, including spaces. If the input is extremely long, it may take longer for the program to run.");
        ObtainUserInput();
        RunEncryption();
        FormatEncryptedData();
        Console.Clear();
    }

    private string ValidCharacters(string uI)
    {
        string invalidSyms = "";
        bool containsInvalid = false;
        List<char> validSymbols = ['!', '#', '$', '%', '&', '(', ')', '*', '=', '+', ',', '-', '.', '/', ':', ';', '<', '>', '?', '@', '[', ']', '^', '_', '`', '{', '}', '~', ' '];

        foreach (char c in uI)
        {
            if ( char.IsLetter(c) == false && char.IsDigit(c) == false)
            {
                if (validSymbols.Contains(c) == false)
                {
                    invalidSyms += c.ToString();
                    containsInvalid = true;
                }
            }
        }

        if (containsInvalid == true)
        {
            return invalidSyms;
        }
        else
        {
            return "All Symbols Valid";
        }
    }
    private bool ValidateInput(string userInput)
    {
        string symsValid;
        bool valid = false;
        if (userInput.Length > 10)
        {
            symsValid = ValidCharacters(userInput);
            if (symsValid != "All Symbols Valid")
            {
                Console.Write(_errorMessage[MESSAGE_SYM_INDEX]);
                foreach (char c in symsValid)
                {
                    Console.Write($"{c}, ");
                }
                Console.Write("\b \b");
                Console.Write("\b \b");
                Console.WriteLine();
            }
            else
            {
                _userInputs.Add(userInput);
                valid = true;
            }
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine(_errorMessage[MESSAGE_LENGTH_INDEX]);
            Console.WriteLine();
        }
        return valid;
    }
    private void ObtainLoginInfo()
    {
        string userInput = "";

        foreach (string p in _loginInfoPrompts)
        {
            bool valid = false;
            while (valid == false)
            {
                Console.Write(p);
                userInput = Console.ReadLine();
                valid = ValidateInput(userInput);
            }
        }
    }
    private void ObtainJournalEntry()
    {
        string userInput = "";

        bool valid = false;
        while (valid == false)
        {
            Console.WriteLine("-- Please enter your journal entry. Entry may be as long as you would like but the longer it is the slower the program may run:");
            Console.WriteLine();
            userInput = Console.ReadLine();
            valid = ValidateInput(userInput);
        }
    }
    private void ObtainUserInput()
    {
        if (_dataType == "login info")
        {
            ObtainLoginInfo();
        }
        else
        {
            ObtainJournalEntry();
        }
    }
    private void RunEncryption()
    {
        Encryption encryption = null;
        Decryption decryption = null;

        foreach (string uI in _userInputs)
        {
            bool run = true;
            while (run)
            {
                if (_level == 1)
                {
                    try
                    {
                        encryption = new Level1(uI);
                        decryption = new DLevel1(encryption.GetFinishedString());
                        run = false;
                    }
                    catch (Exception e)
                    {
                        
                    }
                }
                else if (_level == 2)
                {
                    try
                    {
                        encryption = new Level2(uI);
                        decryption = new DLevel2(encryption.GetFinishedString());
                        run = false;
                    }
                    catch (Exception e)
                    {
                        
                    }
                }
                else
                {
                    try
                    {
                        encryption = new Level3(uI);
                        decryption = new DLevel3(encryption.GetFinishedString());
                        run = false;
                    }
                    catch (Exception e)
                    {
                        
                    }
                }
            }

            _encryptedData.Add(encryption.GetFinishedString());
        }
    }
    private void FormatEncryptedData()
    {
        string formattedData = "";
        int index = 0;
        foreach (string d in _encryptedData)
        {
            formattedData += d;
            if (_encryptedData.Count > 1 && index != 2)
            {
                formattedData += "|";
            }
            index += 1;
        }
        
        _formattedEncryptedData = formattedData;
    }
    public string GetEncryptedData()
    {
        Console.WriteLine("Data creation successful.");
        Console.WriteLine();
        return _formattedEncryptedData;
    }
}