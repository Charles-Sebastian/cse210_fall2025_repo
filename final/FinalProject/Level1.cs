public class Level1 : Encryption
{
    public Level1(string pS) : base(1, pS)
    {
        RunEncryption();
    }

    protected override void RunEncryption()
    {
        EncryptString();
        EmbedId();
        EmbedIncriment();
    }
}