using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Chapter2
{
    static class LinkListTest
    {
        /// <summary>
        /// 测试
        /// </summary>
        public static void TestLinkList()
        {
            LinkList<int> list = new LinkList<int>();
            Console.WriteLine("初始化数据");
            InitData(list);
            Print(list);

            Console.WriteLine("测试Insert");
            TestInsert(list);
            Print(list);

            Console.WriteLine("测试Delete");
            TestDelete(list);
            Print(list);
        }

        /// <summary>
        /// 初始化链表数据
        /// </summary>
        /// <param name="list"></param>
        static void InitData(LinkList<int> list)
        {
            list.Append(1);
            list.Append(3);
            list.Append(5);
            list.Append(7);
            list.Append(9);
        }

        /// <summary>
        /// 测试insert方法
        /// </summary>
        /// <param name="list"></param>
        static void TestInsert(LinkList<int> list)
        {
            list.Insert(12, 0);
            list.Insert(14, 2);
            list.Insert(16, 6);
            list.Insert(18, 7);
            list.Insert(20, 10);
        }

        /// <summary>
        /// 测试删除
        /// </summary>
        /// <param name="list"></param>
        static void TestDelete(LinkList<int> list)
        {
            Console.WriteLine("删除Index=0：" + list.Delete(0));
            Console.WriteLine("删除Index=2：" + list.Delete(2));
            Console.WriteLine("删除Index=7：" + list.Delete(7));
        }

        /// <summary>
        /// 输出链表数据
        /// </summary>
        /// <param name="list"></param>
        static void Print(LinkList<int> list)
        {
            Node<int> tmp = list.Head;
            while (tmp != null)
            {
                Console.Write(tmp.Data + " ");
                tmp = tmp.Next;
            }
            Console.WriteLine();
        }
    }
}
