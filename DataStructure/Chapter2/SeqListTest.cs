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
            Console.WriteLine("测试Append方法");
            TestAppend(list);
            Print(list);

            Console.WriteLine("\n\r测试Insert方法");
            TestInsert(list);
            Print(list);

            Console.WriteLine("\n\r测试Delete方法");
            TestDelete(list);
            Print(list);

            Console.WriteLine("\r\n测试GetElem方法");
            TestGetElem(list);

            Console.WriteLine("\r\n测试Locate方法");
            TestLocate(list);

            Console.WriteLine("\r\n测试Reverse方法");
            list.Reverse();
            Print(list);

            Console.WriteLine("");
            TestMerge();
        }

        /// <summary>
        /// 测试Append方法
        /// </summary>
        /// <param name="list"></param>
        static void TestAppend(SeqList<int> list)
        {
            list.Append(1);
            list.Append(2);
            list.Append(3);
            list.Append(4);
            list.Append(5);
        }

        /// <summary>
        /// 测试Insert方法
        /// </summary>
        /// <param name="list"></param>
        static void TestInsert(SeqList<int> list)
        {
            list.Insert(10, 3);
            list.Insert(20, 5);
        }

        /// <summary>
        /// 测试Delete方法
        /// </summary>
        /// <param name="list"></param>
        static void TestDelete(SeqList<int> list)
        {
            Console.WriteLine("删除数据Index=2：" + list.Delete(2));
            Console.WriteLine("删除数据Index=4：" + list.Delete(4));
        }

        /// <summary>
        /// 测试GetElem方法
        /// </summary>
        /// <param name="list"></param>
        static void TestGetElem(SeqList<int> list)
        {
            Console.WriteLine("获取元素Index=0：" + list.GetElem(0));
            Console.WriteLine("获取元素Index=2：" + list.GetElem(2));
            Console.WriteLine("获取元素Index=3：" + list.GetElem(3));
        }

        /// <summary>
        /// 测试元素定位
        /// </summary>
        /// <param name="list"></param>
        static void TestLocate(SeqList<int> list)
        {
            Console.WriteLine("获取元素位置Value=1：" + list.Locate(1));
            Console.WriteLine("获取元素位置Value=10：" + list.Locate(10));
            Console.WriteLine("获取元素位置Value=4：" + list.Locate(4));
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

        /// <summary>
        /// 测试合并
        /// </summary>
        static void TestMerge()
        {
            SeqList<int> la = new SeqList<int>(10);
            la.Append(1);
            la.Append(3);
            la.Append(5);
            la.Append(7);
            la.Append(8);

            SeqList<int> lb = new SeqList<int>(10);
            lb.Append(2);
            lb.Append(4);
            lb.Append(6);
            lb.Append(8);
            lb.Append(11);

            SeqList<int> lc = Merge(la, lb);
            Console.WriteLine("测试Merge");
            Print(lc);

            Console.WriteLine("测试去重");
            lc = Purge(lc);
            Print(lc);
        }

        /// <summary>
        /// 有数据类型为整型的顺序表La和Lb，其数据元素均按从小到大的升序排列，编写一个算法将它们合并成一个表Lc，要求Lc中数据元素也按升序排列。 
        /// </summary>
        /// <param name="la"></param>
        /// <param name="lb"></param>
        /// <returns></returns>
        static SeqList<int> Merge(SeqList<int> la, SeqList<int> lb)
        {
            SeqList<int> lc = new SeqList<int>(la.GetLength() + lb.GetLength());
            int i = 0;
            int j = 0;
            while (i < la.GetLength() && j < lb.GetLength())
            {
                if (la[i] < lb[j])
                {
                    lc.Append(la[i++]);
                    continue;
                }
                lc.Append(lb[j++]);
            }

            while (i < la.GetLength())
            {
                lc.Append(la[i++]);
            }

            while (j < lb.GetLength())
            {
                lc.Append(lb[j++]);
            }
            return lc;
        }

        /// <summary>
        /// 已知一个存储整数的顺序表La，试构造顺序表Lb，要求顺序表Lb中只包含顺序表La中所有值不相同的数据元素
        /// </summary>
        /// <param name="la"></param>
        /// <returns></returns>
        static SeqList<int> Purge(SeqList<int> la)
        {
            int len = la.GetLength();
            SeqList<int> lb = new SeqList<int>(len);
            if (len <= 0)
            {
                return lb;
            }

            lb.Append(la[0]);

            for (int i = 1; i < len; i++)
            {
                int j = 0;
                for (; j < lb.GetLength(); j++)
                {
                    if (lb[j].Equals(la[i]))
                    {
                        break;
                    }
                }

                if (j >= lb.GetLength())
                {
                    lb.Append(la[i]);
                }
            }
            return lb;
        }
    }
}
