public abstract class Cypher
{
    private char _typeId;

    protected Cypher(char id)
    {
        _typeId = id;
    }

    public char GetId()
    {
        return _typeId;
    }

    public abstract char GetCypherId();
    public abstract List<char> GetCypher();
}