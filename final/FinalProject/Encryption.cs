using System.Runtime.InteropServices.Marshalling;

public abstract class Encryption
{
    private int _level;
    private int _autoincriment;
    private string _providedString = "";
    private string _finishedString;
    private List<char> _keyId = new List<char>();
    private List<char> _key = new List<char>();
    private List<char> _cypher = new List<char>();
    private List<char> _encryptedString = new List<char>();
    private List<char> _string = new List<char>();
    private const int ABC_L_INDEX = 0;
    private const int ABC_U_INDEX = 1;
    private const int NUM_INDEX = 2;
    private const int SYM_INDEX = 3;

    protected Encryption(int l, string pS)
    {
        _providedString = pS;
        _level = l;
        Compile(GetCyphers(1), GetKeys(), 1);
        GenerateAutoincriment();
    }

    protected int GetAbcLIndex()
    {
        return ABC_L_INDEX;
    }
    protected int GetAbcUIndex()
    {
        return ABC_U_INDEX;
    }
    protected int GetNumIndex()
    {
        return NUM_INDEX;
    }
    protected int GetSymIndex()
    {
        return SYM_INDEX;
    }
    protected string GetString()
    {
        return _providedString;
    }
    protected virtual List<Key> GetKeys()
    {
        KeyLower abcLKey = new KeyLower();
        KeyUpper abcUKey = new KeyUpper();
        KeyNum numKey = new KeyNum();
        KeySym symKey = new KeySym();

        List<Key> keys = [abcLKey, abcUKey, numKey, symKey];

        return keys;
    }
    protected virtual List<Cypher> GetCyphers(int keyAndCypherNum)
    {
        LowerAlpha abcL = new LowerAlpha('a');
        UpperAlpha abcU = new UpperAlpha('A');
        Number num = new Number('1');
        Symbol sym = new Symbol('!');

        List<Cypher> cyphers = [abcL, abcU, num, sym];
        GenerateKeyId(cyphers, keyAndCypherNum);

        return cyphers;
    }
    protected List<char> GetCypher()
    {
        return _cypher;
    }
    protected virtual void GenerateKeyId(List<Cypher> cyphers, int keyAndCypherNum)
    {
        Random random = new Random();

        int setKeyId = -1;
        List<int> idIndex = new List<int>();

        while (_keyId.Count < 4)
        {
            setKeyId = random.Next(0, 4);

            if (idIndex.Contains(setKeyId) == false)
            {
                _keyId.Add(cyphers[setKeyId].GetCypherId());
                idIndex.Add(setKeyId);
            }
        }
    }
    protected List<char> GetKeyId()
    {
        return _keyId;
    }
    protected void SetKeyId(List<char> kI)
    {
        _keyId = kI;
    }
    protected List<char> GetKey()
    {
        return _key;
    }
    protected string DetectIdType(char id)
    {
        if (char.IsLetter(id))
        {
            if (char.IsUpper(id))
            {
                return "abcU";
            }
            else
            {
                return "abcL";
            }
        }
        else if (char.IsDigit(id))
        {
            return "num";
        }
        else
        {
            return "sym";
        }
    }
    protected virtual void Compile(List<Cypher> cyphers, List<Key> keys, int keyAndCypherNum)
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
            if (DetectIdType(_keyId[index]) == "abcL" && abcLCount < abcLCypher.Count)
            {
                _cypher.Add(abcLCypher[abcLCount]);
                _key.Add(abcLKey[abcLCount]);
                abcLCount += 1;
            }
            else if (DetectIdType(_keyId[index]) == "abcU" && abcUCount < abcUCypher.Count)
            {
                _cypher.Add(abcUCypher[abcUCount]);
                _key.Add(abcUKey[abcUCount]);
                abcUCount += 1;
            }
            else if (DetectIdType(_keyId[index]) == "num" && numCount < numCypher.Count)
            {
                if (numCount == 0 || symCount % 3 == 0)
                {
                    _cypher.Add(numCypher[numCount]);
                    _key.Add(numKey[numCount]);
                    numCount += 1;
                }
            }
            else if (DetectIdType(_keyId[index]) == "sym" && symCount < symCypher.Count)
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
    protected void SetKey(List<char> k)
    {
        _key = k;
    }
    protected void SetCypher(List<char> c)
    {
        _cypher = c;
    }
    private void GenerateAutoincriment()
    {
        Random random = new Random();
        _autoincriment = random.Next(0, 23);
    }
    protected int GetAutoincriment()
    {
        return _autoincriment;
    }
    protected virtual void EncryptString(string sTE = null)
    {
        List<char> id = _keyId;
        List<char> key = _key;
        List<char> cypher = _cypher;
        string stringToEncrypt;
        if (sTE == null)
        {
            stringToEncrypt = _providedString;
        }
        else
        {
            stringToEncrypt = sTE;
        }
        

        int autoincriment = _autoincriment;

        int index = -1;
        int count = 0;
        int autoincriment_count = 0;

        foreach (char character in stringToEncrypt)
        {
            autoincriment_count = autoincriment + count;
            index = (key.IndexOf(character) + autoincriment_count) % key.Count;

            _string.Add(cypher[index]);
            count += 1;
        }
    }
    protected void SetString(List<char> s)
    {
        _string = s;
    }
    protected List<char> GetStringNoEmbed()
    {
        return _string;
    }
    protected virtual void EmbedId()
    {
        int idSpacing = _string.Count / 4;
        int position = -1;
        List<char> id = _keyId;

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
            if (count == position && idIndex < 4)
            {
                _encryptedString.Add(id[idIndex]);
                idIndex += 1;
                position += idSpacing;
            }
            count += 1;
        }
    }
    protected void SetEncryptedString(List<char> eS)
    {
        _encryptedString = eS;
    }
    protected List<char> GetEncryptedString()
    {
        return _encryptedString;
    }
    protected virtual void EmbedIncriment()
    {
        int autoincriment = _autoincriment;
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
        List<List<char>> encryptionCypher = [abcL, abcU, sym, num];

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
                _finishedString += encryptedIncriment[1];
            }

            index += 1;

            _finishedString += character;
        }
    }
    protected void SetFinishedString(string eS)
    {
        _finishedString = eS;
    }
    public virtual string GetFinishedString()
    {
        return _finishedString;
    }
    protected abstract void RunEncryption();
}