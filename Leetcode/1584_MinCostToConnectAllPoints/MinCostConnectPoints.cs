/*
You are given an array points representing integer coordinates of some points on a 2D-plane, where points[i] = [xi, yi].

The cost of connecting two points [xi, yi] and [xj, yj] is the manhattan distance between them: |xi - xj| + |yi - yj|, where |val| denotes the absolute value of val.

Return the minimum cost to make all points connected. All points are connected if there is exactly one simple path between any two points.
*/
using System;

public class GNode{
    public int Index { get; set; }
    public int ParentIndex {get; set;}

    public int Cost {get;set;}
}
public class Solution {

    // Dijstra Algorith is not correct here for this question. 
    // So the following imeplmentation is not finished and not correct.
    public static int MinCostConnectPoints(int[][] points) {
        int pointCount = points.Length;
        if (pointCount == 0) return 0;

        IDictionary<int, GNode> map = new Dictionary<int, GNode>();
        nodes.Add(new GNode { Index = 0, ParentIndex = -1, Cost = 0 });
        ISet<int> visited = new HashSet<int>();

        while(map.Count > 0) {
            // We always make sure the first one is the least node
            GNode leastNode = nodes[0];
            nodes.RemoveAt(0);
            visited.Add(leastNode.Index);

            for (int i = 0; i < nodes.Count; i++){
                if (i == leastnode.Index) continue;
                if (visited.Contains(i)) continue;

                int segCost = abs(points[i][0] - points[leastnode.Index][0]) + 
                    abs(points[i][1] - points[leastnode.Index][1]) + leastNode.Cost;

                AddOrUpdateNode(map, i, leastnode.Index, segCost);
            }
        }
    }

    private static GNode GetLeastCostNode(IDictionary<int, GNode> map)
    {
        int leastIndex;
        int minCost = int.MaxValue;
        foreach (var node in map)
        {
            if (node.Value.Cost < minCost) {
                leastIndex = node.Key;
                minCost = node.Value.Cost;
            }
        }

        GNode leastNode = map[leastIndex];
        map.Remove(leastIndex);
        return leastNode;
    }

    private static void AddOrUpdateNode(IDictionary<int, GNode> map, int currIndex, int parentIndex, int cost){
        if (map.TryGetValue(currIndex, out GNode node)) {
            if (node.Cost > cost) {
                node.Cost = cost;
                node.ParentIndex = parentIndex;
            }
        }
        else {
            map[currIndex] = new GNode { Index = currIndex, ParentIndex = parentIndex, Cost = cost };
        }
    }

    public static void Main(string[] args) {

    }
}