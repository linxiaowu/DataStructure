using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Chapter3
{
    /// <summary>
    /// 测试顺序栈
    /// </summary>
    static class SeqStackTest
    {
        /// <summary>
        /// 测试顺序栈
        /// </summary>
        public static void TestSeqStack()
        {
            SeqStack<int> stack = new SeqStack<int>(20);
            Console.WriteLine("len：" + stack.GetLength());
            Console.WriteLine("\r\n测试Push方法");
            TestPush(stack);
            Console.WriteLine("期望长度6，len：" + stack.GetLength());

            Console.WriteLine("\n\r测试GetPop方法");
            TestGetPop(stack);
            Console.WriteLine("期望长度6，len：" + stack.GetLength());


            Console.WriteLine("\n\r测试Pop方法");
            TestPop(stack);
            Console.WriteLine("期望长度0，len：" + stack.GetLength());
        }

        /// <summary>
        /// 测试Push方法
        /// </summary>
        /// <param name="stack"></param>
        static void TestPush(SeqStack<int> stack)
        {
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            stack.Push(6);
        }

        /// <summary>
        /// 测试GetPop方法
        /// </summary>
        /// <param name="stack"></param>
        static void TestGetPop(SeqStack<int> stack)
        {
            Console.WriteLine("期望6：" + stack.GetPop());
        }

        /// <summary>
        /// 测试TestPop方法
        /// </summary>
        /// <param name="stack"></param>
        static void TestPop(SeqStack<int> stack)
        {
            while (!stack.IsEmpty())
            {
                Console.Write(stack.Pop()+" ");
            }
            Console.WriteLine();
        }
    }
}
