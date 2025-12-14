public class Number : Cypher
{
    private List<char> _cypher = new List<char>();
    private char _cypherId;
    public Number(char id, char cypherId = '\0') : base(id)
    {
        GenerateCypher(cypherId);
    }

    private void GenerateCypher(char cypherId)
    {
        int cypher = -1;

        List<char> cypher1 = ['7', '3', '9', '1', '4', '0', '8', '6', '5', '2'];
        List<char> cypher2 = ['4', '0', '7', '9', '2', '8', '1', '3', '6', '5'];
        List<char> cypher3 = ['2', '8', '6', '5', '3', '9', '0', '4', '1', '7'];

        List<List<char>> cyphers = [cypher1, cypher2, cypher3];
        List<char> cypherIds = ['1', '2', '3'];

        if (cypherId == '\0')
        {
            Random random = new Random();
            int randomCypher = random.Next(0, 3);
            cypher = randomCypher;
            // Console.WriteLine("Selecting Random Cypher");
        }
        else
        {
            cypher = cypherIds.IndexOf(cypherId);
        }

        _cypher = cyphers[cypher];
        _cypherId = cypherIds[cypher];
        // Console.WriteLine("NUM Cypher Generated");
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