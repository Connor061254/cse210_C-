using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage?");
        string gradePercentage = Console.ReadLine();

        int strToInt = int.Parse(gradePercentage);

        if (strToInt >= 90)
        {
            Console.Write("A");
        }
        else if (strToInt >= 80)
        {
            Console.Write("B");
        }
        else if(strToInt >= 70)
        {
            Console.Write("C");
        }
        else if (strToInt >= 60)
        {
            Console.Write("D");
        }
        else
        {
            Console.Write("F");
        }


    }
}