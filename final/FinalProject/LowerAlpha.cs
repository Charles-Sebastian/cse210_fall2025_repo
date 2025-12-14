public class LowerAlpha : Cypher
{
    private List<char> _cypher = new List<char>();
    private char _cypherId;
    public LowerAlpha(char id, char cypherId = '\0') : base(id)
    {
        GenerateCypher(cypherId);
    }

    private void GenerateCypher(char cypherId)
    {
        int cypher = -1;

        List<char> cypher1 = ['q', 'k', 'x', 'g', 'o', 'r', 't', 'a', 'y', 's', 'c', 'b', 'v', 'z', 'p', 'e', 'w', 'l', 'm', 'u', 'f', 'j', 'h', 'i', 'n', 'd'];
        List<char> cypher2 = ['h', 'u', 'j', 'e', 'd', 't', 'y', 'm', 'r', 'n', 'c', 'p', 'b', 'w', 'l', 'i', 'v', 'x', 'a', 'q', 'o', 'z', 's', 'k', 'f', 'g'];
        List<char> cypher3 = ['z', 'f', 'm', 'h', 'p', 'b', 'u', 'x', 'q', 'v', 'i', 'o', 'd', 'c', 's', 'a', 'w', 't', 'l', 'g', 'e', 'n', 'y', 'r', 'k', 'j'];

        List<List<char>> cyphers = [cypher1, cypher2, cypher3];
        List<char> cypherIds = ['a', 'b', 'c'];

        if (cypherId == '\0')
        {
            Random random = new Random();
            int randomCypher = random.Next(0, 3);
            cypher = randomCypher;
        }
        else
        {
            cypher = cypherIds.IndexOf(cypherId);
        }

        _cypher = cyphers[cypher];
        _cypherId = cypherIds[cypher];
        // Console.WriteLine("ABCL Cypher Generated");
    }
    public override char GetCypherId()
    {
        return _cypherId;
    }
    public override List<char> GetCypher()
    {
        return _cypher;
    }
}