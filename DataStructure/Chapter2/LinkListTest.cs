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
            Console.WriteLine("测试Append");
            TestAppend(list);
            Print(list);

            Console.WriteLine("\r\n测试Insert");
            TestInsert(list);
            Print(list);

            Console.WriteLine("\r\n测试Delete");
            TestDelete(list);
            Print(list);

            Console.WriteLine("\r\n测试GetElem");
            TestGetElem(list);

            Console.WriteLine("\r\n测试Locate");
            TestLocate(list);

            Console.WriteLine("\r\n测试Reverse");
            list.Reverse();
            Print(list);

            Console.WriteLine("\r\n测试Merge");
            LinkList<int> la = new LinkList<int>();
            LinkList<int> lb = new LinkList<int>();
            TestAppend(la);
            TestAppend(lb);
            lb.Append(11);
            lb.Append(20);
            Print(la);
            Print(lb);
            LinkList<int> lc = Merge(la, lb);
            Print(lc);
        }

        /// <summary>
        /// 测试Append方法
        /// </summary>
        /// <param name="list"></param>
        static void TestAppend(LinkList<int> list)
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
        /// 测试元素获取
        /// </summary>
        /// <param name="list"></param>
        static void TestGetElem(LinkList<int> list)
        {
            Console.WriteLine("获取元素Index=0：" + list.GetElem(0));
            Console.WriteLine("获取元素Index=2：" + list.GetElem(2));
            Console.WriteLine("获取元素Index=6：" + list.GetElem(6));
        }

        /// <summary>
        /// 测试元素定位
        /// </summary>
        /// <param name="list"></param>
        static void TestLocate(LinkList<int> list)
        {
            Console.WriteLine("获取元素位置Value=1：" + list.Locate(1));
            Console.WriteLine("获取元素位置Value=5：" + list.Locate(5));
            Console.WriteLine("获取元素位置Value=9：" + list.Locate(9));
            Console.WriteLine("获取元素位置Value=3：" + list.Locate(3));
        }


        static LinkList<int> Merge(LinkList<int> la, LinkList<int> lb)
        {
            LinkList<int> lc = new LinkList<int>();
            Node<int> laHead = la.Head;
            Node<int> lbHead = lb.Head;
            Node<int> lcLast = lc.Head;
            Node<int> tmp = null;
            while (laHead != null && lbHead != null)
            {
                if (laHead.Data < lbHead.Data)
                {
                    tmp = laHead;
                    laHead = laHead.Next;
                }
                else
                {
                    tmp = lbHead;
                    lbHead = lbHead.Next;
                }

                if (lc.Head == null)
                {
                    //lc.Append(tmp.Data);
                    lc.Head = tmp;
                    lcLast = lc.Head;
                }
                else
                {
                    lcLast.Next = tmp;
                    lcLast = lcLast.Next;
                }
            }

            if (laHead == null)
            {
                laHead = lbHead;
            }
            lcLast.Next = laHead;
            return lc;
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
