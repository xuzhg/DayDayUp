using System;
using System.Collections.Generic;

namespace PreOrderTraversalNs;

public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int value, TreeNode left = null, TreeNode right = null) {
        this.val = value;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    /// <summary>
    /// Pre-order the binary tree without using recursively
    /// </summary>
    public static IList<int> PreorderTraversalIteratorly(TreeNode root)
    {
        IList<int> result = new List<int>();
        if (root == null) return result;

        Stack<TreeNode> stack = new();
        stack.Push(root);
        while (stack.Count != 0)
        {
            TreeNode node = stack.Pop(); // return the topone and 
            result.Add(node.val);

            if (node.right != null)
            {
                stack.Push(node.right);
            }

            if (node.left != null)
            {
                stack.Push(node.left);
            }
        }

        return result;
    }

    /// <summary>
    /// Pre-order the binary tree without using recursively
    /// </summary>
    public static IList<int> PreorderTraversalRecursively(TreeNode root)
    {
        IList<int> result = new List<int>();
        PreorderRecursively(root, result);
        return result;
    }

    private static void PreorderRecursively(TreeNode node, IList<int> result)
    {
        if (node == null) return;

        result.Add(node.val);

        PreorderRecursively(node.left, result);
        PreorderRecursively(node.right, result);
    }

    public static void Main(string[] args)
    {
        {
            // Test 1
            TreeNode root = new TreeNode(1, 
                null, new TreeNode(2, new TreeNode(3)));
            
            IList<int> result = PreorderTraversalRecursively(root);
            PrintPreorderList(result);

            result = PreorderTraversalIteratorly(root);
            PrintPreorderList(result);
        }

        {
        /*    2
            /  \
           7     5
           \      \
            6      9
            / \    /
            1  11 4
        */

            TreeNode root = new TreeNode(2);
            TreeNode node7 = root.left = new TreeNode(7);
            TreeNode node5 = root.right = new TreeNode(5);

            TreeNode node6 = node7.right = new TreeNode(6);
            node6.left = new TreeNode(1);
            node6.right = new TreeNode(11);

            TreeNode node9 = node5.right = new TreeNode(9);
            node9.left = new TreeNode(4);

            IList<int> result = PreorderTraversalRecursively(root);
            PrintPreorderList(result);

            result = PreorderTraversalIteratorly(root);
            PrintPreorderList(result);
        }
    }

    private static void PrintPreorderList(IList<int> list)
    {
        Console.Write("Preorder: [");
        foreach (int i in list){
            Console.Write($"{i},");
        }
        Console.WriteLine("]");
    }
}