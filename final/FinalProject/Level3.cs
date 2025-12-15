public class Level3 : Encryption
{
    private List<char> _keyId2 = new List<char>();
    private List<char> _key2 = new List<char>();
    private List<char> _cypher2 = new List<char>();
    private List<char> _encryptedString2 = new List<char>();
    
    public Level3(string pS) : base(3, pS)
    {
        RunEncryption();
    }

    protected override void GenerateKeyId(List<Cypher> cyphers, int keyAndCypherNum)
    {
        Random random = new Random();

        int setKeyId = -1;
        List<int> idIndex = new List<int>();
        List<char> keyId = new List<char>();

        while (keyId.Count < 4)
        {
            setKeyId = random.Next(0, 4);

            if (idIndex.Contains(setKeyId) == false)
            {
                keyId.Add(cyphers[setKeyId].GetCypherId());
                idIndex.Add(setKeyId);
            }
        }
        
        if (keyAndCypherNum == 1)
        {
            SetKeyId(keyId);
        }
        else
        {
            _keyId2 = keyId;
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

        int index = 0;
        List<char> cypher = new List<char>();
        List<char> key = new List<char>();
        List<char> keyId = new List<char>();
        List<char> keyId1 = GetKeyId();
        
        if(keyAndCypherNum == 1)
        {
            keyId = keyId1;
        }
        else
        {
            keyId = _keyId2;
        }

        while (legnth > cypher.Count || legnth > key.Count)
        {
            if (DetectIdType(keyId[index]) == "abcL" && abcLCount < abcLCypher.Count)
            {
                cypher.Add(abcLCypher[abcLCount]);
                key.Add(abcLKey[abcLCount]);
                abcLCount += 1;
            }
            else if (DetectIdType(keyId[index]) == "abcU" && abcUCount < abcUCypher.Count)
            {
                cypher.Add(abcUCypher[abcUCount]);
                key.Add(abcUKey[abcUCount]);
                abcUCount += 1;
            }
            else if (DetectIdType(keyId[index]) == "num" && numCount < numCypher.Count)
            {
                if (numCount == 0 || symCount % 3 == 0)
                {
                    cypher.Add(numCypher[numCount]);
                    key.Add(numKey[numCount]);
                    numCount += 1;
                }
            }
            else if (DetectIdType(keyId[index]) == "sym" && symCount < symCypher.Count)
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
    protected override void EncryptString(string sTE = null)
    {
        List<char> id1 = GetKeyId();
        List<char> key1 = GetKey();
        List<char> cypher1 = GetCypher();

        List<char> id2 = _keyId2;
        List<char> key2 = _key2;
        List<char> cypher2 = _cypher2;

        List<char> encryptedString = new List<char>();
        
        string stringToEncrypt = sTE;        

        int autoincriment = GetAutoincriment();

        int index = -1;
        int count = 0;
        int autoincriment_count = 0;
        List<char> key = new List<char>();
        List<char> cypher = new List<char>();

        foreach (char character in stringToEncrypt)
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
            autoincriment_count = autoincriment + count;
            index = (key.IndexOf(character) + autoincriment_count) % key.Count;

            encryptedString.Add(cypher[index]);
            count += 1;
        }
        SetString(encryptedString);
    }
    protected override void EmbedId()
    {
        List<char> encryptedString = GetStringNoEmbed();
        List<char> keyId1 = GetKeyId();
        int idCount = 8;
        int idSpacing = encryptedString.Count / idCount;
        int position = -1;
        List<char> id = new List<char>();
        foreach (char c in keyId1)
        {
            id.Add(c);
        }
        foreach (char c in _keyId2)
        {
            id.Add(c);
        }

        if (encryptedString.Count % idCount == 0)
        {
            position = 1;
        }
        else
        {
            position = idSpacing;
        }

        int count = 1;
        int idIndex = 0;
        List<char> fullEncryptedString = new List<char>();

        foreach (char character in encryptedString)
        {
            fullEncryptedString.Add(character);
            if (count == position && idIndex < idCount)
            {
                fullEncryptedString.Add(id[idIndex]);
                idIndex += 1;
                position += idSpacing;
            }
            count += 1;
        }
        SetEncryptedString(fullEncryptedString);
    }
    protected override void RunEncryption()
    {
        Level2 level2 = new Level2(GetString());
        Compile(GetCyphers(2), GetKeys(), 2);
        EncryptString(level2.GetFinishedString());
        EmbedId();
        EmbedIncriment();
    }
}