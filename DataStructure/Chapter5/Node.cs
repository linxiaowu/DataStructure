using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Chapter5
{
    /// <summary>
    /// 二叉树节点
    /// </summary>
    class Node<T>
    {
        /// <summary>
        /// 数据域
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 左孩子
        /// </summary>
        public Node<T> LChild { get; set; }

        /// <summary>
        /// 右孩子
        /// </summary>
        public Node<T> RChild { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="data">节点数据</param>
        /// <param name="lc">左孩子</param>
        /// <param name="rc">右孩子</param>
        public Node(T data, Node<T> lc, Node<T> rc)
        {
            this.Data = data;
            this.LChild = lc;
            this.RChild = rc;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="lc">左孩子</param>
        /// <param name="rc">右孩子</param>
        public Node(Node<T> lc, Node<T> rc) :
            this(default(T), lc, rc)
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="data">节点数据</param>
        public Node(T data)
            : this(data, null, null)
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public Node()
            : this(default(T), null, null)
        {

        }
    }
}
