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
    }
    public override string CallType()
    {
        return "sym";
    }
}