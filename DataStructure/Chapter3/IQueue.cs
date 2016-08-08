using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Chapter3
{
    /// <summary>
    /// 队列接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IQueue<T>
    {
        /// <summary>
        /// 获取队列长度
        /// </summary>
        /// <returns></returns>
        int GetLength();

        /// <summary>
        /// 判断队列是否为空
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();

        /// <summary>
        /// 清空队列
        /// </summary>
        void Clear();

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="item"></param>
        void In(T item);

        /// <summary>
        /// 出队
        /// </summary>
        /// <returns></returns>
        T Out();

        /// <summary>
        /// 或取队头元素
        /// </summary>
        /// <returns></returns>
        T GetFront();
    }
}
