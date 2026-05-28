using System;
using System.Dynamic;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture("Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.");
        string response = "";
       
        while (response.ToLower() != "quit" && !scripture.isCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine($"Proverbs 3:5-6: {scripture.GetDisplayText()}");
            Console.WriteLine("Press q to continue or enter 'quit' to exit");
            response = Console.ReadLine();

            if(response.ToLower() != "quit")
            {
                scripture.HideRandomWords(3);
            }
            
        }
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("Goodbye!");
        
        
    }
}