using System;
using System.Net;

class Program
{
    public static int userResponse;
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        
        Console.WriteLine("Welcome to the Journal Program!");
        
        while(userResponse != 5)
        {
            myJournal.Run();
            userResponse = myJournal.response;
            myJournal.HandleResponse();

        }
        
        Console.WriteLine("You have quit the program");
    }   
}