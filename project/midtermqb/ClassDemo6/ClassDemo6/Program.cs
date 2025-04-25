// Class Demo6: Solving the critical region problem using Lock for two functions

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace ThreadSample2
{
    class Program
    {
        private static bool b = false;
        static bool Done = false;
        static object Locker = new object();
        static void Main(string[] args)
        {
            Thread FirestThread = new Thread(PrintX);
            Thread SecondThread = new Thread(PrintY);
            FirestThread.Start();
            SecondThread.Start();
            Console.ReadKey();
        }
        static void PrintX()
        {
            for (int i = 0; i < 100; i++)
            {
                Go();
                Console.Write('X');
                Done = false;
            }
        }
        static void PrintY()
        {
            for (int i = 0; i < 100; i++)
            {
                Go();
                Console.Write('Y');
                Done = false;
            }
        }
        static void Go()
        {
            lock (Locker)
            {
                if (!Done)
                {
                    Thread.Sleep(1);
                    Done = true;
                }
            }
        }
    }
}



