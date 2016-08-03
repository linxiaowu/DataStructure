using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Chapter2
{
    /// <summary>
    /// 线性表使用、测试类
    /// </summary>
    static class SeqListTest
    {
        /// <summary>
        /// 测试线性表方法
        /// </summary>
        public static void TestSeqList()
        {
            SeqList<int> list = new SeqList<int>(10);
            InitData(list);
            Print(list);

            list.Insert(10, 3);
            Print(list);

            Console.WriteLine("线性表长度：" + list.GetLength());
            Console.WriteLine("删除数据：" + list.Delete(2));
            Console.WriteLine("删除后长度：" + list.GetLength());
            Print(list);

            Console.WriteLine("第三个数据：" + list.GetElem(2));
            Console.WriteLine("10的位置：" + list.Locate(10));

            list.Reverse();
            Print(list);
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="">线性表</param>
        static void InitData(SeqList<int> list)
        {
            list.Append(1);
            list.Append(2);
            list.Append(3);
            list.Append(4);
            list.Append(5);
        }

        /// <summary>
        /// 输出列表
        /// </summary>
        /// <param name="list">列表</param>
        static void Print(SeqList<int> list)
        {
            for (int i = 0; i < list.GetLength(); i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
