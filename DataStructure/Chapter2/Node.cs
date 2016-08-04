using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Chapter2
{
    /// <summary>
    /// 链表节点
    /// </summary>
    class Node<T>
    {
        /// <summary>
        /// 节点数据
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 下一个节点
        /// </summary>
        public Node<T> Next { get; set; }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="data">节点数据</param>
        /// <param name="next">下一个节点</param>
        public Node(T data, Node<T> next)
        {
            this.Data = data;
            this.Next = next;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="next">下一个节点</param>
        public Node(Node<T> next)
            : this(default(T), next)
        {

        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="data">节点数据</param>
        public Node(T data)
            : this(data, null)
        {

        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public Node()
            : this(default(T), null)
        {

        }
    }
}
