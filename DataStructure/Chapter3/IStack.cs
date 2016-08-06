using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Chapter3
{
    /// <summary>
    /// 栈
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IStack<T>
    {
        /// <summary>
        /// 栈长度
        /// </summary>
        /// <returns></returns>
        int GetLength();

        /// <summary>
        /// 栈是否为空
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();

        /// <summary>
        /// 清空栈
        /// </summary>
        void Clear();

        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="item"></param>
        void Push(T item);

        /// <summary>
        /// 出栈
        /// </summary>
        /// <returns></returns>
        T Pop();

        /// <summary>
        /// 获取栈顶元素
        /// </summary>
        /// <returns></returns>
        T GetPop();
    }
}
