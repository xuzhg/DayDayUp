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

    public static int MinCostConnectPoints(int[][] points)
    {

        int pointCount = points.Length;
        int[] nodes = new int[pointCount];
        for (int i = 0; i < pointCount; ++i)
        {
            nodes[i] = -1; // location is the point index, the value is its parent index, -1 mean it hasn't any parent.
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
                nodes[p1] = -2; // a head label
                nodes[p2] = p1;
                totalCost += link.Cost;
            }
            else if (nodes[p1] == -1)
            {
                if (nodes[p2] == -2)
                {
                    nodes[p2] = p1;
                    nodes[p1] = -2;
                }
                else
                {
                    nodes[p1] = p2;
                }

                totalCost += link.Cost;
            }
            else if (nodes[p2] == -1)
            {
                if (nodes[p1] == -2)
                {
                    nodes[p1] = p2;
                    nodes[p2] = -2;
                }
                else
                {
                    nodes[p2] = p1;
                }

                totalCost += link.Cost;
            }
            else
            {
                if (!IsLoop(nodes, link))
                {
                    // Let's merge
                    int k = p2;
                    while (nodes[k] != -2)
                    {
                        k = nodes[k];
                    }
                    nodes[k] = p1;

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

    private static bool IsLoop(int[] nodes, Link link)
    {
        int p1 = link.P1;
        int p2 = link.P2;
        ISet<int> set = new HashSet<int>();
        set.Add(p1);
        while (nodes[p1] != -2)
        {
            set.Add(nodes[p1]);
            p1 = nodes[p1];
        }

        if (set.Contains(p2)) return true;

        while (nodes[p2] != -2)
        {
            if (set.Contains(nodes[p2]))
            {
                return true;
            }

            p2 = nodes[p2];
        }

        return false;
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
    }
}