// Class Demo1: Printing X and Y without threads

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ThreadSample1 {
class Program {
static void Main(string[] args) {
   PrintY();
   PrintX();
   Console.ReadKey(); 
  }
static void PrintX() {
   for (int i = 0; i < 20; i++) {
   Console.Write('X');
 } }
static void PrintY() {
   for (int i = 0; i < 20; i++) {
   Console.Write('Y');
   }  
  }
 }  
}

