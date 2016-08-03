using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Chapter2
{
    /// <summary>
    /// 顺序表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class SeqList<T> : IListDS<T>
    {
        /// <summary>
        /// 顺序表最大容量
        /// </summary>
        public int Maxsize { get; private set; }

        /// <summary>
        /// 顺序表中的数据数组
        /// </summary>
        public T[] Data { get; set; }

        /// <summary>
        /// 顺序表中的最后一个元素位置
        /// </summary>
        public int Last { get; private set; }

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                return Data[index];
            }
            set
            {
                Data[index] = value;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="size">顺序表最大长度</param>
        public SeqList(int size)
        {
            this.Data = new T[size];
            this.Maxsize = size;
            this.Last = -1;
        }

        /// <summary>
        /// 获取顺序表元素个数
        /// </summary>
        /// <returns></returns>
        public int GetLength()
        {
            return this.Last + 1;
        }

        /// <summary>
        /// 清空顺序表
        /// </summary>
        public void Clear()
        {
            this.Last = -1;
        }

        /// <summary>
        /// 判断顺序表是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this.Last.Equals(-1);
        }

        /// <summary>
        /// 判断顺序表是否已满
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            return this.Last.Equals(this.Maxsize - 1);
        }

        /// <summary>
        /// 在顺序表末尾添加元素
        /// </summary>
        /// <param name="item">元素</param>
        public void Append(T item)
        {
            if (IsFull())
            {
                throw new IndexOutOfRangeException("List is full");
            }
            this.Data[++this.Last] = item;
        }

        /// <summary>
        /// 在顺序表指定位置插入元素
        /// </summary>
        /// <param name="item">元素</param>
        /// <param name="index">插入位置</param>
        public void Insert(T item, int index)
        {
            if (IsFull())
            {
                throw new IndexOutOfRangeException("List is full");
            }
        }

        public T Delete(int index)
        {
            throw new NotImplementedException();
        }

        public T GetElem(int index)
        {
            throw new NotImplementedException();
        }

        public int Locate(T value)
        {
            throw new NotImplementedException();
        }
    }
}
