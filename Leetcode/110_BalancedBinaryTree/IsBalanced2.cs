/*
Given a binary tree, determine if it is height-balanced.

For this problem, a height-balanced binary tree is defined as:

a binary tree in which the left and right subtrees of every node differ in height by no more than 1.
*/
using System;
// Definition for a binary tree node.
public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution {
    public static bool IsBalanced(TreeNode root) {
        return IsBalanced(root, out int maxDept);
    }

    public static bool IsBalanced(TreeNode node, out int maxDepth) {
        maxDepth = 0;
        if (node == null)
        {
            return true;
        }

        maxDepth = 1;
        if (node.left == null && node.right == null) {
            return true;
        }

        bool isLeftBalanced = IsBalanced(node.left, out int leftMax);
        if (!isLeftBalanced){
            return false;
        }

        bool isRightBalanced = IsBalanced(node.right, out int rightMax);
        if (!isRightBalanced){
            return false;
        }

        maxDepth = 1 + Math.Max(leftMax, rightMax);
        return Math.Abs(leftMax - rightMax) <= 1;
    }

    public static void Main(string[] args){
        TreeNode root = new TreeNode(3, 
            new TreeNode(9),
            new TreeNode(20, new TreeNode(15), new TreeNode(7)));

        Console.WriteLine($"{IsBalanced(root)} == true");

        TreeNode root1 = new TreeNode(1, 
            new TreeNode(2,
                new TreeNode(3,
                   new TreeNode(4),
                   new TreeNode(4)),
                new TreeNode(3)),
            new TreeNode(2));

        Console.WriteLine($"{IsBalanced(root1)} == false");
    }
}