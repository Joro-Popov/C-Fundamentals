using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    private static void Main()
    {
        try
        {
            List<string> studentInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> workerInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Student student = new Student(studentInfo[0],
                                          studentInfo[1],
                                          studentInfo[2]);

            Worker worker = new Worker(workerInfo[0],
                                       workerInfo[1],
                                       decimal.Parse(workerInfo[2]),
                                       decimal.Parse(workerInfo[3]));
            Console.WriteLine(student);
            Console.WriteLine(worker);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}