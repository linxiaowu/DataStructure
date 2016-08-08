using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Chapter3
{
    /// <summary>
    /// 链队列
    /// </summary>
    class LinkQueue<T> : IQueue<T>
    {
        private int num;    //队列元素个数

        /// <summary>
        /// 队首
        /// </summary>
        public Node<T> Front { get; set; }

        /// <summary>
        /// 队尾
        /// </summary>
        public Node<T> Rear { get; set; }

        /// <summary>
        /// 获取队列长度
        /// </summary>
        /// <returns></returns>
        public int GetLength()
        {
            return num;
        }

        /// <summary>
        /// 队列是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return Front == Rear && num == 0;
        }

        /// <summary>
        /// 清空队列
        /// </summary>
        public void Clear()
        {
            Front = Rear = null;
            num = 0;
        }

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="item"></param>
        public void In(T item)
        {
            Node<T> node = new Node<T>(item);
            if (Rear == null)
            {
                Rear = node;
                Front = Rear;
            }
            else
            {
                Rear.Next = node;
                Rear = Rear.Next;
            }
            ++num;
        }

        /// <summary>
        /// 出栈
        /// </summary>
        /// <returns></returns>
        public T Out()
        {
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException("Queue is empty");
            }

            Node<T> node = Front;
            Front = Front.Next;

            if (Front == null)
            {
                Rear = null;
            }
            --num;
            return node.Data;
        }

        /// <summary>
        /// 获取栈顶元素
        /// </summary>
        /// <returns></returns>
        public T GetFront()
        {
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException("Queue is empty");
            }
            return Front.Data;
        }
    }
}
