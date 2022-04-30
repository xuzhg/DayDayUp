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
        if (root == null) return true;

        if (root.left == null && root.right == null) return true;

        bool isLeftBalance = IsBalanced(root.left);
        bool isRightBalance = IsBalanced(root.right);
        if (!isLeftBalance || !isRightBalance)
        {
            return false;
        }

        int leftDepth = MaxDepth(root.left);
        int rightDepth = MaxDepth(root.right);

        return Math.Abs(leftDepth - rightDepth) <= 1;
    }

    public static int MaxDepth(TreeNode root) {
        if (root == null) return 0;
        if (root.left == null && root.right == null) {
            return 1;
        }

        int leftDepth = MaxDepth(root.left);
        int rightDepth = MaxDepth(root.right);

        if (leftDepth > rightDepth) {
            return leftDepth + 1;
        }
        else{
            return rightDepth + 1;
        }
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
