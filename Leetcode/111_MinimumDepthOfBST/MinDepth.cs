// Given a binary tree, find its minimum depth.

// The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.

// Note: A leaf is a node with no children.
using System;
using System.Collections.Generic;
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


public class DepthNode
{
    public int Depth = 0;
    public TreeNode Node;
}

public class Solution
{
    // Iteralively
    public static int MinDepth(TreeNode root)
    {
        if (root == null) return 0;
        Stack<DepthNode> stack = new Stack<DepthNode>();
        stack.Push(new DepthNode { Depth = 1, Node = root });

        int minDepth = int.MaxValue;
        while (stack.Count > 0){
            DepthNode top = stack.Pop();

            if (top.Node.left == null && top.Node.right == null)
            {
                // a leave
                if (top.Depth < minDepth){
                    minDepth = top.Depth;
                }
            }
            
            if (top.Node.left != null)
            {
                stack.Push(new DepthNode { Depth = top.Depth + 1, Node = top.Node.left});
            }

            if (top.Node.right != null)
            {
                stack.Push(new DepthNode { Depth = top.Depth + 1, Node = top.Node.right});
            }
        }

        return minDepth;
    }

    public static void Main(string[] args)
    {
        TreeNode root = new TreeNode(3,
            new TreeNode(9),
            new TreeNode(20, new TreeNode(15), new TreeNode(7)));
        
        Console.WriteLine("MinDepth = " + MinDepth(root)); // output is 2
    }
}
