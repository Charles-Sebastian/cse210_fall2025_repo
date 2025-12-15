public abstract class Key
{
    private List<char> _key;

    protected Key()
    {

    }

    public abstract string CallType();
    protected void SetKey(List<char> key)
    {
        _key = key;
    }
    public List<char> GetKey()
    {
        return _key;
    }
}