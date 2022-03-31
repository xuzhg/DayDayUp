// Given the roots of two binary trees p and q, write a function to check if they are the same or not.

// Two binary trees are considered the same if they are structurally identical, and the nodes have the same value.

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
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        if (p == null && q == null) return true;

        if ((p == null && q != null) || (p != null && q == null)) return false;

        if (p.val != q.val) return false;

        if (!IsSameTree(p.left, q.left)) return false;

        if (!IsSameTree(p.right, q.right)) return false;

        return true;
    }
}