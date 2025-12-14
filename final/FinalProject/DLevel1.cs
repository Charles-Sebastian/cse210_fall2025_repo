public class DLevel1 : Decryption
{
    public DLevel1(string pS) : base(pS)
    {
        RunDecryption();
    }

    public override void RunDecryption()
    {
        ExtractIncriment();
        ExtractId();
        Compile(GetCyphers(), GetKeys());
        Decrypt();
    }
}