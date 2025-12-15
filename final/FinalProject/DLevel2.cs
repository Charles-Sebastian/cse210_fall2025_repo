public class DLevel2 : Decryption
{
    private List<char> _desaltedString;
    public DLevel2(string pS) : base(pS)
    {
        RunDecryption();
    }

    private void Desalt()
    {
        Salt desalt = new Salt(GetString(), GetCypher(), 1);

        _desaltedString = desalt.GetEditedString();
    }
    public override void RunDecryption()
    {
        string desaltedString = "";

        ExtractIncriment();
        ExtractId();
        Compile(GetCyphers(GetId()), GetKeys());
        Decrypt();
        Desalt();
        foreach (char c in _desaltedString)
        {
            desaltedString += c.ToString();
        }
        DLevel1 dLevel1 = new DLevel1(desaltedString);
        SetDecryptedString(dLevel1.GetDecryptedString());
    }
}