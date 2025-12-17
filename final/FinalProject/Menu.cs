public class Menu
{
    private List<string> _newEncryptedData = new List<string>();
    private List<string> _oldEncryptedData = new List<string>();
    private List<string> _programMenu = new List<string>();
    private List<string> _loginMenu = new List<string>();
    private List<string> _journalMenu = new List<string>();
    private List<string> _doneIds = new List<string> {LOGIN_DONE_ID, JOURNAL_DONE_ID};
    private const string PROGRAM_MENU_ID = "program";
    private const int PROGRAM_MENU_COUNT = 3;
    private const string MENU_LOGIN_ID = "login info";
    private const string MENU_JOURNAL_ID = "journal";
    private const string MENU_QUIT_ID = "quit";
    private const int MENU_LOGIN_INDEX = 0;
    private const int MENU_JOURNAL_INDEX = 1;
    private const int MENU_QUIT_INDEX = 2;
    private const int LOGIN_MENU_COUNT = 5;
    private const string LOGIN_CREATE_ID = "create";
    private const string LOGIN_SAVE_ID = "save";
    private const string LOGIN_LOAD_ID = "load";
    private const string LOGIN_VIEW_ID = "view";
    private const string LOGIN_DONE_ID = "quit";
    private const int LOGIN_CREATE_INDEX = 0;
    private const int LOGIN_SAVE_INDEX = 1;
    private const int LOGIN_LOAD_INDEX = 2;
    private const int LOGIN_VIEW_INDEX = 3;
    private const int LOGIN_DONE_INDEX = 4;
    private const int JOURNAL_MENU_COUNT = 5;
    private const string JOURNAL_CREATE_ID = "create";
    private const string JOURNAL_SAVE_ID = "save";
    private const string JOURNAL_LOAD_ID = "load";
    private const string JOURNAL_VIEW_ID = "view";
    private const string JOURNAL_DONE_ID = "quit";
    private const int JOURNAL_CREATE_INDEX = 0;
    private const int JOURNAL_SAVE_INDEX = 1;
    private const int JOURNAL_LOAD_INDEX = 2;
    private const int JOURNAL_VIEW_INDEX = 3;
    private const int JOURNAL_DONE_INDEX = 4;

    public Menu(string b = "")
    {
        for (int i = 0; i < PROGRAM_MENU_COUNT; i++)
        {
            if (i == MENU_LOGIN_INDEX)
            {
                _programMenu.Add(MENU_LOGIN_ID);
            }
            else if (i == MENU_JOURNAL_INDEX)
            {
                _programMenu.Add(MENU_JOURNAL_ID);
            }
            else if (i == MENU_QUIT_INDEX)
            {
                _programMenu.Add(MENU_QUIT_ID);
            }
        }
        for (int i = 0; i < LOGIN_MENU_COUNT; i++)
        {
            if (i == LOGIN_CREATE_INDEX)
            {
                _loginMenu.Add(LOGIN_CREATE_ID);
            }
            else if (i == LOGIN_SAVE_INDEX)
            {
                _loginMenu.Add(LOGIN_SAVE_ID);
            }
            else if (i == LOGIN_LOAD_INDEX)
            {
                _loginMenu.Add(LOGIN_LOAD_ID);
            }
            else if (i == LOGIN_VIEW_INDEX)
            {
                _loginMenu.Add(LOGIN_VIEW_ID);
            }
            else if (i == LOGIN_DONE_INDEX)
            {
                _loginMenu.Add(LOGIN_DONE_ID);
            }
        }
        for (int i = 0; i < JOURNAL_MENU_COUNT; i++)
        {
            if (i == JOURNAL_CREATE_INDEX)
            {
                _journalMenu.Add(JOURNAL_CREATE_ID);
            }
            else if (i == JOURNAL_SAVE_INDEX)
            {
                _journalMenu.Add(JOURNAL_SAVE_ID);
            }
            else if (i == JOURNAL_LOAD_INDEX)
            {
                _journalMenu.Add(JOURNAL_LOAD_ID);
            }
            else if (i == JOURNAL_VIEW_INDEX)
            {
                _journalMenu.Add(JOURNAL_VIEW_ID);
            }
            else if (i == JOURNAL_DONE_INDEX)
            {
                _journalMenu.Add(JOURNAL_DONE_ID);
            }
        }

        bool run;
        if (b == "test")
        {
            run = false;
            RunTest();
        }
        else
        {
            run = true;
        }

        while (run == true)
        {
            RunMenu(PROGRAM_MENU_ID);

            string userInput = "";
            bool valid = false;
            while (valid == false)
            {
                userInput = Console.ReadLine().ToLower();
                valid = ValidInput(userInput, PROGRAM_MENU_ID);
            }
            
            Console.Clear();
            int tryUserInput;
            int.TryParse(userInput, out tryUserInput);
            if (tryUserInput == MENU_LOGIN_INDEX || userInput == MENU_LOGIN_ID)
            {
                RunMenu(MENU_LOGIN_ID);
                _newEncryptedData.Clear();
                _oldEncryptedData.Clear();
            }
            else if (int.Parse(userInput) == MENU_JOURNAL_INDEX || userInput == MENU_JOURNAL_ID)
            {
                RunMenu(MENU_JOURNAL_ID);
                _newEncryptedData.Clear();
                _oldEncryptedData.Clear();
            }
            else if (int.Parse(userInput) == MENU_QUIT_INDEX || userInput == MENU_QUIT_ID)
            {
                Console.Write("Are you sure you would like to quit? ");
                if (Console.ReadLine().ToLower() != "no")
                {
                    run = false;
                }
            }
            else
            {
                DisplayError("Entry");
                Console.WriteLine();
            }
        }
    }

    private void RunMenu(string m)
    {
        string userInput;
        string doneConfirm;
        bool valid;
        bool testValid;
        bool runMenu = true;
        while (runMenu)
        {
            userInput = "";
            doneConfirm = "";
            valid = false;
            while (valid == false)
            {
                if (m == PROGRAM_MENU_ID)
                {
                    Console.WriteLine("Menu");
                    Console.WriteLine();
                    for (int i = 0; i < PROGRAM_MENU_COUNT; i ++)
                    {
                        Console.WriteLine($"{i}. {_programMenu[i].ToUpper()}");
                    }
                    Console.WriteLine();
                    Console.Write("Please select the type of data you would like to work with or quit: ");
                    valid = true;
                    runMenu = false;
                }
                else if (m == MENU_LOGIN_ID)
                {
                    Console.WriteLine("Login Menu");
                    Console.WriteLine();
                    for (int i = 0; i < LOGIN_MENU_COUNT; i ++)
                    {
                        Console.WriteLine($"{i}. {_loginMenu[i].ToUpper()}");
                    }
                    Console.WriteLine();
                    Console.Write("Please select the action you would like to perform: ");
                }
                else if (m == MENU_JOURNAL_ID)
                {
                    Console.WriteLine("Journal Menu");
                    Console.WriteLine();
                    for (int i = 0; i < JOURNAL_MENU_COUNT; i ++)
                    {
                        Console.WriteLine($"{i}. {_journalMenu[i].ToUpper()}");
                    }
                    Console.WriteLine();
                    Console.Write("Please select the action you would like to perform: ");
                }

                if (m != PROGRAM_MENU_ID)
                {
                    userInput = Console.ReadLine().ToLower();
                    testValid = ValidInput(userInput, m);
                    if (testValid == false)
                    {
                        DisplayError("Entry");
                        Console.WriteLine();
                    }

                    if (testValid == true)
                    {
                        int tryUserInput;
                        if (int.TryParse(userInput, out tryUserInput))
                        {
                            if (m == MENU_LOGIN_ID)
                            {
                                userInput = _loginMenu[tryUserInput];
                            }
                            else
                            {
                                userInput = _journalMenu[tryUserInput];
                            }
                        }

                        if (_doneIds.Contains(userInput) == true)
                        {
                            while ((doneConfirm == "yes") == false && (doneConfirm == "no") == false)
                            {
                                Console.Write("Are you sure you would like to quit? Any unsaved data will be lost. ");
                                doneConfirm = Console.ReadLine().ToLower();

                                if ((doneConfirm == "no") == false && (doneConfirm == "yes") == false)
                                {
                                    Console.WriteLine("Invalid Input - Input needs to be yes or no.");
                                }
                            }
                        }
                    }

                    if (testValid == true && (doneConfirm == "yes" || doneConfirm == ""))
                    {
                        valid = true;
                        if (doneConfirm == "yes")
                        {
                            runMenu = false;
                        }
                        Console.Clear();
                    }
                }
            }

            doneConfirm = "";

            if (m != PROGRAM_MENU_ID)
            {
                int tryUserInput;
                if (int.TryParse(userInput, out tryUserInput))
                {
                    if (m == MENU_LOGIN_ID)
                    {
                        userInput = _loginMenu[tryUserInput];
                    }
                    else
                    {
                        userInput = _journalMenu[tryUserInput];
                    }
                }
                RunAction(m, userInput);
            }
        }
    }
    private void DisplayError(string eT)
    {
        Console.Clear();
        if (eT == "Entry")
        {
            Console.WriteLine("Invalid Entry: Please review menu and select valid entry");
        }
    }
    private bool ValidInput(string uI, string m)
    {
        List<string> menu = new List<string>();
        int count;
        if (m == MENU_LOGIN_ID)
        {
            menu = _loginMenu;
            count = LOGIN_MENU_COUNT;
        }
        else
        {
            menu = _journalMenu;
            count = JOURNAL_MENU_COUNT;
        }

        int uIInt = -1;
        if (menu.Contains(uI))
        {
            return true;
        }
        else
        {
            if (int.TryParse(uI, out uIInt))
            {
                if (uIInt > -1)
                {
                    if (uIInt < count || uIInt > -1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
    private int ObtainLevel()
    {
        string level;
        int tryLevel = 0;
        Console.WriteLine("This program permits 3 types of encryption. At the moment you will need to remember what type of encryption you used for each item.");
        bool valid = false;
        while (valid == false)
        {
            Console.Write("Would you like to use type 1, 2, or 3? ");
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

        return tryLevel;
    }
    private void RunAction(string m, string a)
    {
        List<string> create = [LOGIN_CREATE_ID, JOURNAL_CREATE_ID];
        List<string> save = [LOGIN_SAVE_ID, JOURNAL_SAVE_ID];
        List<string> load = [LOGIN_LOAD_ID, JOURNAL_LOAD_ID];
        List<string> view = [LOGIN_VIEW_ID, JOURNAL_VIEW_ID];
        
        if (create.Contains(a))
        {
            int level = ObtainLevel();
            Create c = new Create(m, level);
            _newEncryptedData.Add(c.GetEncryptedData());
        }
        else if (save.Contains(a))
        {
            if (_newEncryptedData.Count > 0)
            {
                Save s = new Save(_newEncryptedData);
                _newEncryptedData.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("ERROR: There is nothing to save. Please select another option:");
                Console.WriteLine();
            }
        }
        else if (load.Contains(a))
        {
            _oldEncryptedData.Clear();
            Load l = new Load(m);
            foreach (string d in l.GetLoadedData())
            {
                _oldEncryptedData.Add(d);
            }
        }
        else if (view.Contains(a))
        {
            if (_newEncryptedData.Count > 0 || _oldEncryptedData.Count > 0)
            {
                View v = new View(m, _newEncryptedData, _oldEncryptedData);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("ERROR: There is no data to be view. Please load a file or create data.");
                Console.WriteLine();
            }
        }
    }
    private void RunTest()
    {   
        Console.WriteLine();
        Console.WriteLine("Testing Login Info create");
        Console.WriteLine();
        RunAction(MENU_LOGIN_ID, LOGIN_CREATE_ID);
        Console.WriteLine();
        Console.WriteLine("Testing Login Info save");
        Console.WriteLine();
        RunAction(MENU_LOGIN_ID, LOGIN_SAVE_ID);
        Console.WriteLine();
        Console.WriteLine("Testing Login Info Load");
        Console.WriteLine();
        RunAction(MENU_LOGIN_ID, LOGIN_LOAD_ID);
        Console.WriteLine();
        Console.WriteLine("Testing Login Info View");
        Console.WriteLine();
        RunAction(MENU_LOGIN_ID, LOGIN_VIEW_ID);
        Console.WriteLine();

        
        Console.WriteLine();
        Console.WriteLine("Testing Journal create");
        Console.WriteLine();
        RunAction(MENU_JOURNAL_ID, JOURNAL_CREATE_ID);
        Console.WriteLine();
        Console.WriteLine("Testing Journal save");
        Console.WriteLine();
        RunAction(MENU_JOURNAL_ID, JOURNAL_SAVE_ID);
        Console.WriteLine();
        Console.WriteLine("Testing Journal Load");
        Console.WriteLine();
        RunAction(MENU_JOURNAL_ID, JOURNAL_LOAD_ID);
        Console.WriteLine();
        Console.WriteLine("Testing Journal View");
        Console.WriteLine();
        RunAction(MENU_JOURNAL_ID, JOURNAL_VIEW_ID);
        Console.WriteLine();


    }
}