// Midterm Q2: manage consumer and producer issue for 5 consumers and 2 producers using semaphore.

using System;
using System.Collections.Generic;
using System.Threading;

namespace MidtermQuestion2
{
    class Program
    {
        // define a shared queue for storage
        private static Queue<int> itemQueue = new Queue<int>();
        // define semaphores for thread synchronization
        private static SemaphoreSlim emptySlots = new SemaphoreSlim(10);  // max 10
        private static SemaphoreSlim fullSlots = new SemaphoreSlim(0);    // initial 0
        private static object queueLock = new object();                   // lock for queue

        static void Main(string[] args)
        {
            // create the producer thread
            Thread[] producers = new Thread[2];
            // start the producer thread in order
            for (int i = 0; i < producers.Length; i++)
            {
                producers[i] = new Thread(new ThreadStart(Producer));
                producers[i].Start();
            }

            // create the consumer thread
            Thread[] consumers = new Thread[5];
            // start the consumer thread in order
            for (int i = 0; i < consumers.Length; i++)
            {
                consumers[i] = new Thread(new ThreadStart(Consumer));
                consumers[i].Start();
            }

            // wait for all threads done
            foreach (var producer in producers)
            {
                producer.Join();
            }
            foreach (var consumer in consumers)
            {
                consumer.Join();
            }
            Console.ReadKey();
        }

        static void Producer()
        {
            Random rand = new Random();
            for (int i = 0; i < 5; i++) // each one produces 5 products
            {
                int item = rand.Next(9); // product ID is random 

                // wait for the avaible unit
                emptySlots.Wait();

                // add to queue
                lock (queueLock)
                {
                    itemQueue.Enqueue(item);
                    Console.WriteLine($"Producer {Thread.CurrentThread.ManagedThreadId} produced item: {item}");
                }

                // release an unit
                fullSlots.Release();

                Thread.Sleep(rand.Next(100)); // simulate the producting time 
            }
        }

        static void Consumer()
        {
            for (int i = 0; i < 10; i++) // each one consumes 10 product
            {
                // wait for semaphore
                fullSlots.Wait();

                int item;
                // get the product from queue
                lock (queueLock)
                {
                    item = itemQueue.Dequeue();
                    Console.WriteLine($"Consumer {Thread.CurrentThread.ManagedThreadId} consumed item: {item}");
                }

                // release an unit
                emptySlots.Release();

                Thread.Sleep(new Random().Next(100));  // simulate the consuming time
            }
        }
    }
}