public class UpperAlpha : Cypher
{
    private List<char> _cypher = new List<char>();
    private char _cypherId;
    public UpperAlpha(char id, char cypherId = '\0') : base(id)
    {
        GenerateCypher(cypherId);
    }

    private void GenerateCypher(char cypherId)
    {
        int cypher = -1;

        List<char> cypher1 = ['Q', 'L', 'F', 'S', 'X', 'O', 'A', 'D', 'Z', 'E', 'J', 'P', 'W', 'C', 'U', 'V', 'Y', 'K', 'R', 'T', 'B', 'G', 'I', 'H', 'N', 'M'];
        List<char> cypher2 = ['T', 'W', 'A', 'Y', 'L', 'Q', 'X', 'H', 'S', 'F', 'N', 'C', 'Z', 'P', 'B', 'D', 'U', 'I', 'J', 'G', 'O', 'K', 'V', 'R', 'M', 'E'];
        List<char> cypher3 = ['N', 'B', 'P', 'G', 'M', 'I', 'E', 'U', 'J', 'O', 'S', 'F', 'A', 'T', 'H', 'Q', 'C', 'Z', 'X', 'R', 'K', 'V', 'W', 'Y', 'D', 'L'];

        List<List<char>> cyphers = [cypher1, cypher2, cypher3];
        List<char> cypherIds = ['A', 'B', 'C'];

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