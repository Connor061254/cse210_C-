using System;

class Program
{
    static void Main(string[] args)
    {
        Job Job1 = new Job();
        Job1._jobTitle = "Software Engineer";
        Job Job2 = new Job();
        Job2._jobTitle = "Lead Engineer";

        Job1.Display(Job1._jobTitle, Job2._jobTitle);
    }
}