public class KeyNum : Key
{
    public KeyNum()
    {
        GenerateKey();
    }

    private void GenerateKey()
    {
        List<char> key = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];
        SetKey(key);
        // Console.WriteLine("NUM Key Generated");
    }
    public override string CallType()
    {
        return "num";
    }
}