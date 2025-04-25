//QB1: Seller & Buyer Processes using FIFO Scheduling

using System;
using System.Collections.Generic;
using System.Threading;

namespace SystemProgramming
{
    class Program
    {
        // 定义一个共享的队列，用于存储项目列表
        private static Queue<List<string>> itemQueue = new Queue<List<string>>();
        // 定义两个信号量，用于同步Seller和Buyer
        private static SemaphoreSlim sellerSemaphore = new SemaphoreSlim(0, 1); // 初始为0，最大为1
        private static SemaphoreSlim buyerSemaphore = new SemaphoreSlim(0, 1);  // 初始为0，最大为1

        static void Main(string[] args)
        {
            // 创建Seller和Buyer线程
            Thread sellerThread = new Thread(new ThreadStart(Seller));
            Thread buyerThread = new Thread(new ThreadStart(Buyer));

            // 启动线程
            sellerThread.Start();
            buyerThread.Start();

            // 等待线程完成
            sellerThread.Join();
            buyerThread.Join();
            Console.ReadKey(); 
        }

        static void Seller()
        {
            // 创建一个项目列表
            List<string> items = new List<string> { "Item1", "Item2", "Item3" };

            // 将项目列表添加到队列中
            lock (itemQueue)
            {
                itemQueue.Enqueue(items);
                Console.WriteLine("Seller: Item list sent to Buyer.");
            }

            // 释放buyerSemaphore，通知Buyer项目列表已经准备好
            buyerSemaphore.Release();

            // 等待Buyer处理完项目列表
            sellerSemaphore.Wait();

            // 打印项目列表
            Console.WriteLine("Seller: Printing item list.");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        static void Buyer()
        {
            // 等待Seller发送项目列表
            buyerSemaphore.Wait();

            // 从队列中获取项目列表
            List<string> items = null;
            lock (itemQueue)
            {
                if (itemQueue.Count > 0)
                {
                    items = itemQueue.Dequeue();
                    Console.WriteLine("Buyer: Item list received.");
                }
            }

            // 处理项目列表
            if (items != null)
            {
                Console.WriteLine("Buyer: Announcing item list.");
                foreach (var item in items)
                {
                    Console.WriteLine(item);
                }
            }

            // 释放sellerSemaphore，通知Seller项目列表已经处理完
            sellerSemaphore.Release();
        }
    }
}


