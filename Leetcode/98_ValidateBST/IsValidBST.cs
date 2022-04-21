/*
Given the root of a binary tree, determine if it is a valid binary search tree (BST).

A valid BST is defined as follows:

 1) The left subtree of a node contains only nodes with keys less than the node's key.
 2) The right subtree of a node contains only nodes with keys greater than the node's key.
 3) Both the left and right subtrees must also be binary search trees.
*/

using System;

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

public class Solution {
    public static bool IsValidBST(TreeNode root) {
        if (root == null) return true;

        int subLeftMax = int.MinValue;
        int subLeftMin = int.MaxValue;
        bool isLeftValid = IsValid(root.left, ref subLeftMax, ref subLeftMin);
        if (!isLeftValid) { return false; }

        int subRightMax = int.MinValue;
        int subRightMin = int.MaxValue;
        bool isRightValid = IsValid(root.right, ref subRightMax, ref subRightMin);
        if (!isRightValid) { return false; }

        if (root.val > subLeftMax && root.val < subRightMin) {
            return true;
        }

        return false;
    }

    private static bool IsValid(TreeNode node, ref int max, ref int min){
        if (node == null) {
            return true;
        }

        if (node.val > max) {
            max = node.val;
        }

        if (node.val < min) {
            min = node.val;
        }

        int subLeftMax = int.MinValue;
        int subLeftMin = int.MaxValue;
        bool isLeftValid = IsValid(node.left, ref subLeftMax, ref subLeftMin);
        if (!isLeftValid) { return false; }

        int subRightMax = int.MinValue;
        int subRightMin = int.MaxValue;
        bool isRightValid = IsValid(node.right, ref subRightMax, ref subRightMin);
        if (!isRightValid) { return false; }

        bool bReturn = false;
        if (node.val > subLeftMax && node.val < subRightMin) {
            bReturn = true;
        }

        if (subLeftMax > max) {
            max = subLeftMax;
        }
        if (subRightMax > max) {
            max = subRightMax;
        }

        if (subLeftMin < min) {
            min = subLeftMin;
        }

        if (subRightMin < min) {
            min = subRightMin;
        }

        return bReturn;
    }

    public static void Main(string[] args) {
        {
            TreeNode node = new TreeNode(2, 
                new TreeNode(1),
                new TreeNode(3));
            
            Console.WriteLine("Test 1 is " + (IsValidBST(node) ? " valid tree" : " invalid tree"));
        }

         {
            TreeNode node = new TreeNode(5, 
                new TreeNode(1),
                new TreeNode(4, new TreeNode(3), new TreeNode(6)));
            
            Console.WriteLine("Test 2 is " + (IsValidBST(node) ? " valid tree" : " invalid tree"));
        }
    }
}