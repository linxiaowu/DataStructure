using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Chapter3
{
    /// <summary>
    /// 循环顺序队列
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class CSeqQueue<T> : IQueue<T>
    {
        private int Maxsize;    //队列最大容量
        private T[] data;       //队列元素数组

        /// <summary>
        /// 队首
        /// </summary>
        public int Front { get; set; }

        /// <summary>
        /// 队尾
        /// </summary>
        public int Rear { get; set; }

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
        /// 构造函数
        /// </summary>
        /// <param name="size">队列容量</param>
        public CSeqQueue(int size)
        {
            data = new T[size];
            Maxsize = size;
            Front = Rear = -1;
        }

        /// <summary>
        /// 获取队列长度
        /// </summary>
        /// <returns></returns>
        public int GetLength()
        {
            return (Rear - Front + Maxsize) % Maxsize;
        }

        /// <summary>
        /// 队列是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return Rear == Front;
        }

        /// <summary>
        /// 清空队列
        /// </summary>
        public void Clear()
        {
            Rear = Front = -1;
        }

        /// <summary>
        /// 队列是否已满
        /// </summary>
        /// <returns></returns>
        private bool IsFull()
        {
            return (Rear + 1) % Maxsize == Front;
        }

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="item"></param>
        public void In(T item)
        {
            if (IsFull())
            {
                throw new IndexOutOfRangeException("Queue is full");
            }
            data[++Rear] = item;
        }

        /// <summary>
        /// 出队
        /// </summary>
        /// <returns></returns>
        public T Out()
        {
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException("Queue is empty");
            }
            return data[++Front];
        }

        /// <summary>
        /// 获取队首元素
        /// </summary>
        /// <returns></returns>
        public T GetFront()
        {
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException("Queue is empty");
            }
            return data[Front + 1];
        }
    }
}
