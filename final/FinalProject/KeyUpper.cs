public class KeyUpper : Key
{
    public KeyUpper()
    {
        GenerateKey();
    }

    private void GenerateKey()
    {
        List<char> key = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'];
        SetKey(key);
        // Console.WriteLine("ABCU Key Generated");
    }
    public override string CallType()
    {
        return "abcU";
    }
}