public class KeyLower : Key
{
    public KeyLower()
    {
        GenerateKey();
    }

    private void GenerateKey()
    {
        List<char> key = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'];
        SetKey(key);
    }
    public override string CallType()
    {
        return "abcL";
    }
}