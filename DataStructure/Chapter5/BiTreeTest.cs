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

            Console.WriteLine("测试Search");
            char value = (char)Console.Read();
            Node<char> tmp = Search(tree.Head, value);
            if (tmp == null)
            {
                Console.WriteLine(value + "不存在");
            }
            else
            {
                Console.WriteLine(string.Format("L:{0}，R:{1}", (tmp.LChild ?? new Node<char>()).Data, (tmp.RChild ?? new Node<char>()).Data));
            }

            Console.WriteLine("\r\n统计叶子节点数量：" + CountLeafNode(tree.Head));

            Console.WriteLine("\r\n计算树的深度：" + GetHeight(tree.Head));

            Console.WriteLine("\r\n输出树结构：");
            PrintTree(tree.Head);
            PrintTree2(tree.Head);
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
        /// 查找节点
        /// </summary>
        /// <param name="root"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        static Node<char> Search(Node<char> root, char value)
        {
            if (root == null)
            {
                return null;
            }

            if (root.Data.Equals(value))
            {
                return root;
            }

            if (root.LChild != null)
            {
                Node<char> tmp = Search(root.LChild, value);
                if (tmp != null)
                {
                    return tmp;
                }
            }

            if (root.RChild != null)
            {
                return Search(root.RChild, value);
            }
            return null;
        }

        /// <summary>
        /// 统计叶子节点数量
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        static int CountLeafNode(Node<char> node)
        {
            if (node == null)
            {
                return 0;
            }

            if (node.LChild == null && node.RChild == null)
            {
                return 1;
            }

            return CountLeafNode(node.LChild) + CountLeafNode(node.RChild);
        }

        /// <summary>
        /// 获取二叉树深度
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        static int GetHeight(Node<char> root)
        {
            if (root == null)
            {
                return 0;
            }

            int lh = GetHeight(root.LChild);
            int rh = GetHeight(root.RChild);
            return (lh > rh ? lh : rh) + 1;
        }

        /// <summary>
        /// 输出树结构
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        static void PrintTree(Node<char> root)
        {
            if (root == null)
            {
                return;
            }

            int deep = GetHeight(root);
            int cNum = 1;   //当前层级节点数量
            int oNum = 0;   //当前层级已输出节点数量
            int num = 0;    //孩子层级节点数量

            string str = "";

            Console.WriteLine("12345678901234567890");

            CSeqQueue<Node<char>> sq = new CSeqQueue<Node<char>>(50);
            sq.In(root);
            while (!sq.IsEmpty())
            {
                Node<char> tmp = sq.Out();
                if (oNum++ % 2 == 0)
                {
                    str = FormatSapce(deep);
                }
                else
                {
                    str = FormatSapce(deep, 1);
                }

                Console.Write(string.Format(str, tmp == null ? ' ' : tmp.Data));

                if (tmp == null)
                {
                    continue;
                }

                sq.In(tmp.LChild);
                sq.In(tmp.RChild);
                num += 2;

                //当前层无节点
                if (--cNum == 0)
                {
                    //换行并切换到下一行
                    Console.WriteLine();
                    deep--;
                    cNum = num;
                    oNum = num = 0;
                }
            }

            Console.WriteLine();
        }

        /// <summary>
        /// 输出树结构
        /// </summary>
        /// <![CDATA[将二叉树认作为一个满二叉树，若节点不存在则以null替代]]>
        /// <param name="root"></param>
        /// <returns></returns>
        static void PrintTree2(Node<char> root)
        {
            if (root == null)
            {
                return;
            }

            int deep = GetHeight(root);
            int index = 0;  //当前树层级，孩子数量（Math.Pow(2, index)）
            int cIndex = 0; //当前层级孩子索引，last：cIndex = Math.Pow(2, index)-1

            string str = "";

            Console.WriteLine("12345678901234567890");

            CSeqQueue<Node<char>> sq = new CSeqQueue<Node<char>>(50);
            sq.In(root);
            while (!sq.IsEmpty())
            {
                Node<char> tmp = sq.Out();
                if (cIndex % 2 == 0)
                {
                    str = FormatSapce(deep - index);
                }
                else
                {
                    str = FormatSapce(deep - index, 1);
                }

                Console.Write(string.Format(str, tmp == null ? ' ' : tmp.Data));

                if (tmp == null)
                {
                    continue;
                }

                sq.In(tmp.LChild);
                sq.In(tmp.RChild);

                //当前层无节点
                if (cIndex++ == (int)Math.Pow(2, index) - 1)
                {
                    //换行并切换到下一行
                    Console.WriteLine();
                    index++;
                    cIndex = 0;
                }
            }

            Console.WriteLine();
        }

        /// <summary>
        /// 输出空格占位符
        /// </summary>
        /// <param name="deep"></param>
        static string FormatSapce(int deep, int offset = 0)
        {
            if (deep < 1)
            {
                return "{0}";
            }

            string str = new string(' ', (int)Math.Pow(2, deep - 1) + offset - 1);

            return str + "{0}" + str;
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
