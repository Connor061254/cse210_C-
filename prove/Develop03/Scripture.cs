using System.Dynamic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

public class Scripture
{
    private List<Word> _words = new List<Word>();
    private Random _random = new Random();

    public Scripture(string text)
    {
        string[] splitWords = text.Split(' ');
        foreach(string wordText in splitWords)
        {
            _words.Add(new Word(wordText));
        }
    }

    public string GetDisplayText()
    {
        List<string> displayWords = new List<string>();
        foreach(Word word in _words)
        {
            displayWords.Add(word.GetDisplayText());
        }
        return string.Join(" ", displayWords);
    }

    public void HideRandomWords(int numberToHide)
    {
        List<Word> visibleWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (word.IsHidden == false)
            {
                visibleWords.Add(word);
            }
        }

        if (visibleWords.Count == 0) return;

        int hiddenCount = 0;
        while (hiddenCount < numberToHide && visibleWords.Count > 0)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].IsHidden = true;
            visibleWords.RemoveAt(index);
            hiddenCount++;
        }
    }

    public bool isCompletelyHidden()
    {
        foreach(Word word in _words)
        {
            if(word.IsHidden == false)
            {
                return false;
            }
        }
        return true;
    }
}