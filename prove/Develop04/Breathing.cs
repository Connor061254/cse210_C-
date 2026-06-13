using System.IO.Pipelines;
using System.Threading;

public class Breathing : Program
{
public override void RunActivity()
    {
        _intro = "Welcome to the Breathing Activity";
        _description = "This Activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";


         string result = Activity(_intro, _description);

         Console.WriteLine($"{result}");
         Console.WriteLine(" ");
         Console.WriteLine($"{_timeQuestion}");
         _durationInSeconds = int.Parse(Console.ReadLine());
        
         LoadingAnimation(5);
         _endTime = DateTime.Now.AddSeconds(_durationInSeconds);

         while(DateTime.Now < _endTime)
        {
            BreatheIn();
            Console.WriteLine(" ");
            BreatheOut();
            Console.WriteLine(" ");
        }

        EndActivity("Breathing", _durationInSeconds);

        
         
    }

    private void BreatheIn()
    {
        Console.Write("Breathe in...");
        for(int i = 4; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    private void BreatheOut()
    {
        Console.Write("Breathe out...");
         for(int i = 6; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

}