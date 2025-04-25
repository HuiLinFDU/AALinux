// MidTerm Question 1: The cat and mouse simulation

using System;
using System.Threading;

namespace MidTermQuestion1
{
    class Program
    {
        // define semaphore for cat and mouse thread
        static SemaphoreSlim catSemaphore = new SemaphoreSlim(0, 1);
        static SemaphoreSlim mouseSemaphore = new SemaphoreSlim(0, 1);

        static void Main(string[] args)
        {
            // create the cat thread
            Thread catCreatorThread = new Thread(new ThreadStart(CreateCatThreads));
            // start the cat thread
            catCreatorThread.Start();

            // create the mouse thread
            Thread mouseCreatorThread = new Thread(new ThreadStart(CreateMouseThreads));
            // start the mouse thread
            mouseCreatorThread.Start();

            // wait for all threads finally done
            catCreatorThread.Join();
            mouseCreatorThread.Join();

            Console.ReadKey();
        }

        static void CreateCatThreads()
        {
            string[] catNames = { "Tom", "John", "Bond" };
            string catFood = "Fish";

            foreach (var name in catNames)
            {
                Thread catThread = new Thread(() => PrintInfo(name, catFood, catSemaphore, mouseSemaphore));
                catThread.Start();
                catThread.Join(); 
            }
        }

        static void CreateMouseThreads()
        {
            string[] mouseNames = { "Jerry", "Gerry", "Kerry" };
            string mouseFood = "Cheese";

            foreach (var name in mouseNames)
            {
                Thread mouseThread = new Thread(() => PrintInfo(name, mouseFood, mouseSemaphore, catSemaphore));
                mouseThread.Start();
                mouseThread.Join(); 
            }
        }

        static void PrintInfo(string name, string food, SemaphoreSlim mySemaphore, SemaphoreSlim otherSemaphore)
        {
            for (int i = 0; i < 3; i++)
            {
                mySemaphore.Wait(); // wait for the semaphore
                Console.WriteLine($"{name} likes {food}");
                Thread.Sleep(500); // just for simulating some handling
                otherSemaphore.Release(); // release the semaphore
            }
        }
    }
}
