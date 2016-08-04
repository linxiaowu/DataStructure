using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Chapter2
{
    /// <summary>
    /// 单链表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class LinkList<T> : IListDS<T>
    {
        /// <summary>
        /// 单链表头
        /// </summary>
        public Node<T> Head { get; set; }

        /// <summary>
        /// 构造器
        /// </summary>
        public LinkList()
        {
            this.Head = null;
        }

        /// <summary>
        /// 获取单链表长度
        /// </summary>
        /// <returns></returns>
        public int GetLength()
        {
            Node<T> cur = Head;
            int len = 0;
            while (cur != null)
            {
                len++;
                cur = cur.Next;
            }
            return len;
        }

        /// <summary>
        /// 清空链表
        /// </summary>
        public void Clear()
        {
            Head = null;
        }

        /// <summary>
        /// 链表是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return Head == null;
        }

        /// <summary>
        /// 链表尾部添加元素
        /// </summary>
        /// <param name="item"></param>
        public void Append(T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (Head == null)
            {
                Head = newNode;
                return;
            }

            Node<T> tmpNode = new Node<T>();
            tmpNode = Head;
            while (tmpNode.Next != null)
            {
                tmpNode = tmpNode.Next;
            }
            tmpNode.Next = newNode;
        }

        /// <summary>
        /// 单链表指定位置插入数据
        /// </summary>
        /// <param name="item">数据</param>
        /// <param name="index">位置</param>
        public void Insert(T item, int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Position is error");
            }

            Node<T> newNode = new Node<T>(item);
            if (index.Equals(0))
            {
                newNode.Next = Head;
                Head = newNode;
                return;
            }

            Node<T> cur = Head;
            int i = 0;
            //找到指定位置的前一个位置即可
            while (cur.Next != null && i < index - 1)
            {
                i++;
                cur = cur.Next;
            }

            if (cur.Next == null)
            {
                cur.Next = newNode;
            }
            else
            {
                Node<T> tmp = cur.Next;
                cur.Next = newNode;
                newNode.Next = tmp;
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

        public void Reverse()
        {
            throw new NotImplementedException();
        }
    }
}
