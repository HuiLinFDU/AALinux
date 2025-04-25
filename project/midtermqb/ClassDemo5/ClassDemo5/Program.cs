// Class Demo5 : Thread connection
// upd version: global variables can be used to create coordination between threads.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace ThreadSample2 {
class Program {
private static bool b = false;
static void Main(string[] args) {
  Thread FirestThread = new Thread(PrintX);
  Thread SecondThread = new Thread(PrintY);
  FirestThread.Start();
  SecondThread.Start();
  Console.ReadKey();   }
static void PrintX() {
for (int i = 0; i < 100; i++) {
  while (b) ;
  Console.Write('X');
  b = true; }  }
static void PrintY() {
for (int i = 0; i < 100; i++) {
  while (!b) ;
  Console.Write('Y');
  b = false; } } }   }


