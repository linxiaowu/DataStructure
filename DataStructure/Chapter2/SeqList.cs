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
        private T[] data;

        /// <summary>
        /// 顺序表中的最后一个元素位置
        /// </summary>
        private int last;

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
        /// <param name="size">顺序表最大长度</param>
        public SeqList(int size)
        {
            this.data = new T[size];
            this.Maxsize = size;
            this.last = -1;
        }

        /// <summary>
        /// 获取顺序表元素个数
        /// </summary>
        /// <returns></returns>
        public int GetLength()
        {
            return last + 1;
        }

        /// <summary>
        /// 清空顺序表
        /// </summary>
        public void Clear()
        {
            last = -1;
        }

        /// <summary>
        /// 判断顺序表是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return last.Equals(-1);
        }

        /// <summary>
        /// 判断顺序表是否已满
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            return last.Equals(Maxsize - 1);
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
            data[++last] = item;
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

            if (index < 0 || index > last + 1)
            {
                throw new IndexOutOfRangeException("Position is error");
            }

            if (index.Equals(last + 1))
            {
                data[++last] = item;
                return;
            }

            for (int i = last; i >= index; i--)
            {
                data[i + 1] = data[i];
            }
            data[index] = item;
            ++last;
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

            if (index < 0 || index > last)
            {
                throw new IndexOutOfRangeException("Position is error");
            }

            if (index.Equals(last))
            {
                return data[last--];
            }

            T tmp = data[index];
            for (int i = index; i <= last; i++)
            {
                data[i] = data[i + 1];
            }
            --last;
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

            if (index < 0 || index > last)
            {
                throw new IndexOutOfRangeException("Position is error");
            }
            return data[index];
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

            for (int i = 0; i <= last; i++)
            {
                if (value.Equals(data[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 倒置线性表
        /// </summary>
        public void Reverse()
        {
            T tmp = default(T);

            int len = GetLength() - 1;
            for (int i = 0; i <= len / 2; i++)
            {
                if (i.Equals(len - i))
                {
                    break;
                }

                tmp = data[i];
                data[i] = data[len - i];
                data[len - i] = tmp;
                //Data[i] = Data[len - i] - Data[i];
                //Data[len - i] = Data[len - i] - Data[i];
                //Data[i] = Data[len - i] + Data[i];
            }
        }
    }
}
