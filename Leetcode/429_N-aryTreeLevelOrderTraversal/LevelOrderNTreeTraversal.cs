// Given an n-ary tree, return the level order traversal of its nodes' values.
using System;
using System.Collections.Generic;

namespace PostOrderTraversalNs;

public class Node {
    public int val;
    public IList<Node> children;
    public Node(int value, IList<Node> children = null) {
        this.val = value;
        this.children = children;
    }
}

public class Solution
{
    /// <summary>
    /// Level-order the N-ary tree
    /// </summary>
    public static IList<IList<int>> LevelOrder(Node root)
    {
        IList<IList<int>> result = new List<IList<int>>();
        if (root == null) return result;

        IList<Node> currentLevel = new List<Node> { root };

        while (currentLevel.Count > 0)
        {
            IList<int> levelData = new List<int>();

            IList<Node> nextLevel = new List<Node>();

            foreach (Node node in currentLevel)
            {
                levelData.Add(node.val);

                if (node.children != null)
                {
                    foreach (var child in node.children){
                        nextLevel.Add(child);
                    }
                }
            }
            result.Add(levelData);
            currentLevel = nextLevel;
        }

        return result;
    }

    public static void Main(string[] args)
    {
        {
            /*        1
                   /  |  \
                 3   2   4
               / \ 
              5  6
        */
            Node node3 = new Node(3, new List<Node>
                {
                    new Node(5),
                    new Node(6)
                });

            Node root = new Node(1, new List<Node>
                {
                    node3,
                    new Node(2),
                    new Node(4)
                });

            IList<IList<int>> result = LevelOrder(root);
            PrintLevelOrderList(result);
        }

        {
        /*      1
             / |  \  \
           2   3   4   5
              / \  |  /  \
             6   7 8  9  10
                 | |  |
                11 12 13
                 |
                14
        */

            Node node11 = new Node(11, new List<Node> { new Node(14) });
            Node node7 = new Node(7, new List<Node> { node11 });

            Node node3 = new Node(3, new List<Node>
                {
                    new Node(6),
                    node7
                });

            Node node8 = new Node(8, new List<Node> { new Node(12) });
            Node node4 = new Node(4, new List<Node> { node8 });

            Node node9 = new Node(9, new List<Node> { new Node(13) });
            Node node5 = new Node(5, new List<Node> { node9, new Node(10) });

            Node root = new Node(1, new List<Node>
                {
                    new Node(2),
                    node3,
                    node4,
                    node5
                });

            IList<IList<int>> result = LevelOrder(root);
            PrintLevelOrderList(result);
        }
    }

    private static void PrintLevelOrderList(IList<IList<int>> list)
    {
        Console.Write("Level: [");
        foreach (var subList in list){
            Console.Write(" <");
            int index = 0;
            foreach (var i in subList)
            {
                Console.Write($"{i}");
                
                ++index;
                if (index != subList.Count)
                {
                    Console.Write(",");
                }
            }
            Console.Write("> ");
        }
        Console.WriteLine("]");
    }
}