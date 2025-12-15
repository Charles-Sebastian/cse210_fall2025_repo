public abstract class Decryption
{
    private string _providedString;
    private string _decryptedString;
    private int _autoincriment;
    private List<char> _id = new List<char>();
    private List<char> _encryptedString = new List<char>();
    private List<char> _key = new List<char>();
    private List<char> _cypher = new List<char>();
    private const int ABC_L_INDEX = 0;
    private const int ABC_U_INDEX = 1;
    private const int NUM_INDEX = 2;
    private const int SYM_INDEX = 3;

    public Decryption(string pS)
    {
        _providedString = pS;
    }

    public int GetAbcLIndex()
    {
        return ABC_L_INDEX;
    }
    public int GetAbcUIndex()
    {
        return ABC_U_INDEX;
    }
    public int GetNumIndex()
    {
        return NUM_INDEX;
    }
    public int GetSymIndex()
    {
        return SYM_INDEX;
    }
    public void ExtractIncriment()
    {
        List<char> abcL = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j'];
        List<char> abcU = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J'];
        List<char> sym = ['!', '#', '$', '%', '&', '(', ')', '*', '=', '+'];
        List<List<char>> encryptionCypher = [abcL, abcU, sym];

        char secondDigitEncrypted = _providedString[0];
        char secondDigit;
        char firstDigit = '\0';
        string autoincriment = " ";
        int firstDigitIndex = -1;
        int useCypher = -1;

        if (DetectCharacterType(secondDigitEncrypted) == "abcL")
        {
            secondDigit = char.Parse(abcL.IndexOf(secondDigitEncrypted).ToString());
            useCypher = 0;
        }
        else if (DetectCharacterType(secondDigitEncrypted) == "abcU")
        {
            secondDigit = char.Parse(abcU.IndexOf(secondDigitEncrypted).ToString());
            useCypher = 1;
        }
        else if (DetectCharacterType(secondDigitEncrypted) == "sym")
        {
            secondDigit = char.Parse(sym.IndexOf(secondDigitEncrypted).ToString());
            useCypher = 2;
        }
        else
        {
            secondDigit = secondDigitEncrypted;
        }

        firstDigitIndex = int.Parse(secondDigit.ToString()) + 1;

        int index = 0;

        foreach (char character in _providedString)
        {
            if (index > 0 && index != firstDigitIndex)
            {
                _encryptedString.Add(character);
            }
            else if (index == firstDigitIndex)
            {
                if (useCypher == -1)
                {
                    firstDigit = character;
                }
                else
                {
                    firstDigit = char.Parse(encryptionCypher[useCypher].IndexOf(character).ToString());
                }
            }
            index += 1;
        }

        autoincriment = firstDigit.ToString() + secondDigit.ToString();
        _autoincriment = int.Parse(autoincriment);
    }
    public List<char> GetEncryptedString()
    {
        return _encryptedString;
    }
    public virtual void ExtractId()
    {
        int idSpacing = (_encryptedString.Count - 4) / 4;
        List<int> idPositions = new List<int>();
        int position = -1;

        if ((_encryptedString.Count - 4) % 4 == 0)
        {
            position = 1;
        }
        else
        {
            position = idSpacing;
        }

        int count = 0;

        foreach (char character in _encryptedString)
        {
            if (count == position && _id.Count < 4)
            {
                _id.Add(character);
                idPositions.Add(position);
                position += idSpacing + 1;
            }
            count += 1;
        }

        for (int i = 0; i < 4; i++)
        {
            _encryptedString.RemoveAt(idPositions[i] - i);
        }
    }
    public void SetId(List<char> i)
    {
        _id = i;
    }
    public virtual List<Key> GetKeys()
    {
        KeyLower abcLKey = new KeyLower();
        KeyUpper abcUKey = new KeyUpper();
        KeyNum numKey = new KeyNum();
        KeySym symKey = new KeySym();

        List<Key> keys = [abcLKey, abcUKey, numKey, symKey];

        return keys;
    }
    public virtual List<Cypher> GetCyphers(List<char> i)
    {
        char abcLId = '\0';
        char abcUId = '\0';
        char numId = '\0';
        char symId = '\0';

        List<char> id = new List<char>();

        id = i;

        foreach (char character in id)
        {
            if (DetectCharacterType(character) == "abcL")
            {
                abcLId = character;
            }
            else if (DetectCharacterType(character) == "abcU")
            {
                abcUId = character;
            }
            else if (DetectCharacterType(character) == "num")
            {
                numId = character;
            }
            else if (DetectCharacterType(character) == "sym")
            {
                symId = character;
            }
        }
        LowerAlpha abcL = new LowerAlpha('a', abcLId);
        UpperAlpha abcU = new UpperAlpha('A', abcUId);
        Number num = new Number('1', numId);
        Symbol sym = new Symbol('!', symId);

        List<Cypher> cyphers = [abcL, abcU, num, sym];

        return cyphers;
    }
    public virtual void Compile(List<Cypher> cyphers, List<Key> keys, int keyAndCypherNum = 1)
    {
        List<char> abcLCypher = cyphers[ABC_L_INDEX].GetCypher();
        List<char> abcUCypher = cyphers[ABC_U_INDEX].GetCypher();
        List<char> numCypher = cyphers[NUM_INDEX].GetCypher();
        List<char> symCypher = cyphers[SYM_INDEX].GetCypher();

        List<char> abcLKey = keys[ABC_L_INDEX].GetKey();
        List<char> abcUKey = keys[ABC_U_INDEX].GetKey();
        List<char> numKey = keys[NUM_INDEX].GetKey();
        List<char> symKey = keys[SYM_INDEX].GetKey();

        int legnth = abcLCypher.Count + abcUCypher.Count + numCypher.Count + symCypher.Count;

        int abcLCount = 0;
        int abcUCount = 0;
        int numCount = 0;
        int symCount = 0;

        int index = 0;
        while (legnth > _cypher.Count || legnth > _key.Count)
        {
            if (DetectCharacterType(_id[index]) == "abcL" && abcLCount < abcLCypher.Count)
            {
                _cypher.Add(abcLCypher[abcLCount]);
                _key.Add(abcLKey[abcLCount]);
                abcLCount += 1;
            }
            else if (DetectCharacterType(_id[index]) == "abcU" && abcUCount < abcUCypher.Count)
            {
                _cypher.Add(abcUCypher[abcUCount]);
                _key.Add(abcUKey[abcUCount]);
                abcUCount += 1;
            }
            else if (DetectCharacterType(_id[index]) == "num" && numCount < numCypher.Count)
            {
                if (numCount == 0 || symCount % 3 == 0)
                {
                    _cypher.Add(numCypher[numCount]);
                    _key.Add(numKey[numCount]);
                    numCount += 1;
                }
            }
            else if (DetectCharacterType(_id[index]) == "sym" && symCount < symCypher.Count)
            {
                _cypher.Add(symCypher[symCount]);
                _key.Add(symKey[symCount]);
                symCount += 1;
            }

            index += 1;
            if (index == 4)
            {
                index = 0;
            }
        }
    }
    public void SetKey(List<char> k)
    {
        _key = k;
    }
    public void SetCypher(List<char> c)
    {
        _cypher = c;
    }
    public string DetectCharacterType(char c)
    {
        if (char.IsLetter(c))
        {
            if (char.IsUpper(c))
            {
                return "abcU";
            }
            else
            {
                return "abcL";
            }
        }
        else if (char.IsDigit(c))
        {
            return "num";
        }
        else
        {
            return "sym";
        }
    }
    public int GetAutoincriment()
    {
        return _autoincriment;
    }
    public List<char> GetId()
    {
        return _id;
    }
    public List<char> GetKey()
    {
        return _key;
    }public List<char> GetCypher()
    {
        return _cypher;
    }
    public virtual void Decrypt()
    {
        int autoincriment = _autoincriment;
        List<char> id = _id;
        List<char> encryptedString = _encryptedString;
        List<char> key = _key;
        List<char> cypher = _cypher;

        int index = -1;
        int count = 0;
        int charIndex = 0;
        int autoincrimentCount = 0;

        foreach (char character in encryptedString)
        {
            autoincrimentCount = autoincriment + count;
            charIndex = cypher.IndexOf(character);
            index = (charIndex - autoincrimentCount) % cypher.Count;
            if (index < 0)
            {
                index = cypher.Count + index;
            }

            _decryptedString += key[index];
            count += 1;
        }
    }
    public string GetString()
    {
        return _decryptedString;
    }
    public virtual string GetDecryptedString()
    {
        return _decryptedString;
    }
    public void SetDecryptedString(string dS)
    {
        _decryptedString = dS;
    }
    public abstract void RunDecryption();
}