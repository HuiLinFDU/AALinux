//QB3: System Call Parameter Passing

using System;

namespace SystemCallParameterPassing
{
    class Program
    {
        static void Main(string[] args)
        {
            // 示例1：通过寄存器传递参数
            Console.WriteLine("Example 1: Passing Parameters via Registers");
            int result1 = AddViaRegisters(2, 3);
            Console.WriteLine($"Result of AddViaRegisters(2, 3): {result1}\n");

            // 示例2：通过内存传递参数
            Console.WriteLine("Example 2: Passing Parameters via Memory");
            int[] parameters = { 4, 5 };
            int result2 = AddViaMemory(parameters);
            Console.WriteLine($"Result of AddViaMemory(new int[] {{ 4, 5 }}): {result2}\n");

            // 示例3：通过栈传递参数
            Console.WriteLine("Example 3: Passing Parameters via Stack");
            int result3 = AddViaStack(6, 7);
            Console.WriteLine($"Result of AddViaStack(6, 7): {result3}\n");

            Console.ReadKey();
        }

        // 示例方法1：通过寄存器传递参数
        // 在实际操作系统中，参数会存储在CPU寄存器中
        static int AddViaRegisters(int a, int b)
        {
            // 模拟寄存器操作
            int registerA = a;
            int registerB = b;
            int registerResult = registerA + registerB;
            return registerResult;
        }

        // 示例方法2：通过内存传递参数
        // 在实际操作系统中，参数会存储在内存的特定位置
        static int AddViaMemory(int[] parameters)
        {
            // 模拟内存操作
            int memoryLocationA = parameters[0];
            int memoryLocationB = parameters[1];
            int memoryResult = memoryLocationA + memoryLocationB;
            return memoryResult;
        }

        // 示例方法3：通过栈传递参数
        // 在实际操作系统中，参数会存储在栈中
        static int AddViaStack(int a, int b)
        {
            // 模拟栈操作
            Stack<int> stack = new Stack<int>();
            stack.Push(a);
            stack.Push(b);
            int stackB = stack.Pop();
            int stackA = stack.Pop();
            int stackResult = stackA + stackB;
            return stackResult;
        }
    }
}