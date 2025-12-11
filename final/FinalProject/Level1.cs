public class Level1 : Encryption
{
    private string _finishedString;
    private List<char> _encryptedString;
    private List<char> _string = new List<char>();

    public Level1(int l) : base(l)
    {
        EncryptString();
        EmbedId();
        EmbedIncriment();
    }

    private void EncryptString()
    {
        List<char> id = GetKeyId();
        List<char> key = GetKey();
        List<char> cypher = GetCypher();
        string stringToEncrypt = GetString();

        int autoincriment = GetAutoincriment();

        int index = -1;
        int count = 0;
        int autoincriment_count = 0;

        foreach (char character in stringToEncrypt)
        {
            if (autoincriment + count > key.Count)
            {
                autoincriment_count = (autoincriment + count) % key.Count;
            }
            else
            {
                autoincriment_count = autoincriment + count;
            }

            index = key.IndexOf(character) + autoincriment_count;
            _string.Add(cypher[index]);
        }
    }
    private void EmbedId()
    {
        int idSpacing = _string.Count / 4;
        int position = 0;
        List<char> id = GetKeyId();

        if (_string.Count % 4 == 0)
        {
            position = 1;
        }
        else
        {
            position = idSpacing;
        }

        int count = 1;
        int idIndex = 0;

        foreach (char character in _string)
        {
            _encryptedString.Add(character);

            if (count == position)
            {
                _encryptedString.Add(id[idIndex]);
                idIndex += 1;
                position += idSpacing;
            }

            count += 1;
        }
    }
    private void EmbedIncriment()
    {
        int autoincriment = GetAutoincriment();
        int firstDigit;
        int secondDigit;
        List<char> encryptedIncriment = new List<char>();

        if (autoincriment >= 10)
        {
            secondDigit = autoincriment % 10;
            firstDigit = (autoincriment - secondDigit) / 10;
        }
        else
        {
            secondDigit = autoincriment;
            firstDigit = 0;
        }

        List<char> abcL = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j'];
        List<char> abcU = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J'];
        List<char> sym = ['!', '#', '$', '%', '&', '(', ')', '*', '=', '+'];
        List<char> num = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];
        List<List<char>> incriptionCypher = [abcL, abcU, sym, num];

        Random random = new Random();
        int randCypher = random.Next(0, 3);

        if (randCypher == 0)
        {
            encryptedIncriment.Add(abcL[secondDigit]);
            encryptedIncriment.Add(abcL[firstDigit]);
        }
        else if (randCypher == 1)
        {
            encryptedIncriment.Add(abcU[secondDigit]);
            encryptedIncriment.Add(abcU[firstDigit]);
        }
        else if (randCypher == 2)
        {
            encryptedIncriment.Add(sym[secondDigit]);
            encryptedIncriment.Add(sym[firstDigit]);
        }
        else
        {
            encryptedIncriment.Add(num[secondDigit]);
            encryptedIncriment.Add(num[firstDigit]);
        }

        int index = 0;
        foreach (char character in _encryptedString)
        {
            if (index == 0)
            {
                _finishedString += encryptedIncriment[0];
            }

            if (index == secondDigit)
            {
                _finishedString += encryptedIncriment[0];
            }

            _finishedString += character;
        }
    }
    public string GetEncryptedString()
    {
        return _finishedString;
    }
}