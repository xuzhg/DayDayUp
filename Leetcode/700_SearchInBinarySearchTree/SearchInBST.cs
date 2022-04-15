// You are given the root of a binary search tree (BST) and an integer val.

// Find the node in the BST that the node's value equals val and return the subtree rooted with that node.
// If such a node does not exist, return null.
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
    // Recursively
    public static TreeNode SearchInBST(TreeNode root, int val)
    {
        if (root == null) return null;

        if (root.val == val) return root;

        TreeNode foundInLeft = SearchInBST(root.left, val);
        if (foundInLeft != null)
            return foundInLeft;

        TreeNode foundInRight = SearchInBST(root.right, val);
        if (foundInRight != null)
            return foundInRight;

        return null;
    }

    // iteratively
    public static TreeNode SearchInBST_Iteratively(TreeNode root, int val)
    {
        if (root == null) return null;

        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);

        while (stack.Count > 0)
        {
            TreeNode node = stack.Pop();

            if (node.val == val) return node;

            if (node.left != null)
                stack.Push(node.left);

            if (node.right != null)
                stack.Push(node.right);
        }

        return null;
    }
}