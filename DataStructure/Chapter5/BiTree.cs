using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Chapter5
{
    /// <summary>
    /// 树
    /// </summary>
    class BiTree<T>
    {
        /// <summary>
        /// 头
        /// </summary>
        public Node<T> Head { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public BiTree()
        {
            Head = null;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="data">节点数据</param>
        public BiTree(T data)
        {
            Head = new Node<T>(data);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="data">数据结构</param>
        /// <param name="lc">左孩子</param>
        /// <param name="rc">右孩子</param>
        public BiTree(T data,Node<T>lc,Node<T>rc)
        {
            Head = new Node<T>(data, lc, rc);
        }

        /// <summary>
        /// 判断二叉树是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return Head == null;
        }

        /// <summary>
        /// 获取根节点
        /// </summary>
        /// <returns></returns>
        public Node<T> GetRoot()
        {
            return Head;
        }

        /// <summary>
        /// 获取左孩子节点
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Node<T> GetLChild(Node<T> p)
        {
            return p.LChild;
        }

        /// <summary>
        /// 获取右孩子节点
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Node<T> GetRChild(Node<T> p)
        {
            return p.RChild;
        }

        /// <summary>
        /// 插入左孩子节点
        /// </summary>
        /// <![CDATA[将新节点插入节点P的左孩子节点位置，原左子树成为新节点的左子树]]>
        /// <param name="data"></param>
        /// <param name="p"></param>
        public void InsertL(T data, Node<T> p)
        {
            Node<T> tmp = new Node<T>(data);
            tmp.LChild = p.LChild;
            p.LChild = tmp;
        }

        /// <summary>
        /// 插入右孩子节点
        /// </summary>
        /// <![CDATA[将新节点插入节点P的右孩子节点位置，原节子树成为新节点的节子树]]>
        /// <param name="data"></param>
        /// <param name="p"></param>
        public void InsertR(T data, Node<T> p)
        {
            Node<T> tmp = new Node<T>(data);
            tmp.RChild = p.RChild;
            p.RChild = tmp;
        }

        /// <summary>
        /// 删除左子树
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Node<T> DeleteL(Node<T> p)
        {
            if (p == null)
            {
                return null;
            }
            Node<T> tmp = p.LChild;
            p.LChild = null;
            return tmp;
        }

        /// <summary>
        /// 删除左子树
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Node<T> DeleteR(Node<T> p)
        {
            if (p == null)
            {
                return null;
            }
            Node<T> tmp = p.RChild;
            p.RChild = null;
            return tmp;
        }

        /// <summary>
        /// 是否为叶子节点
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool IsLeaf(Node<T> p)
        {
            if (p == null)
            {
                return false;
            }

            return p.LChild == null && p.RChild == null;
        }
    }
}
