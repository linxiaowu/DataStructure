using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Chapter4
{
    /// <summary>
    /// 串测试类
    /// </summary>
    static class StringDSTest
    {
        /// <summary>
        /// 串测试
        /// </summary>
        public static void TestStringDS()
        {
            Console.WriteLine("初始化数据");
            StringDS sd = InitData();
            Print(sd);

            Console.WriteLine("\r\n测试Compare");
            Console.WriteLine(TestCompare(sd));

            Console.WriteLine("\r\n测试Substring");
            Print(TestSubstring(sd));

            Console.WriteLine("\r\n测试Concat");
            Print(TestConcat(sd));

            Console.WriteLine("\r\n测试Insert");
            Print(TestInsert(sd));

            Console.WriteLine("\r\n测试TestDelete");
            Print(TestDelete(sd));

            Console.WriteLine("\r\n测试Index");
            Console.WriteLine(TestIndex(sd));
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <returns></returns>
        static StringDS InitData()
        {
            char[] arr = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', '1', '2', '3', '4', '5', '6', '7' };
            return new StringDS(arr);
        }

        /// <summary>
        /// 测试Compare
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static int TestCompare(StringDS s)
        {
            return s.Compare(ReadString());
        }

        /// <summary>
        /// 测试Substring
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static StringDS TestSubstring(StringDS s)
        {
            return s.SubString(6, 7);
        }

        /// <summary>
        /// 测试Concat
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static StringDS TestConcat(StringDS s)
        {
            return s.Concat(ReadString());
        }

        /// <summary>
        /// 测试Insert
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static StringDS TestInsert(StringDS s)
        {
            return s.Insert(6, ReadString());
        }

        /// <summary>
        /// 测试Delete
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static StringDS TestDelete(StringDS s)
        {
            return s.Delete(6, 7);
        }

        /// <summary>
        /// 测试Index
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static int TestIndex(StringDS s)
        {
            return s.Index(ReadString());
        }

        /// <summary>
        /// 读取字符串
        /// </summary>
        /// <returns></returns>
        static StringDS ReadString()
        {
            return new StringDS(Console.ReadLine().ToArray());
        }

        /// <summary>
        /// 输出
        /// </summary>
        /// <param name="s"></param>
        static void Print(StringDS s)
        {
            for (int i = 0; i < s.GetLength(); i++)
            {
                Console.Write(s[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
