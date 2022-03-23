using System;
using System.Collections.Generic;

namespace PostOrderTraversalNs;

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
    /// Post-order the binary tree without using recursively
    /// </summary>
    public static IList<int> PostorderTraversalIteratorly(TreeNode root)
    {
        IList<int> result = new List<int>();
        if (root == null) return result;

        Stack<TreeNode> stack = new();
        if (root.right != null){
            stack.Push(root.right);
        }
        stack.Push(root);
        TreeNode current = root.left;

        while (stack.Count != 0)
        {
            while(current != null)
            {
                if (current.right != null)
                {
                    stack.Push(current.right);
                }

                stack.Push(current);
                current = current.left;
            }

            current = stack.Pop();
            
            if (stack.Count != 0 && current.right != null && current.right == stack.Peek())
            {
                TreeNode node = stack.Pop();
                stack.Push(current);
                current = node; 
            }
            else
            {
                result.Add(current.val);
                current = null;
            }
           }

        return result;
    }

    /// <summary>
    /// Post-order the binary tree without using recursively
    /// </summary>
    public static IList<int> PostorderTraversalRecursively(TreeNode root)
    {
        IList<int> result = new List<int>();
        PostorderRecursively(root, result);
        return result;
    }

    private static void PostorderRecursively(TreeNode node, IList<int> result)
    {
        if (node == null) return;

        PostorderRecursively(node.left, result);
        PostorderRecursively(node.right, result);
        result.Add(node.val);
    }

    public static void Main(string[] args)
    {
        {
            // Test 1
            TreeNode root = new TreeNode(1, 
                null, new TreeNode(2, new TreeNode(3)));
            
            IList<int> result = PostorderTraversalRecursively(root);
            PrintPostorderList(result);

            result = PostorderTraversalIteratorly(root);
            PrintPostorderList(result);
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

            IList<int> result = PostorderTraversalRecursively(root);
            PrintPostorderList(result);

            result = PostorderTraversalIteratorly(root);
            PrintPostorderList(result);
        }
    }

    private static void PrintPostorderList(IList<int> list)
    {
        Console.Write("Postorder: [");
        foreach (int i in list){
            Console.Write($"{i},");
        }
        Console.WriteLine("]");
    }
}