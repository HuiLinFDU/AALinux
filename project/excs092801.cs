using System.Threading;
namespace ThreadSample10 {
class Program {
private static int n;
static void Main(string[] args) {
   ThreadStart GetNref = new ThreadStart(GetN);
   ThreadStart PrintXref = new ThreadStart(PrintX);
   ThreadStart PrintYref = new ThreadStart(PrintY);
   Thread CoorThread = new Thread(GetNref);
   Thread FirestThread = new Thread(PrintXref);
   Thread SecondThread = new Thread(PrintYref);
   Console.WriteLine("Please input the counter number:");
   CoorThread.Start();
   CoorThread.Join();
   Console.WriteLine("CoorThread operation has been finished.");
   FirestThread.Start();
   SecondThread.Start();
   FirestThread.Join();
   SecondThread.Join();
   Console.WriteLine();
   Console.WriteLine("FirestThread & SecondThread operation has been finished.");
   Console.ReadKey(); }
static void GetN() {
n = Convert.ToInt32(Console.ReadLine());
}
static void PrintX() {
for (int i = 0; i < n; i++) {
Console.Write('X');
Thread.Sleep(50); } }
static void PrintY() {
for (int i = 0; i < n; i++) {
   Console.Write('Y');
   Thread.Sleep(50);
    }
  }
 }
}
