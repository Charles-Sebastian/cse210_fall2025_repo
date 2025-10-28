using System.Diagnostics;

public class Word
{
    private string _word;
    private string _hiddenWord;
    private bool _hidden;

    public Word(string word)
    {
        _word = word;
        
        foreach (char character in word)
        {
            if (char.IsLetterOrDigit(character) == true)
            {
                _hiddenWord += "_";
            }
            else
            {
                _hiddenWord += character;
            }
        }

        _hidden = false;
    }

    public void HideWord()
    {
        _hidden = true;
    }
    public int DisplayWord()
    {
        if (_hidden == false)
        {
            Console.Write(_word);
            return 0;
        }
        else
        {
            Console.Write(_hiddenWord);
            return 1;
        }
    }
}