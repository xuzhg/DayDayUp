// You are given a 2D integer array descriptions where descriptions[i] = [parenti, childi, isLefti] indicates that parenti is the parent of childi in a binary tree of unique values. Furthermore,

//If isLefti == 1, then childi is the left child of parenti.
// If isLefti == 0, then childi is the right child of parenti.
// Construct the binary tree described by descriptions and return its root.

// The test cases will be generated such that the binary tree is valid.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    public class TreeNodeItem
    {
        public bool HasParent { get; set; }

        public TreeNode Node { get; set; }
    }

    public static TreeNode CreateBinaryTree(int[][] descriptions)
    {
        if (descriptions == null) return null;

        // be noted, the value is unique, so we can use the dictionary
        IDictionary<int, TreeNodeItem> nodes = new Dictionary<int, TreeNodeItem>();

        for (int i = 0; i < descriptions.Length; ++i)
        {
            if (descriptions[i].Length != 3)
            {
                return null; // it's not a valid
            }

            TreeNodeItem parent = GetOrCreateNode(descriptions[i][0], nodes);
            TreeNodeItem child = GetOrCreateNode(descriptions[i][1], nodes);
            child.HasParent = true;

            if (descriptions[i][2] == 1)
            {
                parent.Node.left = child.Node;
            }
            else
            {
                parent.Node.right = child.Node;
            }
        }

        // Make sure there's only one node without parent
        TreeNodeItem rootItem = nodes.FirstOrDefault(n => !n.Value.HasParent).Value;

        return rootItem == null ? null : rootItem.Node;
    }

    public static TreeNodeItem GetOrCreateNode(int val, IDictionary<int, TreeNodeItem> nodes)
    {
        if (nodes.ContainsKey(val))
        {
            return nodes[val];
        }
        else
        {
            TreeNodeItem newItem = new TreeNodeItem
            {
                HasParent = false,
                Node = new TreeNode(val)
            };
            nodes[val] = newItem;
            return newItem;
        }
    }

    public static void Main(string[] args)
    {
        {
            int[][] descriptions =
                {
                    new int[] {20, 15, 1},
                    new int[] {20, 17, 0},
                    new int[] {50, 20, 1},
                    new int[] {50, 80, 0},
                    new int[] {80, 19, 1}
                };

            TreeNode root = CreateBinaryTree(descriptions);

            Console.Write("Preorder: [ ");
            PrintPreorderRecursively(root);
            Console.WriteLine("]");

            Console.Write("Inorder: [ ");
            PrintInorderRecursively(root);
            Console.WriteLine("]");
        }

         {
            int[][] descriptions =
                {
                    new int[] {1, 2, 1},
                    new int[] {2, 3, 0},
                    new int[] {3, 4, 1}
                };

            TreeNode root = CreateBinaryTree(descriptions);

            Console.Write("Preorder: [ ");
            PrintPreorderRecursively(root);
            Console.WriteLine("]");

            Console.Write("Inorder: [ ");
            PrintInorderRecursively(root);
            Console.WriteLine("]");
        }
    }

    private static void PrintPreorderRecursively(TreeNode node)
    {
        if (node == null) return;

        Console.Write($"{node.val},");

        PrintPreorderRecursively(node.left);
        PrintPreorderRecursively(node.right);
    }

    private static void PrintInorderRecursively(TreeNode node)
    {
        if (node == null) return;

        PrintInorderRecursively(node.left);

        Console.Write($"{node.val},");

        PrintInorderRecursively(node.right);
    }
}