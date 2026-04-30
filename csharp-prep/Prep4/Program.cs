using System;
using System.Globalization;
using System.Numerics;
using System.Transactions;

class Program
{
    
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished");

        int input = 1;

        while(input != 0)
        {
            Console.WriteLine("Enter a number: ");

            if (int.TryParse(Console.ReadLine(), out input))
            {
               if(input != 0)
                {
                    numbers.Add(input);
                }
            }
            else
            {
                Console.WriteLine("Please enter a number value");
            }
        }

        int total = 0;
        foreach(int num in numbers)
        {
            total += num;
        }

        Console.WriteLine($"You entered {total}");
            
    }
}