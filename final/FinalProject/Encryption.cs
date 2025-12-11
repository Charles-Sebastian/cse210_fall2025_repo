using System.Runtime.InteropServices.Marshalling;

public abstract class Encryption
{
    private int _level;
    private int _autoincriment;
    private string _providedString;
    private List<char> _keyId = new List<char>();
    private List<char> _key = new List<char>();
    private List<char> _cypher = new List<char>();
    private const int ABC_L_INDEX = 0;
    private const int ABC_U_INDEX = 1;
    private const int NUM_INDEX = 2;
    private const int SYM_INDEX = 3;

    public Encryption(int l, string pS)
    {
        _providedString = pS;
        _level = l;
        Compile(GetCyphers(), GetKeys());
        GenerateAutoincriment();
    }

    public virtual void SetKeyId(List<Cypher> cyphers)
    {
        Random random = new Random();

        int setKeyId = -1;
        List<int> idIndex = new List<int>();

        while (_keyId.Count < 4)
        {
            setKeyId = random.Next(0, 4);

            if (idIndex.Contains(setKeyId) == false)
            {
                _keyId.Add(cyphers[setKeyId].GetId());
                idIndex.Add(setKeyId);
                // Console.WriteLine($"Obtained Key ID {idIndex.Count}");
            }
        }
        // Console.WriteLine("Set Key ID");
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
    public virtual List<Cypher> GetCyphers()
    {
        LowerAlpha abcL = new LowerAlpha('a');
        UpperAlpha abcU = new UpperAlpha('A');
        Number num = new Number('1');
        Symbol sym = new Symbol('!');

        List<Cypher> cyphers = [abcL, abcU, num, sym];
        SetKeyId(cyphers);

        return cyphers;
    }
    public virtual void Compile(List<Cypher> cyphers, List<Key> keys)
    {
        // Console.WriteLine("Compiling Key and Cypher.....");

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

        // Console.WriteLine("Variables Set. Continuing to compile....");

        while (legnth > _cypher.Count || legnth > _key.Count)
        {
            // Console.WriteLine($"Character {_cypher.Count}/{legnth} of Cypher set. Character {_key.Count}/{legnth} of Key set.");

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
    public List<char> GetCypher()
    {
        return _cypher;
    }
    public List<char> GetKey()
    {
        return _key;
    }
    public List<char> GetKeyId()
    {
        return _keyId;
    }
    public string GetString()
    {
        return _providedString;
    }
    private void GenerateAutoincriment()
    {
        Random random = new Random();
        _autoincriment = random.Next(0, _key.Count);
    }
    public int GetAutoincriment()
    {
        return _autoincriment;
    }
    public string DetectIdType(char id)
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
}