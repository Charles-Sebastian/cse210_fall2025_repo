
public class DLevel3 : Decryption
{
    private List<char> _id2 = new List<char>();
    private List<char> _key2 = new List<char>();
    private List<char> _cypher2 = new List<char>();
    public DLevel3(string pS) : base(pS)
    {
        RunDecryption();
    }

    protected override void ExtractId()
    {
        List<char> encryptedString = GetEncryptedString();
        int idCount = 8;
        int idSpacing = (encryptedString.Count - idCount) / idCount;
        List<int> idPositions = new List<int>();
        List<char> id = new List<char>();
        int position = -1;

        if ((encryptedString.Count - idCount) % idCount == 0)
        {
            position = 1;
        }
        else
        {
            position = idSpacing;
        }

        int count = 0;

        foreach (char character in encryptedString)
        {
            if (count == position && id.Count < idCount / 2)
            {
                id.Add(character);
                idPositions.Add(position);
                position += idSpacing + 1;
            }
            else if(count == position && id.Count >= idCount / 2 && id.Count < idCount)
            {
                _id2.Add(character);
                idPositions.Add(position);
                position += idSpacing + 1;
            }
            count += 1;
        }

        SetId(id);

        for (int i = 0; i < idCount; i++)
        {
            encryptedString.RemoveAt(idPositions[i] - i);
        }
    }
    protected override void Compile(List<Cypher> cyphers, List<Key> keys, int keyAndCypherNum)
    {
        List<char> abcLCypher = cyphers[GetAbcLIndex()].GetCypher();
        List<char> abcUCypher = cyphers[GetAbcUIndex()].GetCypher();
        List<char> numCypher = cyphers[GetNumIndex()].GetCypher();
        List<char> symCypher = cyphers[GetSymIndex()].GetCypher();

        List<char> abcLKey = keys[GetAbcLIndex()].GetKey();
        List<char> abcUKey = keys[GetAbcUIndex()].GetKey();
        List<char> numKey = keys[GetNumIndex()].GetKey();
        List<char> symKey = keys[GetSymIndex()].GetKey();

        int legnth = abcLCypher.Count + abcUCypher.Count + numCypher.Count + symCypher.Count;

        int abcLCount = 0;
        int abcUCount = 0;
        int numCount = 0;
        int symCount = 0;

        List<char> key = new List<char>();
        List<char> cypher = new List<char>();
        List<char> id = new List<char>();

        if (keyAndCypherNum == 1)
        {
            id = GetId();
        }
        else
        {
            id = _id2;
        }

        int index = 0;
        while (legnth > cypher.Count || legnth > key.Count)
        {
            if (DetectCharacterType(id[index]) == "abcL" && abcLCount < abcLCypher.Count)
            {
                cypher.Add(abcLCypher[abcLCount]);
                key.Add(abcLKey[abcLCount]);
                abcLCount += 1;
            }
            else if (DetectCharacterType(id[index]) == "abcU" && abcUCount < abcUCypher.Count)
            {
                cypher.Add(abcUCypher[abcUCount]);
                key.Add(abcUKey[abcUCount]);
                abcUCount += 1;
            }
            else if (DetectCharacterType(id[index]) == "num" && numCount < numCypher.Count)
            {
                if (numCount == 0 || symCount % 3 == 0)
                {
                    cypher.Add(numCypher[numCount]);
                    key.Add(numKey[numCount]);
                    numCount += 1;
                }
            }
            else if (DetectCharacterType(id[index]) == "sym" && symCount < symCypher.Count)
            {
                cypher.Add(symCypher[symCount]);
                key.Add(symKey[symCount]);
                symCount += 1;
            }

            index += 1;
            if (index == 4)
            {
                index = 0;
            }
        }

        if (keyAndCypherNum == 1)
        {
            SetKey(key);
            SetCypher(cypher);
        }
        else
        {
            _key2 = key;
            _cypher2 = cypher;
        }
    }
    private bool IsEven(int n)
    {
        if (n % 2 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    protected override void Decrypt()
    {
        int autoincriment = GetAutoincriment();
        List<char> encryptedString = GetEncryptedString();
        List<char> id1 = GetId();
        List<char> key1 = GetKey();
        List<char> cypher1 = GetCypher();

        List<char> id2 = _id2;
        List<char> key2 = _key2;
        List<char> cypher2 = _cypher2;

        int index = -1;
        int count = 0;
        int charIndex = 0;
        int autoincrimentCount = 0;
        string decryptedString = "";
        List<char> key = new List<char>();
        List<char> cypher = new List<char>();

        foreach (char character in encryptedString)
        {
            if (IsEven(count))
            {
                key = key1;
                cypher = cypher1;
            }
            else
            {
                key = key2;
                cypher = cypher2;
            }
            autoincrimentCount = autoincriment + count;
            charIndex = cypher.IndexOf(character);
            index = (charIndex - autoincrimentCount) % cypher.Count;
            if (index < 0)
            {
                index = cypher.Count + index;
            }

            decryptedString += key[index];
            count += 1;
        }
        
        SetDecryptedString(decryptedString);
    }
    protected override void RunDecryption()
    {
        ExtractIncriment();
        ExtractId();
        Compile(GetCyphers(GetId()), GetKeys(), 1);
        Compile(GetCyphers(_id2), GetKeys(), 2);
        Decrypt();
        DLevel2 dLevel2 = new DLevel2(GetDecryptedString());
        SetDecryptedString(dLevel2.GetDecryptedString());
    }
}