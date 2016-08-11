using DataStructure.Chapter3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Chapter5
{
    /// <summary>
    /// 测试树
    /// </summary>
    class BiTreeTest
    {
        /// <summary>
        /// 测试树
        /// </summary>
        public static void TestBiTree()
        {
            BiTree<char> tree = InitTree();
            Console.WriteLine("测试先序遍历");
            Console.WriteLine("期望：A B D H I E J C F G");
            Console.Write("结果：");
            PreOrder(tree.Head);
            Console.WriteLine("\r\n");

            Console.WriteLine("测试中序遍历");
            Console.WriteLine("期望：H D I B J E A F C G");
            Console.Write("结果：");
            InOrder(tree.Head);
            Console.WriteLine("\r\n");

            Console.WriteLine("测试后序遍历");
            Console.WriteLine("期望：H I D J E B F G C A");
            Console.Write("结果：");
            PostOrder(tree.Head);
            Console.WriteLine("\r\n");

            Console.WriteLine("测试层级遍历");
            Console.WriteLine("期望：A B C D E F G H I J");
            Console.Write("结果：");
            LevelOrder(tree.Head);
            Console.WriteLine("\r\n");
        }

        /// <summary>
        /// 初始化数
        /// </summary>
        /// <returns></returns>
        static BiTree<char> InitTree()
        {
            //左子树
            Node<char> h = new Node<char>('H');
            Node<char> i = new Node<char>('I');
            Node<char> d = new Node<char>('D', h, i);
            Node<char> j = new Node<char>('J');
            Node<char> e = new Node<char>('E', j, null);
            Node<char> b = new Node<char>('B', d, e);

            //右子树
            Node<char> f = new Node<char>('F');
            Node<char> g = new Node<char>('G');
            Node<char> c = new Node<char>('C', f, g);

            return new BiTree<char>('A', b, c);
        }

        /// <summary>
        /// 先序遍历（DLR）
        /// </summary>
        /// <![CDATA[首先访问跟节点，然后遍历左子树，最后右子树]]>
        /// <param name="root"></param>
        static void PreOrder(Node<char> root)
        {
            if (root == null)
            {
                return;
            }

            Print(root);
            PreOrder(root.LChild);
            PreOrder(root.RChild);
        }

        /// <summary>
        /// 中序遍历（LDR）
        /// </summary>
        /// <![CDATA[先遍历左子树，然后根节点，最后遍历右子树]]>
        /// <param name="root"></param>
        static void InOrder(Node<char> root)
        {
            if (root == null)
            {
                return;
            }

            InOrder(root.LChild);
            Print(root);
            InOrder(root.RChild);
        }

        /// <summary>
        /// 后序遍历（LRD）
        /// </summary>
        /// <![CDATA[先遍历左子树，然后遍历右子树，最后遍历根节点]]>
        /// <param name="root"></param>
        static void PostOrder(Node<char> root)
        {
            if (root == null)
            {
                return;
            }

            PostOrder(root.LChild);
            PostOrder(root.RChild);
            Print(root);
        }

        /// <summary>
        /// 层序遍历
        /// </summary>
        /// <![CDATA[从上向下从左到右]]>
        /// <param name="root"></param>
        static void LevelOrder(Node<char> root)
        {
            if (root == null)
            {
                return;
            }
            CSeqQueue<Node<char>> sq = new CSeqQueue<Node<char>>(50);
            sq.In(root);
            while (!sq.IsEmpty())
            {
                Node<char> tmp = sq.Out();
                Print(tmp);

                if (tmp.LChild != null)
                {
                    sq.In(tmp.LChild);
                }

                if (tmp.RChild != null)
                {
                    sq.In(tmp.RChild);
                }
            }
        }

        /// <summary>
        /// 输出
        /// </summary>
        /// <param name="root"></param>
        static void Print(Node<char> root)
        {
            Console.Write(root.Data + " ");
        }
    }
}
