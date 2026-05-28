public class Word
{
    private string _text;
    private bool _isHidden;

    public bool IsHidden
    {
        get
        {
            return _isHidden;
        }
        set
        {
            if(_isHidden == true && value == false)
            {
                return;
            }

            _isHidden = value;
        }
    }
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length);
        }
        return _text;
    }
}