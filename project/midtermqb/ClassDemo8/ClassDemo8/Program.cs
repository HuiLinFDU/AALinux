// Class Demo8: Parameterization of threads

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace ThreadSample7 {
class Program {
static void Main(string[] args) {
  int m = 100;
  int n = 120;
  ParameterizedThreadStart PrintXref =
  new ParameterizedThreadStart(PrintX);
  ParameterizedThreadStart PrintYref =
  new ParameterizedThreadStart(PrintY);
  Thread FirestThread = new Thread(PrintXref);
  Thread SecondThread = new Thread(PrintYref);
  FirestThread.Start(m);
  SecondThread.Start(n);
  Console.ReadKey();
}
static void PrintX(object k) {
for (int i = 0; i < (int)k; i++) {

Console.Write('X');
Thread.Sleep(50);
 }
}
static void PrintY(object p) {
for (int i = 0; i < (int)p; i++) {
  Console.Write('Y');
  Thread.Sleep(50);
   }
  }
 }
}



