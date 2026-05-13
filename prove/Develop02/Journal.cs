using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public class Journal
{
    public int response;

    private List<string> entries = new List<string>
        {
            "Who was the most interesting person I met today?",
            "What was the best part of my day?",
            "What was the strongest emotion I felt today?",
            "How did I see the hand of the Lord in my life today?",
            "If I had one thing I could do over today, what would it be?"
        };
    public void Run()
    {
        Console.WriteLine("Please select one of the following choices: ");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
        Console.WriteLine("What would you like to do? ");
        response = int.Parse(Console.ReadLine()); 
    } 
    public void HandleResponse()
    {
        if(response == 1)
        {
              Console.WriteLine($"{GetRandomPrompt()}");
        }
    }
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(entries.Count);
        return entries[index];
    }
}