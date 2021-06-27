using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Point[] points = new Point[7];
            points[0] = new Point(0, 0);
            points[1] = new Point(10, 0);
            points[2] = new Point(-10, 0);
            points[3] = new Point(0, 10);
            points[4] = new Point(0, -10);
            points[5] = new Point(20, 0);
            points[6] = new Point(30, 0);

            int len = points.Length;

            MvNode[] nodes = new MvNode[len];

            for (int i = 0; i < len; i++)
            {
                nodes[i] = new MvNode() { Point = points[i], Index = i };
            }

            double distance = 0;
            double angle = 0;

            for (int i = 0; i < len - 1; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    distance = nodes[i].Distance(nodes[j]);

                    if (distance <= 10)
                    {
                        angle = nodes[i].Angle(nodes[j]);

                        nodes[i].ConnectedNodes.Add(nodes[j], new MvNodesData(distance, angle));
                        nodes[j].ConnectedNodes.Add(nodes[i], new MvNodesData(distance, angle + 180));
                    }
                }
            }

            List<MvPath> paths = new List<MvPath>();

            for (int i = 0; i < len; i++)
            {
                if (nodes[i].ConnectedNodesNum < 1)
                {
                    continue;
                }

                nodes[i].Flag = true;

                foreach (var obj in nodes[i].ConnectedNodes)
                {
                    obj.Key.Flag = true;

                    if (GetPaths(nodes, nodes[i], obj.Key, out MvPath res))
                    {
                        res.Parent = null;
                        paths.Add(res);
                    }

                    obj.Key.Flag = false;
                }

                nodes[i].Flag = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodes">全部节点数组</param>
        /// <param name="nFirstIndex">第1个点索引</param>
        /// <param name="nSecondIndex">第2个点索引</param>
        /// <param name="paths"></param>
        /// <returns></returns>
        private bool GetPaths(MvNode[] nodes, MvNode mFirstNode, MvNode mSecondNode, out MvPath path)
        {
            int len = mSecondNode.ConnectedNodesNum;
            path = new MvPath(mFirstNode, mSecondNode);

            // 第2个点连接的节点数量若为1，则该点应该为第1个点；因此，返回
            if (len <= 1)
            {
                return false;
            }
            else
            {
                // 第1个点到第2个点的角度
                double angle12 = mFirstNode.ConnectedNodes[mSecondNode].Angle;
                double angle23 = 0;

                // 遍历第2个节点连接的全部节点，即可能是第3个点
                foreach (var obj in mSecondNode.ConnectedNodes)
                {
                    // 该节点已经被占用；有可能是第2节点
                    if (obj.Key.Flag)
                    {
                        continue;
                    }

                    angle23 = mSecondNode.ConnectedNodes[obj.Key].Angle;

                    double intersectAngle = Math.Abs(angle12 - angle23);

                    if (intersectAngle > 180)
                    {
                        intersectAngle = 360 - intersectAngle;
                    }

                    if (intersectAngle > 10)
                    {
                        continue;
                    }

                    // 该节点(第3节点)只有1个连接的节点，说明是第2节点；
                    // 因此,这是符合条件的第3个点
                    if (obj.Key.ConnectedNodesNum == 1)
                    {
                        // 这是第3个点                        
                        path.Nodes.Add(obj.Key);
                    }
                    else
                    {
                        obj.Key.Flag = true;

                        // 以第2个点为起点，第2个点的子节点为第2个点：获得新的路径
                        if (GetPaths(nodes, mSecondNode, obj.Key, out MvPath res))
                        {
                            res.Parent = path;
                            path.Paths.Add(res);
                        }

                        obj.Key.Flag = false;
                    }
                }
            }

            return path.NodeNum > 0 || path.PathNum > 0;
        }
    }
}
