//QB4: State the Solution for Critical Section Problem.

using System;
using System.Threading;

namespace CriticalSectionProblem
{
    class Program
    {
        // 定义一个信号量，用于控制对临界区的访问
        private static SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
        // 定义一个共享的计数器
        private static int counter = 0;

        static void Main(string[] args)
        {
            // 创建并启动多个线程
            Thread[] threads = new Thread[5];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(new ThreadStart(CriticalSection));
                threads[i].Start();
            }

            // 等待所有线程完成
            foreach (var thread in threads)
            {
                thread.Join();
            }

            // 打印最终计数器值
            Console.WriteLine($"Final counter value: {counter}");

            Console.ReadKey();
        }

        static void CriticalSection()
        {
            for (int i = 0; i < 10; i++)
            {
                // 进入临界区
                semaphore.Wait();

                try
                {
                    // 临界区代码
                    int temp = counter;
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} reading counter: {temp}");
                    temp++;
                    Thread.Sleep(10); // 模拟一些工作
                    counter = temp;
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} updated counter to: {counter}");
                }
                finally
                {
                    // 离开临界区
                    semaphore.Release();
                }
            }
        }
    }
}
