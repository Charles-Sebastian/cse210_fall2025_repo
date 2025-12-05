public class Symbol : Cypher
{
    private List<char> _cypher = new List<char>();
    private char _cypherId;
    public Symbol(char id) : base(id)
    {
        GenerateCypher();
    }

    private void GenerateCypher(char cypherId = '\0')
    {
        int cypher = -1;

        List<char> cypher2 = ['+', ']', '(', '}', '<', '!', '`', '_', '@', '*', '~', '$', '/', '?', '%', '[', ' ', '^', '>', '&', ',', '{', '-', ';', ')', ':', '=', '#', '.'];
        List<char> cypher1 = [':', '%', '<', ']', '(', '}', '+', '~', ',', '/', '_', '&', '`', '@', '-', '>', '*', '!', '{', '^', '?', ')', '$', '[', ' ', '=', '#', '.', ';'];
        List<char> cypher3 = ['@', ';', '(', '<', '`', '~', '}', '^', '/', '!', ' ', '*', '[', '?', '=', ')', '.', '_', '%', '#', '-', ']', '+', '&', '{', ':', '>', ',', '$'];

        List<List<char>> cyphers = [cypher1, cypher2, cypher3];
        List<char> cypherIds = ['!', '#', '$'];

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
        // Console.WriteLine("SYM Cypher Generated");
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