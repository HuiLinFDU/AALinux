// Class Demo3: Sleep Method

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace ThreadSample3 {
class Program {
static void Main(string[] args) {
   ThreadStart PrintXref = new ThreadStart(PrintX);
   ThreadStart PrintYref = new ThreadStart(PrintY);
   Thread FirestThread = new Thread(PrintXref);
   Thread SecondThread = new Thread(PrintYref);
   FirestThread.Start();
   SecondThread.Start();
   Console.ReadKey();   }
    static void PrintX() {
    for (int i = 0; i < 100; i++) {
        Console.Write('X');
        Thread.Sleep(10); 
        } 
    }
    static void PrintY() {
    for (int i = 0; i < 100; i++) {
        Console.Write('Y');
        Thread.Sleep(10);
        } 
    }
} 
}


