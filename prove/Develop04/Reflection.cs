using System.Diagnostics;
using System.IO.Pipelines;

public class Reflection : Program
{
    List<string> prompts = [
        "Think of a time when you stood up for someone else",
        "Think of a time when you did something really difficult",
        "Think of a time when you helped someone in need",
        "Think of a time when you did something truly selfless"
    ];

    List<string> questions = [
        "How did you feel when it was complete?",
        "What is your favorite thing about this experience?",
        "Was it difficult doing this?",
        "Why was this experience meaningful to you",
        "How could you learn from this experience"
    ];
    private string response;
    public override void RunActivity()
    {
        _intro = "welcome to the reflecting Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will hlep you recognize the power you have and how you can use it in other aspects of your life.";
        string result = Activity(_intro, _description);

        Console.WriteLine(result);
        Console.WriteLine(" ");
        Console.WriteLine(_timeQuestion);
        _durationInSeconds = int.Parse(Console.ReadLine());
        Console.Clear();

        InitialPrompt();

        

        if(response == "q")
        {
            Console.WriteLine(" ");
            Console.WriteLine("Now Ponder on each of the following questions as they relate to this experience.");
            BeginTimer();
            Console.Clear();
            DateTime time = DateTime.Now;
            while(DateTime.Now < time.AddSeconds(_durationInSeconds))
            {
                string question = GetRandomQuestion();
                Console.WriteLine(question);
                LoadingAnimation(10);
            }

            EndActivity("Reflection", _durationInSeconds);
            



        }
        else
        {
            Console.WriteLine("please enter a valid response.");
            return;

        }
    }

    private void InitialPrompt()
    {
        Console.WriteLine("Get ready...");
        LoadingAnimation(4);
        Console.WriteLine(" ");
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine(" ");
        string propmt = GetRandomPrompt();
        Console.WriteLine($"---{propmt}---");
        Console.WriteLine(" ");
        Console.WriteLine("When you have something in mind, enter q to continue");
        response = Console.ReadLine();
    }

    private string GetRandomPrompt()
    {
        int index = GetRandom(prompts);
        return prompts[index];
    }

    private string GetRandomQuestion()
    {
        int index = GetRandom(questions);
        return questions[index];
    }

    private void BeginTimer()
    {
        Console.Write("You may begin in: ");
        for(int i = 5; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

}