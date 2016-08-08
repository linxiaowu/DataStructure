using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Chapter3
{
    /// <summary>
    /// 顺序栈
    /// </summary>
    /// <![CDATA[]]>
    /// <typeparam name="T"></typeparam>
    class SeqStack<T> : IStack<T>
    {
        private T[] data;       //栈数据

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }

        /// <summary>
        /// 栈最大容量
        /// </summary>
        public int MaxSize { get; set; }

        /// <summary>
        /// 栈顶
        /// </summary>
        public int Top { get; private set; }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="size">栈容量</param>
        public SeqStack(int size)
        {
            data = new T[size];
            MaxSize = size;
            Top = -1;
        }

        /// <summary>
        /// 获取栈长度
        /// </summary>
        /// <returns></returns>
        public int GetLength()
        {
            return Top + 1;
        }

        /// <summary>
        /// 清空栈
        /// </summary>
        public void Clear()
        {
            Top = -1;
        }

        /// <summary>
        /// 栈是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return Top.Equals(-1);
        }

        /// <summary>
        /// 判断栈是否已满
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            return Top.Equals(MaxSize - 1);
        }

        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            if (IsFull())
            {
                throw new IndexOutOfRangeException("Stack is full");
            }

            data[++Top] = item;
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
            return data[Top--];
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
            return data[Top];
        }
    }
}
