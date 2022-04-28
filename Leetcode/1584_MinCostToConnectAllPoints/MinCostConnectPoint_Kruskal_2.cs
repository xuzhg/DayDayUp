/*
You are given an array points representing integer coordinates of some points on a 2D-plane, where points[i] = [xi, yi].

The cost of connecting two points [xi, yi] and [xj, yj] is the manhattan distance between them: |xi - xj| + |yi - yj|, where |val| denotes the absolute value of val.

Return the minimum cost to make all points connected. All points are connected if there is exactly one simple path between any two points.
*/
using System;
using System.Collections.Generic;

public class Link : IComparable<Link>
{
    public Link(int p1, int p2, int cost)
    {
        P1 = p1;
        P2 = p2;
        Cost = cost;
    }
    public int P1 { get; }
    public int P2 { get; }
    public int Cost { get; }

    public int CompareTo(Link other)
    {
        if (other == null || this.Cost > other.Cost)
        {
            return 1; // greater
        }
        else if (this.Cost < other.Cost)
        {
            return -1;
        }

        return 0;
    }
}

public class Solution5
{
    // 在第1个版本中，由于我们每个节点记录的是前一个节点的index，所以我们在判断两个point是不是Loop时候要去
    // 查找是不是有共同的祖先，当数据量很大是，效率就很低。
    // 其实我们可以修改把每个节点记录的是它的父节点的index，这样就不需要search，
    // 因为我们可以快速的来判断两个节点是不是属于同一个树
    // 同时我们也可以快速的链接两个子树
    public static int MinCostConnectPoints(int[][] points)
    {
        int pointCount = points.Length;
        int[] nodes = new int[pointCount];
        for (int i = 0; i < pointCount; ++i)
        {
            nodes[i] = -1; // location is the point index, the value is its root index, -1 mean it hasn't root.
        }

        Link[] allLinks = GetLinks(points);
        Array.Sort(allLinks);

        int totalCost = 0;
        for (int i = 0; i < allLinks.Length; ++i)
        {
            Link link = allLinks[i];
            int p1 = link.P1;
            int p2 = link.P2;
            if (nodes[p1] == -1 && nodes[p2] == -1)
            {
                // The whole link is new to the whole graph, 
                // Add it into
                nodes[p1] = p1; // a head label
                nodes[p2] = p1;
                totalCost += link.Cost;
            }
            else if (nodes[p1] == -1)
            {
                nodes[p1] = nodes[p2];
                totalCost += link.Cost;
            }
            else if (nodes[p2] == -1)
            {
                nodes[p2] = nodes[p1];
                totalCost += link.Cost;
            }
            else
            {
                if (nodes[p1] == nodes[p2])
                {
                    // they have same root, it's a loop, skip it.
                }
                else
                {
                    int mergeRoot = nodes[p2];
                    for (int j = 0; j < nodes.Length; ++j)
                    {
                        // 把所有节点的父节点是p2父节点的改成都是以p1父节点
                        if (nodes[j] == mergeRoot)
                        {
                            nodes[j] = nodes[p1];
                        }
                    }

                    totalCost += link.Cost;
                }
            }
        }

        return totalCost;
    }

    private static Link[] GetLinks(int[][] points)
    {

        int pointCount = points.Length;
        Link[] links = new Link[pointCount * (pointCount - 1) / 2];
        int index = 0;
        for (int i = 0; i < pointCount; ++i)
        {
            for (int j = i + 1; j < pointCount; ++j)
            {
                int cost = Math.Abs(points[j][0] - points[i][0]) + Math.Abs(points[j][1] - points[i][1]);
                links[index++] = new Link(i, j, cost);
            }
        }

        return links;
    }


    public static void Main(string[] args)
    {
        int[][] points = new int[][] {
            new int[] {0, 0},
            new int[] {2, 2},
            new int[] {3, 10},
            new int[] {5, 2},
            new int[] {7, 0},
        };
        Console.WriteLine($"{MinCostConnectPoints(points)} == 20");

        int[][] points2 = new int[][] {
            new int[] {2, -3},
            new int[] {-17,-8},
            new int[] {13,8},
            new int[] {-17,-15}
        };

        Console.WriteLine($"{MinCostConnectPoints(points2)} == 53");
    }
}