/*Given the root of a Binary Search Tree (BST),
 return the minimum difference between the values of any two different nodes in the tree.*/

/*
 Definition for a binary tree node.
*/
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
    // 中序遍历，获取一个有序数列
    // 返回相邻两个节点之间值最小的
    public static int MinDiffInBST(TreeNode root) {
        if (root == null) return 0;

        IList<int> inOrders = new List<int>();
        InOrder(root, inOrders);

        int min = int.MaxValue;
        for (int i = 0; i < inOrders.Count - 1; i++) {
            int diff = Math.Abs(inOrders[i] - inOrders[i + 1]);
            if (diff < min) min = diff;
        }

        return min;
    }

    private static void InOrder(TreeNode node, IList<int> inOrders){
        if (node.left != null) {
            InOrder(node.left, inOrders);
        }

        inOrders.Add(node.val);

        if (node.right != null){
            InOrder(node.right, inOrders);
        }
    }
}