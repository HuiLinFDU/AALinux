// Class Demo2:Printing X and Y with threads
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace ThreadSample2 {
class Program {
static void Main(string[] args) {
   Thread FirestThread = new Thread(PrintX);
   Thread SecondThread = new Thread(PrintY);
   FirestThread.Start();
   SecondThread.Start();
   Console.ReadKey();
}
static void PrintX() {
   for (int i = 0; i < 100; i++) {
   Console.Write('X');
  }
}
static void PrintY() {
for (int i = 0; i < 100; i++) {
   Console.Write('Y');
    }
  }
 }
}



