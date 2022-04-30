/*
Given the root of a binary tree, 
construct a string consisting of parenthesis and integers from a binary tree
 with the preorder traversal way, and return it.

Omit all the empty parenthesis pairs
 that do not affect the one-to-one mapping relationship 
 between the string and the original binary tree.
*/


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
        public string Tree2str(TreeNode root) {
        if (root == null) return string.Empty;

        StringBuilder sb = new StringBuilder();
        PreOrder(root, sb);

        return sb.ToString();
    }
    
    private static void PreOrder(TreeNode node, StringBuilder sb){
         sb.Append(node.val);
        
        if (node.left == null && node.right == null) {
            return;
        }
        
        sb.Append("(");
        if (node.left != null) {
            PreOrder(node.left, sb);
        }
        sb.Append(")");
        
        if (node.right != null) {
            sb.Append("(");
            PreOrder(node.right, sb);
            sb.Append(")");   
        }
    }
}