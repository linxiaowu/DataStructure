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

            if (index < 0 || index > Last + 1)
            {
                throw new IndexOutOfRangeException("Position is error");
            }

            if (index.Equals(Last + 1))
            {
                Data[++Last] = item;
                return;
            }

            for (int i = Last; i >= index; i--)
            {
                Data[i + 1] = Data[i];
            }
            Data[index] = item;
            ++Last;
        }

        /// <summary>
        /// 删除制定位置元素
        /// </summary>
        /// <param name="index">元素位置</param>
        /// <returns></returns>
        public T Delete(int index)
        {
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException("List is empty");
            }

            if (index < 0 || index > Last)
            {
                throw new IndexOutOfRangeException("Position is error");
            }

            if (index.Equals(Last))
            {
                return Data[Last--];
            }

            T tmp = Data[index];
            for (int i = index; i <= Last; i++)
            {
                Data[i] = Data[i + 1];
            }
            --Last;
            return tmp;
        }

        /// <summary>
        /// 获取指定位置元素
        /// </summary>
        /// <param name="index">元素位置</param>
        /// <returns></returns>
        public T GetElem(int index)
        {
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException("List is empty");
            }

            if (index < 0 || index > Last)
            {
                throw new IndexOutOfRangeException("Position is error");
            }
            return Data[index];
        }

        /// <summary>
        /// 根据值查找元素位置
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Locate(T value)
        {
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException("List is empty");
            }

            for (int i = 0; i <= Last; i++)
            {
                if (value.Equals(Data[i]))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
