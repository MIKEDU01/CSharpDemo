using System;
using System.Collections.Generic;
using System.Drawing;

namespace CSharpDemo
{
    class MvNode
    {
        public int Index { get; set; }

        public Point Point { get; set; }

        public Dictionary<MvNode, MvNodesData> ConnectedNodes { get; } = new Dictionary<MvNode, MvNodesData>();

        /// <summary>
        /// 状态 TRUE表示被使用
        /// </summary>
        public bool Flag { get; set; }

        /// <summary>
        /// 链接的节点数量
        /// </summary>
        public int ConnectedNodesNum => ConnectedNodes.Count;

        public double Distance(MvNode node)
        {
            return Math.Sqrt(Math.Pow((this.Point.X - node.Point.X), 2) + Math.Pow((this.Point.Y - node.Point.Y), 2));
        }

        public double Angle(MvNode node)
        {
            return Math.Atan2(node.Point.Y - Point.Y, node.Point.X - Point.X) * 180 / Math.PI;
        }

        public override string ToString()
        {
            return $"Index={Index} Point={Point} ConnectedNodes={ConnectedNodes.Count}";
        }
    }

    class MvNodesData
    {
        public double Distance { get; set; }

        public double Angle { get; set; }

        public MvNodesData(double distance, double angle)
        {
            Distance = distance;
            Angle = angle;

            if (Angle < 0)
            {
                Angle += 360;
            }
        }

        public override string ToString()
        {
            return $"Distance={Distance:F3} Angle={Angle}";
        }
    }

    class MvPath
    {
        /// <summary>
        /// 当前路径的第2个节点连接的节点数量
        /// </summary>
        public int NodeNum => Nodes.Count;

        /// <summary>
        /// 当前路径的第2个节点为起点的节点数量
        /// </summary>
        public int PathNum => Paths.Count;

        /// <summary>
        /// 当前路径的第1个节点
        /// </summary>
        public MvNode FirstNode { get; set; }

        /// <summary>
        /// 当前路径的第2个节点
        /// </summary>
        public MvNode SecondNode { get; set; }

        /// <summary>
        /// 当前路径连接的“节点”的数量(即：该节点是终点，没有连接其他节点)
        /// 此时，该路径第1个点和第2个点与该集合内的点，可组成3个点的路径；
        /// 路径数量即为集合中节点的个数
        /// </summary>
        /// <returns></returns>
        public List<MvNode> Nodes { get; } = new List<MvNode>();

        /// <summary>
        /// 路径点1和点2为起始点，连接的路径数量；
        /// 此时，点2为新的路径的起点；点2的子节点依次为新路径的第2个点
        /// </summary>
        /// <returns></returns>
        public List<MvPath> Paths { get; } = new List<MvPath>();

        /// <summary>
        /// 父节点
        /// </summary>
        public MvPath Parent { get; set; } 

        public string Key { get; }

        /// <summary>
        /// 路径
        /// </summary>
        /// <param name="node1">路径第1个点</param>
        /// <param name="node2">路径第2个点</param>
        public MvPath(MvNode node1, MvNode node2)
        {
            FirstNode = node1;
            SecondNode = node2;
            Key = node1.Index + " - " + node2.Index;
        }

        public override string ToString()
        {
            return $"FirstIndex={FirstNode.Index} SecondIndex={SecondNode.Index} NodeNum={NodeNum} PathNum={PathNum}";
        }
    }
}