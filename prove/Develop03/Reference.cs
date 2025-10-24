public class Reference
{
    private string _book;
    private int _chapter;
    private int _fVerse;
    private int _lVerse;

    public Reference(string book, int chapter, int fVerse, int lVerse)
    {
        _book = book;
        _chapter = chapter;
        _fVerse = fVerse;
        _lVerse = lVerse;
    }
    public Reference(string book, int chapter, int fVerse)
    {
        _book = book;
        _chapter = chapter;
        _fVerse = fVerse;
    }

    public string CompileReference()
    {
        string reference;
        reference = $"{_book} {_chapter}:{_fVerse}";
        if (_lVerse > 0)
        {
            reference = reference + $"-{_lVerse}";
        }

        return reference;
    }
}