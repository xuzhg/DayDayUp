// Given the root of a binary tree, invert the tree, and return its root.

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

public class Solution
{
    public static TreeNode InvertTree(TreeNode root) {

        if (root == null) return null;

        TreeNode left = root.left;

        root.left = InvertTree(root.right);

        root.right = InvertTree(left);

        return root;
    }


}