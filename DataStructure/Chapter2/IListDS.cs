using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Chapter2
{
    /// <summary>
    /// 线性表接口
    /// </summary>
    interface IListDS<T>
    {
        /// <summary>
        /// 获取线性表元素个数
        /// </summary>
        /// <returns></returns>
        int GetLength();

        /// <summary>
        /// 清除列表
        /// </summary>
        void Clear();

        /// <summary>
        /// 线性表是否为空
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();

        /// <summary>
        /// 附加元素
        /// </summary>
        /// <param name="item">元素</param>
        void Append(T item);

        /// <summary>
        /// 插入元素
        /// </summary>
        /// <param name="item">元素</param>
        /// <param name="index">插入位置</param>
        void Insert(T item, int index);

        /// <summary>
        /// 删除元素
        /// </summary>
        /// <param name="index">被删除元素位置</param>
        /// <returns>被删除元素</returns>
        T Delete(int index);

        /// <summary>
        /// 获取元素
        /// </summary>
        /// <param name="index">元素位置</param>
        /// <returns>指定位置元素</returns>
        T GetElem(int index);

        /// <summary>
        /// 按值查找元素
        /// </summary>
        /// <param name="value">值</param>
        /// <returns>线性表中首次出现时的位置</returns>
        int Locate(T value);
    }
}
