//QB5: State types of Procedure Calls

using System;

namespace ProcedureCallSimulation
{
    // 定义一个枚举，表示过程调用的状态
    public enum CallState
    {
        Ready,     // 准备状态
        Running,   // 运行状态
        Blocked,   // 阻塞状态
        Finished    // 完成状态
    }

    // 定义一个过程类
    public class Procedure
    {
        public string Name { get; set; }
        public CallState State { get; set; }

        public Procedure(string name)
        {
            Name = name;
            State = CallState.Ready; // 初始化状态为准备状态
        }

        public void Start()
        {
            State = CallState.Running; // 切换到运行状态
            Console.WriteLine($"{Name} is now running.");
        }

        public void Block()
        {
            State = CallState.Blocked; // 切换到阻塞状态
            Console.WriteLine($"{Name} is now blocked.");
        }

        public void Finish()
        {
            State = CallState.Finished; // 切换到完成状态
            Console.WriteLine($"{Name} has finished execution.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 创建一个过程实例
            Procedure proc = new Procedure("ExampleProcedure");

            // 模拟过程调用的状态变化
            proc.Start(); // 开始过程
            // 在某些情况下，过程可能会被阻塞
            proc.Block(); // 阻塞过程
            // 继续执行并完成过程
            proc.Finish(); // 完成过程

            // 打印最终状态
            Console.WriteLine($"Final state of {proc.Name}: {proc.State}");
            Console.ReadKey();
        }
    }
}


