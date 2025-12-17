public class View
{
    private int _level;
    private string _dataType;
    private List<string> _dataToDisplay = new List<string>();
    private List<string> _encryptedData = new List<string>();

    public View(string dT, List<string> nED, List<string> oED)
    {
        _dataType = dT;
        foreach (string d in oED)
        {
            _encryptedData.Add(d);
        }
        foreach (string d in nED)
        {
            if (_encryptedData.Contains(d) == false)
            {
                _encryptedData.Add(d);
            }
        }

        FilterData();
        ObtainLevel();
        Console.Clear();
        DisplayData();
        Console.WriteLine();
        Console.Write("Press enter when you are done viewing the data.");
        Console.ReadLine();
        Console.Clear();
    }

    private void FilterData()
    {

        foreach (string d in _encryptedData)
        {
            if (_dataType == "login info")
            {
                if (d.Contains('|'))
                {
                    _dataToDisplay.Add(d);
                }
            }
            else
            {
                if (d.Contains('|') == false)
                {
                    _dataToDisplay.Add(d);
                }
            }
        }
    }
    private void ObtainLevel()
    {
        string level;
        int tryLevel = 0;
        bool valid = false;
        while (valid == false)
        {
            Console.Write("What encryption type did you use for this data: 1, 2, or 3? ");
            level = Console.ReadLine();
            if (int.TryParse(level, out tryLevel))
            {
                if (tryLevel > 0 && tryLevel < 4)
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Invalid Input - Input needs to be 1, 2, or 3.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Input - Input needs to be a number");
            }
        }

        _level = tryLevel;
    }
    private string TryDecryption(string lI)
    {
        Decryption decryption = null;
        if (_level == 1)
        {
            try
            {
                decryption = new DLevel1(lI);
                return decryption.GetDecryptedString();
            }
            catch(Exception e)
            {
                return "Decryption Error: Incorrect encryption type provided.";
            }
        }
        else if (_level == 2)
        {
            try
            {
                decryption = new DLevel2(lI);
                return decryption.GetDecryptedString();
            }
            catch(Exception e)
            {
                return "Decryption Error: Incorrect encryption type provided.";
            }
        }
        else
        {
            try
            {
                decryption = new DLevel3(lI);
                return decryption.GetDecryptedString();
            }
            catch(Exception e)
            {
                return "Decryption Error: Incorrect encryption type provided.";
            }
        }
    }
    private void DisplayLoginInfo()
    {
        List<string> displayMessage = ["Website -", "Username -", "Password -"];
        string[] loginInfo = null;
        int loginInfoIndex;
        int index = 0;
        foreach (string d in _dataToDisplay)
        {
            Console.Write($"{index + 1}.");
            loginInfoIndex = 0;
            loginInfo = d.Split('|');
            foreach (string lI in loginInfo)
            {
                Console.Write($"{displayMessage[loginInfoIndex]} {TryDecryption(lI)}");
                if (loginInfoIndex < 2)
                {
                    Console.Write("; ");
                }
                loginInfoIndex += 1;
            }
            Console.WriteLine();
            index += 1;
        }
    }
    private void DisplayJournal()
    {
        foreach (string d in _dataToDisplay)
        {
            Console.WriteLine(TryDecryption(d));
            Console.WriteLine();
        }
    }
    private void DisplayData()
    {
        if (_dataType == "login info")
        {
            DisplayLoginInfo();
        }
        else
        {
            DisplayJournal();
        }
    }
}