// Given the root of an n-ary tree, return the preorder traversal of its nodes' values.
using System;
using System.Linq;
using System.Collections.Generic;

namespace BinaryTreePathsNs;

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
    /*
    public IList<string> BinaryTreePaths(TreeNode root)
    {
        IList<string> paths = new List<string>();
        if (root == null) return paths;

        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);

        while(stack.Count > 0)
        {
            TreeNode node = stack.Peek();

            if (node.left == null && node.right == null)
            {
                string aPath = ToPaths(stack);
                paths.Add(aPath);

                // find a leaf
                stack.Pop();
                
            }

            if (node.left != null)
            {
                stack.Push(node.left);
            }

            
        }
    }*/

    public static IList<string> BinaryTreePaths(TreeNode root)
    {
        IList<string> paths = new List<string>();
        Stack<int> stack = new Stack<int>();
        BinaryTreePathsRecursively(root, stack, paths);
        return paths;
    }

    private static void BinaryTreePathsRecursively(TreeNode node, Stack<int> nodes, IList<string> paths){
        if (node == null)
            return;

        nodes.Push(node.val);

        if (node.left == null && node.right == null)
        {
            string path = ToPaths(nodes);
            paths.Add(path);
        }

        if (node.left != null)
        {
            BinaryTreePathsRecursively(node.left, nodes, paths);
        }

        if (node.right != null)
        {
            BinaryTreePathsRecursively(node.right, nodes, paths);
        }

        nodes.Pop();
    }

    private static string ToPaths(Stack<int> stack){

        int[] paths = new int[stack.Count];
        int index = stack.Count - 1;
        foreach (int data in stack)
        {
            paths[index] = data;
            --index;
        }

        return string.Join("->", paths.Select(e => e.ToString()));
    }

    public static void Main(string[] args)
    {
        {
            // Test 1
            TreeNode root = new TreeNode(1, 
                new TreeNode(2, null, new TreeNode(5)),
                new TreeNode(3));
            
            IList<string> paths = BinaryTreePaths(root);
            PrintBinaryTreePaths(paths);
        }
    }

    public static void PrintBinaryTreePaths(IList<string> paths){
        Console.Write("[");
        foreach (string path in paths)
        {
            Console.Write(path);
            Console.Write(",");
        }
        Console.Write("]\n");
    }
}