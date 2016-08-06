using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Chapter3
{
    /// <summary>
    /// 链栈节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Node<T>
    {
        /// <summary>
        /// 数据域
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 引用域
        /// </summary>
        public Node<T> Next { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public Node()
            : this(default(T), null)
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="data"></param>
        public Node(T data)
            : this(data, null)
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="next"></param>
        public Node(Node<T> next)
            : this(default(T), next)
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="data"></param>
        /// <param name="next"></param>
        public Node(T data, Node<T> next)
        {
            this.Data = data;
            this.Next = next;
        }
    }
}
