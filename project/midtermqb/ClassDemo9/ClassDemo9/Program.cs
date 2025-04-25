// Class Demo9:  Naming Threads

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace ThreadSample8 {
class Program {
static void Main(string[] args) {
  Thread.CurrentThread.Name = "Main";
  Thread SampleThread = new Thread(TestFunction);
  SampleThread.Name = "SampleThread";
  SampleThread.Start();
  TestFunction();
  Console.ReadKey();
}
static void TestFunction() {
Console.WriteLine("Hello From "+Thread.CurrentThread.Name);
   }
  }
}

