using DataStructure.Chapter2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            TestSeqList();
        }

        /// <summary>
        /// 测试线性表方法
        /// </summary>
        static void TestSeqList()
        {
            SeqList<int> list = new SeqList<int>(10);
            list.Append(1);
            list.Append(2);
            list.Append(3);
            list.Append(4);
            list.Append(5);


            for (int i = 0; i < list.GetLength(); i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();

            list.Insert(10, 3);
            for (int i = 0; i < list.GetLength(); i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("线性表长度：" + list.GetLength());
            Console.WriteLine("删除数据：" + list.Delete(2));
            Console.WriteLine("删除后长度：" + list.GetLength());
            for (int i = 0; i < list.GetLength(); i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("第三个数据：" + list.GetElem(2));
            Console.WriteLine("10的位置：" + list.Locate(10));
        }
    }
}
