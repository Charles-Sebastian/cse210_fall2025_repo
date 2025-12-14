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
        int testReady = 2;
        string output = "";
        Encryption eTest = null;
        Decryption dTest = null;
        
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
                    eTest = new Level1(testString);
                    dTest = new DLevel1(eTest.GetEncryptedString());
                    output = dTest.GetDecryptedString();
                }
                else if (test == 2)
                {
                    eTest = new Level2(testString);
                    dTest = new DLevel2(eTest.GetEncryptedString());
                    output = dTest.GetDecryptedString();
                }

                
                if (runtime == 1)
                {
                    Console.WriteLine($"Level {test} Test - |{eTest.GetEncryptedString()}|");
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