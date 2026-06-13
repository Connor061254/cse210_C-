using System;
public class MathAssignment : Assignment
{
    public string _textbookSection {get; set;}

    public string _problems {get; set;}
    public MathAssignment(string name, string topic, string section, string problems)
    {
        _studentName = name;
        _topic = topic;
        _problems = problems;
        _textbookSection = section;
    }
}