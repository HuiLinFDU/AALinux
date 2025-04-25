using System;
using System.Threading;

namespace CourseThreads
{
    class Program
    {
        static string[] courses = { "CSCI6751AI", "CSCI7850UI", "CSCI7645SP" };
        
        static Thread[] threads = new Thread[courses.Length];

        static void Main(string[] args)
        {
            Console.WriteLine("New semester is coming.");

            for (int i = 0; i < courses.Length; i++)
            {
                int index = i; 
                threads[i] = new Thread(() => PrintCourse(index));
                threads[i].Start();
            }

            Console.WriteLine("On Tuesday I have ");
            //threads[0].Start();
            threads[0].Join();
            Console.WriteLine("On Friday I have ");
            //threads[1].Start();
            threads[1].Join();
            Console.WriteLine("On Saturday I have ");
            //threads[2].Start();
            threads[2].Join();

            Console.WriteLine("My courses have been printed in order.");
        }

        static void PrintCourse(int index)
        {
            int stime = (index+1) * 10000;
            Thread.Sleep(stime);
            Console.WriteLine($"   the Course: {courses[index]}");
        }
    }
}