using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Chapter3
{
    /// <summary>
    /// 链栈
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class LinkStack<T> : IStack<T>
    {
        /// <summary>
        /// 栈顶
        /// </summary>
        public Node<T> Top { get; set; }

        /// <summary>
        /// 节点个数
        /// </summary>
        public int Num { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public LinkStack()
        {
            Clear();
        }

        /// <summary>
        /// 获取链栈长度
        /// </summary>
        /// <returns></returns>
        public int GetLength()
        {
            return Num;
        }

        /// <summary>
        /// 链栈是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return Top == null && Num == 0;
        }

        /// <summary>
        /// 清空链栈
        /// </summary>
        /// <returns></returns>
        public void Clear()
        {
            this.Top = null;
            this.Num = 0;
        }

        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            Node<T> tmp = new Node<T>(item);
            if (Top == null)
            {
                Top = tmp;
            }
            else
            {
                tmp.Next = Top;
                Top = tmp;
            }
            Num++;
        }

        /// <summary>
        /// 出栈
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException("Stack is empty");
            }
            Node<T> tmp = Top;
            Top = Top.Next;
            Num--;

            return tmp.Data;
        }

        /// <summary>
        /// 获取栈顶元素
        /// </summary>
        /// <returns></returns>
        public T GetTop()
        {
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException("Stack is empty");
            }

            return Top.Data;
        }
    }
}
