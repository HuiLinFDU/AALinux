//QB6: sets of threads print the name information after the others

using System;
using System.Threading;

namespace ThreadSetPrint
{
    class Program
    {
        // 用于线程同步的锁对象
        private static readonly object _lock = new object();
        private static int _currentThreadSet = 1; // 记录当前正在打印的线程集

        static void Main(string[] args)
        {
            // 创建两个线程集合
            Thread[] set1 = new Thread[5];
            Thread[] set2 = new Thread[5];

            // 初始化并启动第一个线程集合
            for (int i = 0; i < 5; i++)
            {
                set1[i] = new Thread(PrintInfo);
                set1[i].Name = "Set1_Thread" + (i + 1);
                set1[i].Start();
            }

            // 初始化并启动第二个线程集合
            for (int i = 0; i < 5; i++)
            {
                set2[i] = new Thread(PrintInfo);
                set2[i].Name = "Set2_Thread" + (i + 1);
                set2[i].Start();
            }

            // 等待所有线程完成
            foreach (var thread in set1)
            {
                thread.Join();
            }
            foreach (var thread in set2)
            {
                thread.Join();
            }

            Console.WriteLine("All threads have completed.");
            Console.ReadKey();
        }

        static void PrintInfo()
        {
            for (int i = 0; i < 5; i++)
            {
                // 线程同步，确保一个线程集在打印
                lock (_lock)
                {
                    if (_currentThreadSet == 1 && Thread.CurrentThread.Name.StartsWith("Set1"))
                    {
                        Console.WriteLine($"Set1: Hui, 2072293, Lin");
                        _currentThreadSet = 2; // 切换到第二个线程集
                    }
                    else if (_currentThreadSet == 2 && Thread.CurrentThread.Name.StartsWith("Set2"))
                    {
                        Console.WriteLine($"Set2: Hui, 2072293, Lin");
                        _currentThreadSet = 1; // 切换到第一个线程集
                    }
                }
                // 确保有时间间隔，使得输出更具可读性
                Thread.Sleep(100); // 睡眠100毫秒
            }
        }
    }
}

