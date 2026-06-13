using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

public class Program
{
    protected static string _intro;
    protected string _description;

    protected int _durationInSeconds;

    protected DateTime _startTime = DateTime.Now;

    protected DateTime _endTime;

    protected string _timeQuestion = "How long in seconds, would you like for your session?";

    protected string _activityName;
    static void Main(string[] args)
    {
        Breathing breathing = new Breathing();
        Reflection reflection = new Reflection();
        Listing listing = new Listing();
       
       bool keepRunning = true;

        while (keepRunning)
        {
            Console.WriteLine("Hello, Please select Which Activity you would like to do:");
            Console.WriteLine(Menu());

            string response = Console.ReadLine();
            int int_response = int.Parse(response);

       
             if(int_response == 1)
             {
                Console.Clear();
                breathing.RunActivity();
             }
            else if(int_response == 2)
             {
                 Console.Clear();
               reflection.RunActivity();
             }
            else if(int_response == 3)
             {
                 Console.Clear();
                listing.RunActivity();
             }
            else
             {
                return;
             }
        }
       
        
    }

    public virtual void RunActivity()
    {

    }

    public void EndActivity(string name, int time)
    {
        _activityName = name;
        _durationInSeconds = time;
        Console.WriteLine("Well done!!");
        LoadingAnimation(4);
        Console.WriteLine(" ");
        Console.WriteLine($"you have completed {_durationInSeconds} seconds of the {_activityName} Activity");
        LoadingAnimation(4);
        Console.Clear();
    }

    public string Activity(string name, string description)
    {
        string activity = $"""
        {name} 
        
        {description}
        """;
        return activity;
    }

    public static string Menu()
    {
        string menu = """
        Menu Options:
        1: Breathing Activity
        2: Reflection Activity
        3: Listing Activity
        4: quit
        """;     
        return menu;  
    }

    public void LoadingAnimation(int duration)
    {
         _endTime = DateTime.Now.AddSeconds(duration);

         List<string> animationStrings = new List<string>();
         animationStrings.Add("|");
         animationStrings.Add("/");
         animationStrings.Add("-");
         animationStrings.Add("\\");
         animationStrings.Add("|");
         animationStrings.Add("/");
         animationStrings.Add("-");
         animationStrings.Add("\\");

         int i = 0;
         
         while(DateTime.Now < _endTime)
        {
            string s = animationStrings[i];
            Console.Write(s);
            Thread.Sleep(300);
            Console.Write("\b \b");
            i++;    
            
            if(i >= animationStrings.Count)
            {
                i = 0;
            }
        }
    }

    public int GetRandom(List<string> strings)
    {
        Random random = new Random();
        int index = random.Next(strings.Count);
        return index;
    }
}