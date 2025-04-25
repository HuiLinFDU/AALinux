// Class Demo7: Semaphore Implementation with C#

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace ThreadSample6 {
class Program {
//------
static Thread[] t = new Thread[5];
static Semaphore SampleSemaphore = new Semaphore(2, 2);
static void Main(string[] args) {
  for (int j = 0; j < 5; j++) {
    t[j] = new Thread(DoSomething);
    t[j].Start();  }
Console.Read(); }
static void DoSomething() {
  Console.WriteLine("waiting");
  SampleSemaphore.WaitOne();
  Console.WriteLine("{0} begins!");
  Thread.Sleep(1000);
  Console.WriteLine("{0} releasing...");
  SampleSemaphore.Release();
} } }

