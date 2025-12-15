public class Level2 : Encryption
{
    private string _stringToEncrypt = "";
    private List<char> _saltedString = new List<char>();
    public Level2(string pS) : base(2, pS)
    {
        RunEncryption();
    }
    private void SaltString(string sTS)
    {
        Salt salt = new Salt(sTS, GetCypher(), 0);

        _saltedString = salt.GetEditedString();
    }
    protected override void RunEncryption()
    {
        Level1 level1 = new Level1(GetString());
        string stringToSalt = level1.GetFinishedString();
        SaltString(stringToSalt);
        foreach (char c in _saltedString)
        {
            _stringToEncrypt += c.ToString();
        }
        EncryptString(_stringToEncrypt);
        EmbedId();
        EmbedIncriment();
    }
}