public class DLevel1 : Decryption
{
    public DLevel1(string pS) : base(pS)
    {
        RunDecryption();
    }

    protected override void RunDecryption()
    {
        ExtractIncriment();
        ExtractId();
        Compile(GetCyphers(GetId()), GetKeys());
        Decrypt();
    }
}