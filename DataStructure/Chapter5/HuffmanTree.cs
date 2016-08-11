using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Chapter5
{
    /// <summary>
    /// 哈夫曼树
    /// </summary>
    class HuffmanTree
    {
        private HNode[] data;   //节点数组

        /// <summary>
        /// 叶子节点数量
        /// </summary>
        public int LeafNum { get; private set; }

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public HNode this[int index]
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
        /// <param name="n">叶子节点数量</param>
        public HuffmanTree(int n)
        {
            data = new HNode[2 * n - 1];
            LeafNum = n;
        }

        /// <summary>
        /// 创建哈夫曼树
        /// </summary>
        public void Create()
        {
            int min1, min2;
            int index1, index2;

            for (int i = 0; i < this.LeafNum; i++)
            {
                int w = int.Parse(Console.ReadLine().Trim());
                data[i] = new HNode(w);
            }

            //建立哈弗曼树
            for (int i = 0; i < this.LeafNum - 1; i++)
            {
                min1 = min2 = Int32.MaxValue;
                index1 = index2 = -1;

                for (int j = 0; j < this.LeafNum + i; j++)
                {
                    if (data[j].Parent != -1)
                    {
                        continue;
                    }

                    if (data[j].Weight < min1)
                    {
                        min2 = min1;
                        index2 = index1;

                        min1 = data[j].Weight;
                        index1 = j;
                    }
                    else if (data[j].Weight < min2)
                    {
                        min2 = data[j].Weight;
                        index2 = j;
                    }
                }

                data[index1].Parent = this.LeafNum + i;
                data[index2].Parent = this.LeafNum + i;
                data[this.LeafNum + i] = new HNode(min1 + min2, index1, index2, -1);
            }

            foreach (HNode node in data)
            {
                Console.Write(node.Weight + " ");
            }
            Console.WriteLine();
        }
    }
}
