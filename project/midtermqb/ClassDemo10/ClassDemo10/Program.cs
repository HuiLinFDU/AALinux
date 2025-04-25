// Background thread

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace ThreadSample9
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Thread worker = new Thread(delegate () { Console.ReadKey(); });
            n = Convert.ToInt32(Console.ReadLine());
            if (n == 1)
                worker.IsBackground = true;
            Console.WriteLine(worker.IsBackground);
            worker.Start();
        }
    }
}



