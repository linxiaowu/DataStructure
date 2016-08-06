using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Chapter2
{
    /// <summary>
    /// 双向链表节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class DbNode<T>
    {
        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 前驱
        /// </summary>
        public DbNode<T> Prev { get; set; }

        /// <summary>
        /// 后继
        /// </summary>
        public DbNode<T> Next { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public DbNode()
        {
            Data = default(T);
            Next = null;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="data">节点数据</param>
        public DbNode(T data)
        {
            Data = data;
            Next = null;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="next">后继</param>
        public DbNode(DbNode<T> next)
        {
            Data = default(T);
            Next = next;
        }
    }
}
