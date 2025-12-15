public class Actions
{
    private int _level;

    public Actions(string b)
    {
        if (b == "")
        {
            RunMenu();
        }
        else if(b == "Test")
        {
            RunTest();
        }
        else
        {
            Console.WriteLine("Invalid Operation");
        }
    }

    private void RunMenu()
    {
        
    }
    private void RunTest()
    {
        string testString = "It is not the critic who counts; not the man who points out how the strong man stumbles, or where the doer of deeds could have done them better.";
        int runtime = 1;
        int test = 1;
        int correctRun = 0;
        int testReady = 3;
        string output = "";
        Encryption eTest = null;
        Encryption eTest1 = null;
        Decryption dTest1 = null;
        Encryption eTest2 = null;
        Decryption dTest2 = null;
        Encryption eTest3 = null;
        Decryption dTest3 = null;
        
        if (runtime == 1)
        {
            Console.WriteLine($"Test String -- |{testString}|");
        }

        for (int r = 0; r < testReady; r++)
        {
            for (int i = 0; i < runtime; i++)
            {
                if (test == 1)
                {
                    // Console.WriteLine("Level 1 Test started");
                    eTest1 = new Level1(testString);
                    eTest = eTest1;
                    dTest1 = new DLevel1(eTest1.GetFinishedString());
                    output = dTest1.GetDecryptedString();
                }
                else if (test == 2)
                {
                    // Console.WriteLine("Level 2 Test started");
                    eTest2 = new Level2(testString);
                    eTest = eTest2;
                    // Console.WriteLine("Level 2 Decryption started");
                    dTest2 = new DLevel2(eTest2.GetFinishedString());
                    output = dTest2.GetDecryptedString();
                }
                else
                {
                    // Console.WriteLine("Level 3 Test started");
                    eTest3 = new Level3(testString);
                    eTest = eTest3;
                    dTest3 = new DLevel3(eTest3.GetFinishedString());
                    output = dTest3.GetDecryptedString();
                }

                
                if (runtime == 1)
                {
                    Console.WriteLine($"Level {test} Test - |{output}|");
                }

                if (testString == output)
                {
                    correctRun += 1;
                }
            }
            Console.WriteLine($"Level {test} Test - {correctRun}/{runtime} runs successful");
            Console.WriteLine();
            test += 1;
            correctRun = 0;
        }
    }
}