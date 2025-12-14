public class Salt
{
    string _stringToEdit;
    List<char> _editedString = new List<char>();
    List<char> _saltChars = new List<char>();

    public Salt(string sTS, List<char> sC, int sODs)
    {
        _stringToEdit = sTS;
        _saltChars = sC;
        if (sODs == 0)
        {
            Salting();
        }
        else
        {
            Desalting();
        }
    }

    public void Salting()
    {
        // Console.WriteLine("Salting string....");

        int saltAmount = 0;
        int saltSeperation = 0;
        int saltPosition = 0;
        int saltToAdd = 0;
        int maxSeperation = 0;
        List<int> saltPositions = new List<int>();

        Random random = new Random();

        int lengthOfString = _stringToEdit.Length;
        while (saltPosition < lengthOfString - 2)
        {
            if (saltPositions.Count == 0)
            {
                if (lengthOfString <= 99)
                {
                    maxSeperation = lengthOfString - 2;
                }
                else
                {
                    maxSeperation = 99;
                }
            }
            else
            {
                if ((lengthOfString - 2) - saltPosition >= 99)
                {
                    maxSeperation = 99;
                }
                else
                {
                    maxSeperation = (lengthOfString - 2) - saltPosition;
                }
            }
            saltSeperation = random.Next(1, maxSeperation + 1);
            saltPosition += saltSeperation;
            saltPositions.Add(saltSeperation);
            // Console.WriteLine($"Salt Position Generated - {saltPositions.Count}");
        }

        int index = 0;
        int usedPositions = 0;
        string digits = "";
        int amountOfSalt = 0;
        int nextSaltPosition = 0;

        digits = DigitsGenerator(saltPositions[usedPositions]);
        _editedString.Add(digits[0]);
        _editedString.Add(digits[1]);
        nextSaltPosition += saltPositions[usedPositions];
        foreach (char c in _stringToEdit)
        {
            if (index == nextSaltPosition)
            {
                // _editedString.Add('|');

                saltAmount = random.Next(0,6);
                _editedString.Add(char.Parse(saltAmount.ToString()));
                while (amountOfSalt < saltAmount)
                {
                    saltToAdd = random.Next(0,_saltChars.Count);
                    _editedString.Add(_saltChars[saltToAdd]);
                    amountOfSalt += 1;
                }

                usedPositions += 1;
                if(usedPositions < saltPositions.Count)
                {
                    nextSaltPosition += saltPositions[usedPositions];
                }
                else
                {
                    nextSaltPosition = lengthOfString;
                }
                

                if (nextSaltPosition < lengthOfString)
                {
                    digits = DigitsGenerator(saltPositions[usedPositions]);
                    _editedString.Add(digits[0]);
                    _editedString.Add(digits[1]);
                }
                else
                {
                    _editedString.Add('0');
                    _editedString.Add('0');
                }
                // _editedString.Add('|');

                // Console.WriteLine("Salt Added");
                amountOfSalt = 0;
            }

            _editedString.Add(c);

            // Console.WriteLine("Character Added");
            index += 1;
        }

        // Console.WriteLine("Salting Complete");
    }
    public void Desalting()
    {
        bool desalted = false;
        List<int> removeIndexes = new List<int>();
        List<char> saltedString = new List<char>();

        foreach (char c in _stringToEdit)
        {
            saltedString.Add(c);
        }
        
        removeIndexes.Add(NumberGenerator(saltedString[0], saltedString[1]));

        saltedString.RemoveAt(0);
        saltedString.RemoveAt(0);

        int saltAmount = 0;
        int nextIndex = -1;
        string saltSeperation;
        bool double0 = false;
        char firstDigit = '\0';
        char secondDigit = '\0';
        char saltAmountChar = '\0';
        int test;
        while(desalted == false)
        {
            saltAmountChar = saltedString[removeIndexes[0]];
            if (int.TryParse(saltAmountChar.ToString(), out test) || saltAmountChar == '0')
            {
                saltAmount = NumberGenerator('0',saltedString[removeIndexes[0]]);
            }
            else
            {
                saltAmount = NumberGenerator('0',saltedString[removeIndexes[0] + 1]);
            }

            for (int i = 0; i < saltAmount + 2; i++)
            {
                removeIndexes.Add(removeIndexes[0] + 1 + i);
            }
            
            firstDigit = saltedString[removeIndexes[removeIndexes.Count - 2]];
            secondDigit = saltedString[removeIndexes[removeIndexes.Count - 1]];
            saltSeperation = firstDigit.ToString() + secondDigit.ToString();
            if (saltSeperation != "00")
            {
                nextIndex = NumberGenerator(firstDigit, secondDigit) + removeIndexes[0];
            }
            else
            {
                double0 = true;
            }

            foreach (int i in removeIndexes)
            {
                saltedString.RemoveAt(removeIndexes[0]);
            }
            removeIndexes.Clear();
            
            if (double0 == false)
            {
                removeIndexes.Add(nextIndex);
            }
            else
            {
                desalted = true;
            }
        }

        _editedString = saltedString;
    }
    public string DigitsGenerator(int n)
    {
        int firstDigit = 0;
        int secondDigit = 0;
        string digits = "";

        if (n >= 10)
        {
            secondDigit = n % 10;
            firstDigit = n / 10;
        }
        else
        {
            secondDigit = n;
        }

        digits += firstDigit.ToString();
        digits += secondDigit.ToString();

        if (digits == "010" || n > 99)
        {
            Console.WriteLine("ISSUE");
        }

        return digits;
    }
    public int NumberGenerator(char d1, char d2, bool t = false)
    {
        if (t)
        {
            Console.WriteLine(d2.ToString());
        }
        string number = "";
        number += d1.ToString();
        number += d2.ToString();

        return int.Parse(number);
    }
    public List<char> GetEditedString()
    {
        return _editedString;
    }
}