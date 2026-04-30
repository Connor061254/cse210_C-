using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is the magic number? ");
        string number = Console.ReadLine();
        int int_number = int.Parse(number);
        Console.WriteLine("What is your guess? ");
        string response = Console.ReadLine();
        int int_response = int.Parse(response);

        while(int_response != int_number)
        {
            if (int_response < int_number)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("Lower");
            }

            Console.WriteLine("What is your guess? ");
            string nextGuess = Console.ReadLine();
            int intNextGuess= int.Parse(nextGuess);
            int_response = intNextGuess;
            
        }

        if(int_response == int_number)
        {
            Console.WriteLine("You Guessed it!");
        }
    }
}