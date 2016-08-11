using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Chapter5
{
    /// <summary>
    /// 哈夫曼树节点
    /// </summary>
    class HNode
    {
        /// <summary>
        /// 节点权值
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// 左孩子位置
        /// </summary>
        public int LChild { get; set; }

        /// <summary>
        /// 右孩子位置
        /// </summary>
        public int RChild { get; set; }

        /// <summary>
        /// 父节点位置
        /// </summary>
        public int Parent { get; set; }

        /// <summary>
        /// 构造方法
        /// </summary>
        public HNode()
        {
            this.Weight = 0;
            this.LChild = -1;
            this.RChild = -1;
            this.Parent = -1;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="weight"></param>
        public HNode(int weight)
        {
            this.Weight = weight;
            this.LChild = -1;
            this.RChild = -1;
            this.Parent = -1;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="weight">节点权重</param>
        /// <param name="lc">左孩子位置</param>
        /// <param name="rc">右孩子位置</param>
        /// <param name="parent">父节点位置</param>
        public HNode(int weight, int lc, int rc, int parent)
        {
            this.Weight = weight;
            this.LChild = lc;
            this.RChild = rc;
            this.Parent = parent;
        }
    }
}
