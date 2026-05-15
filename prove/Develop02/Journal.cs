using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public class Journal
{
    public int response;

    public string promptResponse;
    List<Entry> myJournalList = new List<Entry>();
    
    private List<string> prompts = new List<string>
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
            string currentPrompt = GetRandomPrompt();
            Console.WriteLine($"{currentPrompt}");
            promptResponse = Console.ReadLine();
            
            Entry todayForm = new Entry();

            todayForm.date = DateTime.Now.ToShortDateString();
            todayForm.promptText = currentPrompt;
            todayForm.entryText = promptResponse;
            myJournalList.Add(todayForm);
        }
        
        if(response == 2)
        {
            DisplayAll();
        }
        
        if(response == 3)
        {
            LoadFile();
        }

        if(response == 4)
        {
            SaveToFile();
            Console.WriteLine("Journal Succesfully Saved");
        }
    }

    public void DisplayAll()
    {
        foreach(Entry currentEntry in myJournalList)
        {
            currentEntry.Display();
        }
    }

    public void SaveToFile()
    {
        Console.WriteLine("What is the filename? ");
        string filename = Console.ReadLine();

        using(StreamWriter writer = new StreamWriter(filename))
        {
            foreach(Entry currentEntry in myJournalList)
            {
                writer.WriteLine($"{currentEntry.date}|{currentEntry.promptText}|{currentEntry.entryText}");
            }
        }
    }

    public void LoadFile()
    {
        Console.WriteLine("What is the filename? ");
        string filename = Console.ReadLine();

        myJournalList.Clear();  

        using(StreamReader reader = new StreamReader(filename))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split("|");

                Entry loadedEntry = new Entry();

                loadedEntry.date = parts[0];
                loadedEntry.promptText = parts[1];
                loadedEntry.entryText = parts[2];

                myJournalList.Add(loadedEntry);
            }
        }
    }
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}