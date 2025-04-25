// Class Demo4: Thread connection
//use the global variable N and Done to create a connection between the threads. 
//The variable N specifies the number of prints of X and Y, and the variable Done, 
//which is of the bool type, indicates the number of prints.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace ThreadSample4 {
class Program {
private static bool done = false;
private static int n;
static void Main(string[] args) {
  ThreadStart GetNref = new ThreadStart(GetN);
  ThreadStart PrintXref = new ThreadStart(PrintX);
  ThreadStart PrintYref = new ThreadStart(PrintY);
  Thread CoorThread = new Thread(GetNref);
  Thread FirestThread = new Thread(PrintXref);
  Thread SecondThread = new Thread(PrintYref);
  CoorThread.Start();
  FirestThread.Start();
  SecondThread.Start();
Console.ReadKey(); 
}
static void GetN() {
n=Convert.ToInt32(Console.ReadLine());
done = true; }
static void PrintX() {
while (!done) ;
for (int i = 0; i < n; i++) {
  Console.Write('X');
  Thread.Sleep(50);
  }
 }
static void PrintY() {
  while (!done) ;
for (int i = 0; i < n; i++) {
  Console.Write('Y');
  Thread.Sleep(50);
     }
   }
 }
}


