using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Chapter3
{
    /// <summary>
    /// 测试队列
    /// </summary>
    static class QueueTest
    {
        /// <summary>
        /// 测试循环顺序队列
        /// </summary>
        public static void TestCSeqQueue()
        {
            Test(new CSeqQueue<int>(20));
        }

        /// <summary>
        /// 测试链队列
        /// </summary>
        public static void TestLinkQueue()
        {
            Test(new LinkQueue<int>());
        }

        /// <summary>
        /// 测试栈
        /// </summary>
        /// <param name="queue"></param>
        static void Test(IQueue<int> queue)
        {
            Console.WriteLine("len：" + queue.GetLength());
            Console.WriteLine("\r\n测试Push方法");
            TestIn(queue);
            Console.WriteLine("期望长度6，len：" + queue.GetLength());

            Console.WriteLine("\n\r测试GetFront方法");
            TestGetFront(queue);
            Console.WriteLine("期望长度6，len：" + queue.GetLength());

            Console.WriteLine("\n\r测试Out方法");
            TestOut(queue);
            Console.WriteLine("期望长度0，len：" + queue.GetLength());

            string str = Console.ReadLine();
            Console.WriteLine(IsPalindrome(str));
        }

        /// <summary>
        /// 测试In方法
        /// </summary>
        /// <param name="queue"></param>
        static void TestIn(IQueue<int> queue)
        {
            queue.In(1);
            queue.In(2);
            queue.In(3);
            queue.In(4);
            queue.In(5);
            queue.In(6);
        }

        /// <summary>
        /// 测试GetFront方法
        /// </summary>
        /// <param name="queue"></param>
        static void TestGetFront(IQueue<int> queue)
        {
            Console.WriteLine("期望1：" + queue.GetFront());
        }

        /// <summary>
        /// 测试TestOut方法
        /// </summary>
        /// <param name="queue"></param>
        static void TestOut(IQueue<int> queue)
        {
            while (!queue.IsEmpty())
            {
                Console.Write(queue.Out() + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// 判断字符串是否是回文
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static bool IsPalindrome(string str)
        {
            SeqStack<char> stack = new SeqStack<char>(20);
            CSeqQueue<char> queue = new CSeqQueue<char>(20);
            foreach (char c in str)
            {
                queue.In(c);
                stack.Push(c);
            }

            while (!queue.IsEmpty() && !stack.IsEmpty())
            {
                if (stack.Pop() != queue.Out())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
