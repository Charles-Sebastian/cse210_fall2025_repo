public class Word
{
    private string _word;
    private bool _hidden;

    public Word(string word)
    {
        _word = word;
        _hidden = false;
    }

    public void HideWord()
    {
        _hidden = true;
    }
    public bool GetStatus()
    {
        return _hidden;
    }
    public string GetWord()
    {
        return _word;
    }
}