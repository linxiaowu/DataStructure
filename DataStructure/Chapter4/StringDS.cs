using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Chapter4
{
    /// <summary>
    /// 串
    /// </summary>
    class StringDS
    {
        private char[] data;    //字符数组

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public char this[int index]
        {
            get
            {
                return data[index];
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="arr"></param>
        public StringDS(char[] arr)
        {
            data = new char[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                data[i] = arr[i];
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="s"></param>
        public StringDS(StringDS s)
        {
            for (int i = 0; i < s.GetLength(); i++)
            {
                data[i] = s[i];
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="len"></param>
        public StringDS(int len)
        {
            data = new char[len];
        }

        /// <summary>
        /// 求串长
        /// </summary>
        /// <returns></returns>
        public int GetLength()
        {
            return data.Length;
        }

        /// <summary>
        /// 串比较
        /// </summary>
        /// <![CDATA[如果两个串的长度相等并且对应位置的字符相同，则串相等，返回0；如果串s对应位置的字符大于该串的字符或者如果串s的长度大于该串，而在该串的长度返回内二者对应位置的字符相同，则返回-1，该串小于串s；其余情况返回1，该串大于串s。]]>
        /// <param name="s"></param>
        /// <returns></returns>
        public int Compare(StringDS s)
        {
            int len = this.GetLength() < s.GetLength() ? this.GetLength() : s.GetLength();

            for (int i = 0; i < len; i++)
            {
                if (this[i] == s[i])
                {
                    continue;
                }

                if (this[i] < s[i])
                {
                    return -1;
                }
                return 1;
            }

            if (this.GetLength() == s.GetLength())
            {
                return 0;
            }
            return this.GetLength() < s.GetLength() ? -1 : 1;
        }

        /// <summary>
        /// 求子串
        /// </summary>
        /// <param name="index">起始位置</param>
        /// <param name="len">截取长度</param>
        /// <returns></returns>
        public StringDS SubString(int index, int len)
        {
            if (index < 0 || index > this.GetLength() - 1 || len < 0 || len + index > this.GetLength())
            {
                throw new Exception("Position or Length is error!");
            }

            char[] arr = new char[len];
            for (int i = 0; i < len; i++)
            {
                arr[i] = this[index + i];
            }
            return new StringDS(arr);
        }

        /// <summary>
        /// 字符串连接
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public StringDS Concat(StringDS s)
        {
            char[] arr = new char[this.GetLength() + s.GetLength()];
            for (int i = 0; i < this.GetLength(); i++)
            {
                arr[i] = this[i];
            }

            for (int i = 0; i < s.GetLength(); i++)
            {
                arr[this.GetLength() + i] = s[i];
            }
            return new StringDS(arr);
        }

        /// <summary>
        /// 串插入
        /// </summary>
        /// <param name="index"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public StringDS Insert(int index, StringDS s)
        {
            if (index < 0 || index > this.GetLength() - 1)
            {
                throw new Exception("Position is error!");
            }

            char[] arr = new char[s.GetLength() + this.GetLength()];
            for (int i = 0; i < index; i++)
            {
                arr[i] = this[i];
            }

            for (int i = 0; i < s.GetLength(); i++)
            {
                arr[index + i] = s[i];
            }

            for (int i = index; i < this.GetLength(); i++)
            {
                arr[s.GetLength() + i] = this[i];
            }
            return new StringDS(arr);
        }

        /// <summary>
        /// 串删除
        /// </summary>
        /// <param name="index"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public StringDS Delete(int index, int len)
        {
            if (index < 0 || index > this.GetLength() - 1 || len < 0 || len + index > this.GetLength())
            {
                throw new Exception("Position or Length is error!");
            }
            char[] arr = new char[this.GetLength() - len];

            for (int i = 0; i < index; i++)
            {
                arr[i] = this[i];
            }

            for (int i = index; i < this.GetLength() - len; i++)
            {
                arr[i] = this[i + len];
            }
            return new StringDS(arr);
        }

        /// <summary>
        /// 串定位
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int Index(StringDS s)
        {
            if (this.GetLength() < s.GetLength())
            {
                throw new Exception("There is not string s");
            }
            int i = 0;
            for (; i <= this.GetLength() - s.GetLength(); i++)
            {
                StringDS sub = this.SubString(i, s.GetLength());
                if (sub.Compare(s) == 0)
                {
                    break;
                }
            }

            if (i <= this.GetLength() - s.GetLength())
            {
                return i;
            }
            return -1;
        }
    }
}
