

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

    // we can use the inorder to check
    public static bool IsValidBST(TreeNode root) {
        
        TreeNode pre = null;
        return IsValidBST(root, ref pre);
    }

    private static bool IsValidBST(TreeNode node, ref TreeNode pre){
        if (node == null) return true;

        if (node.left != null)
        {
            if (!IsValidBST(node.left, ref pre)) {
                return false;
            }
        }

        if (pre != null)
        {
            if (node.val <= pre.val) {
                return false;
            }
        }

        pre = node;

        if (node.right != null)
        {
            if (!IsValidBST(node.right, ref pre)) {
                return false;
            }
        }

        return true;
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

        {
            TreeNode node = new TreeNode(2, 
                new TreeNode(2),
                new TreeNode(2));
            
            Console.WriteLine("Test 3 is " + (IsValidBST(node) ? " valid tree" : " invalid tree"));
        }
    }
}