// Given the root of a binary tree, return the sum of all left leaves.

// A leaf is a node with no children. A left leaf is a leaf that is the left child of another node.
using System;
using System.Collections.Generic;

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
    // iteratively
    public static int SumOfLeftLeaves(TreeNode root) { 
        if (root == null) return 0;

        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);

        int sum = 0;
        while(stack.Count > 0)
        {
            TreeNode top = stack.Pop();

            if (top.left != null){
                // found a left leave
                if (top.left.left == null && top.left.right == null)
                {
                    sum += top.left.val;
                }
                else
                {
                    stack.Push(top.left);
                }
            }

            if (top.right != null){
                stack.Push(top.right);
            }
        }

        return sum;
    }

    public static void Main(string[] args)
    {
        TreeNode node1 = new TreeNode(3, 
            new TreeNode(9),
            new TreeNode(20, new TreeNode(15), new TreeNode(7)));

        Console.WriteLine("Tree1 left leave sum is " + SumOfLeftLeaves(node1));
    }
}
