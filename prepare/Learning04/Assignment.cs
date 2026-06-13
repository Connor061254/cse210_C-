using System;
public class Assignment
{
        public string _studentName {get; set;}
        public string _topic {get; set;}

        public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}