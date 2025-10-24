public class Scripture
{
    private List<Word> _words = new List<Word>();
    private Reference _reference = new Reference("", 0, 0);
    private List<int> _hiddenWords = new List<int>();
    Random _random = new Random();

    public Scripture(string reference, List<string> scripture)
    {
        foreach (string newWord in scripture)
        {
            _words.Add(new Word(newWord));
        }

        bool spaceFound = false;
        bool characterIsSpecial = false;
        bool colonFound = false;
        bool dashFound = false;
        string book = "";
        string chapter = "";
        string fVerse = "";
        string lVerse = "";
        foreach (char character in reference)
        {
            if (character.ToString() == " ")
            {
                spaceFound = true;
                characterIsSpecial = true;
            }
            else if (character.ToString() == ":")
            {
                colonFound = true;
                characterIsSpecial = true;
            }
            else if (character.ToString() == "-")
            {
                dashFound = true;
                characterIsSpecial = true;
            }

            if (spaceFound == false && colonFound == false && dashFound == false)
            {
                book += character;
            }
            else if (characterIsSpecial == false && colonFound == false && dashFound == false)
            {
                chapter += character;
            }
            else if (characterIsSpecial == false && dashFound == false)
            {
                fVerse += character;
            }
            else if (characterIsSpecial == false)
            {
                lVerse += character;
            }

            characterIsSpecial = false;
        }

        if (lVerse != "")
        {
            _reference = new Reference(book, int.Parse(chapter), int.Parse(fVerse), int.Parse(lVerse));
        }
        else
        {
            _reference = new Reference(book, int.Parse(chapter), int.Parse(fVerse));
        }
    }

    public void Hide()
    {
        Console.Clear();
        int hideWord;
        bool validHide = false;
        int wordsRemaining = _words.Count() - _hiddenWords.Count();
        int wordsToHide = 0;
        if (wordsRemaining < 3)
        {
            wordsToHide = wordsRemaining;
        }
        else
        {
            wordsToHide = 3;
        }

        for (int i = 0; i < wordsToHide; i += 1)
        {
            validHide = false;
            do
            {
                hideWord = _random.Next(_words.Count);

                if (_hiddenWords.Contains(hideWord) == false)
                {
                    validHide = true;
                }
            } while (validHide == false);

            _hiddenWords.Add(hideWord);
            _words[hideWord].HideWord();
        }
    }
    public void Display(int iteration)
    {
        Console.Write($"{_reference.CompileReference()} ");

        foreach (Word word in _words)
        {
            if (iteration < 2)
            {
                Console.Write($"{word.GetWord()} ");
            }
            else
            {
                if (word.GetStatus() == false)
                {
                    Console.Write($"{word.GetWord()} ");
                }
                else
                {
                    foreach (char character in word.GetWord())
                    {
                        if (char.IsLetter(character) == true || char.IsDigit(character) == true)
                        {
                            Console.Write("_");
                        }
                        else
                        {
                            Console.Write(character);
                        }
                    }

                    Console.Write(" ");
                }
            }
        }

        Console.WriteLine();
    }
}