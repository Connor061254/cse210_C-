using System;

public class Program
{
    private static int _response;

    static GoalManager goalManager = new GoalManager();
    private static bool _isRunning = true;
    static void Main(string[] args)
    {
    
        while (_isRunning == true)
        {
            Menu();

            if(_response == 1)
            {
                goalManager.DefineGoal();
            }
            if(_response == 2)
            {
                goalManager.ListGoals();
            }
            if(_response == 3)
            {
                goalManager.SaveGoals();
            }
            if(_response == 4)
            {
                goalManager.LoadGoals();
            }
            if(_response == 5)
            {
                goalManager.RecordEvent();
            }
            else if(_response == 6)
            {
                _isRunning = false;
            }
            
        }
    }
    static void Menu()
    {
        Console.WriteLine($"""
        You have {goalManager._points} points

        Menu Options:
        1. Create New Goal
        2. List Goals
        3. Save Goals
        4. Load Goals
        5. Record Event
        6. Quit
        Select a choice from the menu: 
        """);

        _response = int.Parse(Console.ReadLine());
    }

}

public class GoalManager
{
    public int _points {get; set;}
    List<Goal> goals = new List<Goal>();
    protected bool _isDone;
    public void DefineGoal()
    {
        Console.WriteLine("""
        The types of goals are:
        1. Simple Goal
        2. Eternal Goal
        3. Checklist Goal
        Which type of goal would you like to create? 
        """);
        int type = int.Parse(Console.ReadLine());
        
        Console.WriteLine("What is the name of your goal? ");

        string name = Console.ReadLine();

        Console.WriteLine("What is a short description of it? ");

        string description = Console.ReadLine();

        Console.WriteLine("What is the amount of points associated with this goal? ");

        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case 1:
            SimpleGoal simpleGoal = new SimpleGoal(name, points, description);
            goals.Add(simpleGoal);
            break;

            case 2:
            EternalGoal eternalGoal = new EternalGoal(name, points, description);
            goals.Add(eternalGoal);
            break;

            case 3:
            Console.WriteLine("What is the target amount? ");
            int target = int.Parse(Console.ReadLine());
            ChecklistGoal checklistGoal = new ChecklistGoal(name, points, description, target);
            goals.Add(checklistGoal);
            break;
        }
    }

    public void ListGoals()
    {
        Console.WriteLine("The goals are: ");
        
        int n = 1;

        foreach(Goal i in goals)
        {
           Console.WriteLine($"{n}. {i.GetDetailString()}");
           n++;
            
        }
    }

    public void SaveGoals()
    {
        Console.WriteLine("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputfile = new StreamWriter(filename))
        {
            outputfile.WriteLine("My Goals File");

            foreach (Goal i in goals)
            {
                if(i is ChecklistGoal checklistGoal)
                {
                    outputfile.WriteLine($"{i}, {i._name}, {i._description}, {i._points}, {checklistGoal.GetDetailsForSaving()}");
                }
                else
                {
                    outputfile.WriteLine($"{i}, {i._name}, {i._description}, {i._points}");
                }
                
            }
        }
    }

    public void LoadGoals()
    {
        Console.WriteLine("what is the file name? ");
        string filename = Console.ReadLine();

        using(StreamReader reader = new StreamReader(filename))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(",");

                string goalType = parts[0];
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                if(goalType == "SimpleGoal")
                {
                    SimpleGoal simpleGoal = new SimpleGoal(name, points, description);
                    goals.Add(simpleGoal);
                }
                else if(goalType == "EternalGoal")
                {
                    EternalGoal eternalGoal = new EternalGoal(name, points, description);
                    goals.Add(eternalGoal);
                }
                else if(goalType == "ChecklistGoal")
                {
                    int targetGoal = int.Parse(parts[4]);
                    ChecklistGoal checklistGoal = new ChecklistGoal(name, points, description, targetGoal);
                    goals.Add(checklistGoal);
                }
            }
        }
    }

    public void RecordEvent()
    {
        ListGoals();

        Console.WriteLine("Which Goal did you accomplish? ");
        int i = int.Parse(Console.ReadLine());

        if(i > 0 && i <= goals.Count)
        {
            Goal selectedGoal = goals[i - 1];

            _points += selectedGoal._points;

            selectedGoal.RecordEvent();

            Console.WriteLine($"Congratulations! You have earned {selectedGoal._points} points! ");
        }
    }
}