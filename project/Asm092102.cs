using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace Assignment092102 {
 class Program  {
 static void Main(string[] args)  {
 int n;
 Thread worker1 = new Thread(delegate () { Console.ReadKey(); });
 Thread worker2 = new Thread(delegate () { Console.ReadKey(); });

 n = Convert.ToInt32(Console.ReadLine());
 if (n == 1)
   worker1.IsBackground = true;
 if (n == 2){
   worker1.IsBackground = true;
   worker2.IsBackground = true;
 }
 
 Console.WriteLine("The worker1 thread bg-flag: " + worker1.IsBackground);
 Console.WriteLine("The worker2 thread bg-flag: " + worker2.IsBackground);
 worker1.Start();
 worker2.Start();

 }
 }
}
