public class KeySym : Key
{
    public KeySym()
    {
        GenerateKey();
    }

    private void GenerateKey()
    {
        List<char> key = ['!', '#', '$', '%', '&', '(', ')', '*', '=', '+', ',', '-', '.', '/', ':', ';', '<', '>', '?', '@', '[', ']', '^', '_', '`', '{', '}', '~', ' '];
        SetKey(key);
        // Console.WriteLine("SYM Key Generated");
    }
    public override string CallType()
    {
        return "sym";
    }
}