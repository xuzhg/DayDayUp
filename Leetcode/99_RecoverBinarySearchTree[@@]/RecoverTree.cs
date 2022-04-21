/*
You are given the root of a binary search tree (BST), 
where the values of exactly two nodes of the tree were swapped by mistake. Recover the tree without changing its structure.
*/
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

public class Solution {

    // Output the in-order list, the in-order list is sorted list
    // try to find two pairs in the wrong position
    // It could be adjacent nodes, or it's not adjacent. 
    public static void RecoverTree(TreeNode root) {
        if (root == null) return;

        IList<TreeNode> list = new List<TreeNode>();
        TraversalInOrder(root, list);

        TreeNode first = null;
        TreeNode mid = null;
        TreeNode last = null;
        TreeNode pre = null;

        foreach (TreeNode node in list)
        {
            if (pre != null)
            {
                if (pre.val > node.val)
                {
                    if (first == null)
                    {
                        first = pre;
                        mid = node;
                    }
                    else{
                        last = node;
                    }
                }
            }

            pre = node;
        }

        TreeNode second = last != null ? last : mid;
        int temp = first.val;
        first.val = second.val;
        second.val = temp;
    }

    private static void TraversalInOrder(TreeNode node, IList<TreeNode> list){
        if (node == null) return;

        TraversalInOrder(node.left, list);
        list.Add(node);
        TraversalInOrder(node.right, list);
    }

    public static void Main(string[] args) {
        Console.WriteLine("Test 1:");
        {
            TreeNode node = new TreeNode(1, 
                new TreeNode(3, null, new TreeNode(2)));

            PrintTree(node);

            RecoverTree(node);
            PrintTree(node);
        }
        Console.WriteLine("Test 2:");
        {
            TreeNode node = new TreeNode(3, 
                new TreeNode(1),
                new TreeNode(4, new TreeNode(2), null));

            PrintTree(node);
            RecoverTree(node);
            PrintTree(node);
        }
        
    }

    private static void PrintTree(TreeNode root) {
        Console.Write("Tree:[");

        IList<TreeNode> currentLvl = new List<TreeNode> { root };

        Console.Write($"{root.val}");

        while (currentLvl.Count > 0) {

            IList<TreeNode> nextLvl = new List<TreeNode>();

            foreach (TreeNode node in currentLvl) {

                if (node.left != null) {
                    nextLvl.Add(node.left);
                    Console.Write($",{node.left.val}");
                }
                else{
                    Console.Write(",^");
                }

                if (node.right != null) {
                    nextLvl.Add(node.right);
                    Console.Write($",{node.right.val}");
                }
                else{
                    Console.Write(",^");
                }
            }

            currentLvl = nextLvl;
        }

        Console.WriteLine("]");
    }
}