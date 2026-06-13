using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        EnglishAssignment EAssignment = new EnglishAssignment();
        Assignment assignment = new Assignment();
        MathAssignment math = new MathAssignment("Roberto", "Fractions", "Section 7.3", "Problems 8-19");
        assignment._studentName = "John";
        assignment._topic = "Multiplication";
        

        string summary = assignment.GetSummary();
        Console.WriteLine($"{math._topic}");


    }
}