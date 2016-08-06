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
    static class StackTest
    {
        /// <summary>
        /// 测试顺序栈
        /// </summary>
        public static void TestSeqStack()
        {
            IStack<int> stack = new SeqStack<int>(20);
            Test(stack);
        }

        /// <summary>
        /// 测试链栈
        /// </summary>
        public static void TestLinkStack()
        {
            IStack<int> stack = new LinkStack<int>();
            Test(stack);
        }

        /// <summary>
        /// 测试栈
        /// </summary>
        /// <param name="stack"></param>
        static void Test(IStack<int> stack)
        {
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

            Console.WriteLine("\n\r进制转换，12：");
            Conversion(12, 8);
            Conversion(12, 2);
        }

        /// <summary>
        /// 测试Push方法
        /// </summary>
        /// <param name="stack"></param>
        static void TestPush(IStack<int> stack)
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
        static void TestGetPop(IStack<int> stack)
        {
            Console.WriteLine("期望6：" + stack.GetPop());
        }

        /// <summary>
        /// 测试TestPop方法
        /// </summary>
        /// <param name="stack"></param>
        static void TestPop(IStack<int> stack)
        {
            while (!stack.IsEmpty())
            {
                Console.Write(stack.Pop() + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// 进制转换
        /// </summary>
        /// <param name="n">原始数据</param>
        /// <param name="m">待转换进制</param>
        static void Conversion(int n, int m)
        {
            LinkStack<int> s = new LinkStack<int>();
            while (n > 0)
            {
                s.Push(n % m);
                n /= m;
            }

            while (!s.IsEmpty())
            {
                Console.Write(s.Pop() + " ");
            }
            Console.WriteLine();
        }
    }
}
