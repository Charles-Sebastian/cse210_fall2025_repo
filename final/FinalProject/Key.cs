public abstract class Key
{
    private List<char> _key;

    public Key()
    {

    }

    public abstract string CallType();
    public void SetKey(List<char> key)
    {
        _key = key;
    }
    public List<char> GetKey()
    {
        return _key;
    }
}