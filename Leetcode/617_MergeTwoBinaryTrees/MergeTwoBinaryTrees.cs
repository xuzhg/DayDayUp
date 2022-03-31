
// You are given two binary trees root1 and root2.

// Imagine that when you put one of them to cover the other, 
// some nodes of the two trees are overlapped while the others are not. 
// You need to merge the two trees into a new binary tree. 

// The merge rule is that if two nodes overlap, then sum node values up as the new value of the merged node.
//  Otherwise, the NOT null node will be used as the node of the new tree.

// Return the merged tree.

// Note: The merging process must start from the root nodes of both trees.
using System;
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
    /// <summary>
    /// Recursively
    /// </summary>
    public static TreeNode MergeTrees(TreeNode node1, TreeNode node2)
    {
        // not necessary
        // if (node1 == null && node2 == null) return null;

        if (node1 == null) return node2;
        
        if (node2 == null) return node1;

        TreeNode newNode = new TreeNode(node1.val + node2.val);

        newNode.left = MergeTrees(node1.left, node2.left);

        newNode.right = MergeTrees(node1.right, node2.right);

        return newNode;
    }


    class TreeNodePair
    {
        public TreeNode n1 {get;set;}
        public TreeNode n2 {get;set;}
    }
    /// <summary>
    /// Iteratively
    /// </summary>
    public static TreeNode MergeTreesIterative(TreeNode node1, TreeNode node2)
    {
        // not necessary
        // if (node1 == null && node2 == null) return null;
        if (node1 == null) return node2;
        
        if (node2 == null) return node1;

        Stack<TreeNodePair> stack = new Stack<TreeNodePair>();
        stack.Push(new TreeNodePair { n1 = node1, n2 = node2});

        while (stack.Count > 0)
        {
            TreeNodePair pair = stack.Pop();
            if (pair.n1 == null || pair.n2 == null)
            {
                continue;
            }
            
            pair.n1.val += pair.n2.val;

            if (pair.n1.left == null)
            {
                pair.n1.left = pair.n2.left;
            }
            else{
                TreeNodePair newPair = new TreeNodePair { n1 = pair.n1.left, n2 = pair.n2.left };
                stack.Push(newPair);
            }

            if (pair.n1.right == null)
            {
                pair.n1.right = pair.n2.right;
            }
            else{
                TreeNodePair newPair = new TreeNodePair { n1 = pair.n1.right, n2 = pair.n2.right };
                stack.Push(newPair);
            }

            return node1;
        }

        TreeNode newNode = new TreeNode(node1.val + node2.val);

        newNode.left = MergeTrees(node1.left, node2.left);

        newNode.right = MergeTrees(node1.right, node2.right);

        return newNode;
    }

    public static void Main(string[] args){

        // test1
        Console.WriteLine("Run for recursively!");
        TreeNode node1 = new TreeNode(1, 
            new TreeNode(3, new TreeNode(5), null),
            new TreeNode(2));

        TreeNode node2 = new TreeNode(2, 
            new TreeNode(1, null, new TreeNode(4)),
            new TreeNode(3, null, new TreeNode(7)));

        node1.Print();

        node2.Print();

        TreeNode newNode = MergeTrees(node1, node2);
        newNode.Print();

        // test 2
        Console.WriteLine("Run for iteratively!");
        
        TreeNode node3 = new TreeNode(1, 
            new TreeNode(2, new TreeNode(4), new TreeNode(5)),
            new TreeNode(3, null, new TreeNode(6)));

        TreeNode node4 = new TreeNode(4, 
            new TreeNode(1, new TreeNode(3), null),
            new TreeNode(7, new TreeNode(2), new TreeNode(6)));

        node3.Print();

        node4.Print();

        newNode = MergeTrees(node3, node4);
        newNode.Print();
    }
}

public static class BTreePrinter
{
    class NodeInfo
    {
        public TreeNode Node;
        public string Text;
        public int StartPos;
        public int Size { get { return Text.Length; } }
        public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }
        public NodeInfo Parent, Left, Right;
    }

    public static void Print(this TreeNode root, int topMargin = 2, int leftMargin = 2)
    {
        if (root == null) return;
        int rootTop = Console.CursorTop + topMargin;
        var last = new List<NodeInfo>();
        var next = root;
        for (int level = 0; next != null; level++)
        {
            var item = new NodeInfo { Node = next, Text = next.val.ToString(" 0 ") };
            if (level < last.Count)
            {
                item.StartPos = last[level].EndPos + 1;
                last[level] = item;
            }
            else
            {
                item.StartPos = leftMargin;
                last.Add(item);
            }
            if (level > 0)
            {
                item.Parent = last[level - 1];
                if (next == item.Parent.Node.left)
                {
                    item.Parent.Left = item;
                    item.EndPos = Math.Max(item.EndPos, item.Parent.StartPos);
                }
                else
                {
                    item.Parent.Right = item;
                    item.StartPos = Math.Max(item.StartPos, item.Parent.EndPos);
                }
            }
            next = next.left ?? next.right;
            for (; next == null; item = item.Parent)
            {
                Print(item, rootTop + 2 * level);
                if (--level < 0) break;
                if (item == item.Parent.Left)
                {
                    item.Parent.StartPos = item.EndPos;
                    next = item.Parent.Node.right;
                }
                else
                {
                    if (item.Parent.Left == null)
                        item.Parent.EndPos = item.StartPos;
                    else
                        item.Parent.StartPos += (item.StartPos - item.Parent.EndPos) / 2;
                }
            }
        }
        Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
    }

    private static void Print(NodeInfo item, int top)
    {
        SwapColors();
        Print(item.Text, top, item.StartPos);
        SwapColors();
        if (item.Left != null)
            PrintLink(top + 1, "┌", "┘", item.Left.StartPos + item.Left.Size / 2, item.StartPos);
        if (item.Right != null)
            PrintLink(top + 1, "└", "┐", item.EndPos - 1, item.Right.StartPos + item.Right.Size / 2);
    }

    private static void PrintLink(int top, string start, string end, int startPos, int endPos)
    {
        Print(start, top, startPos);
        Print("─", top, startPos + 1, endPos);
        Print(end, top, endPos);
    }

    private static void Print(string s, int top, int left, int right = -1)
    {
        Console.SetCursorPosition(left, top);
        if (right < 0) right = left + s.Length;
        while (Console.CursorLeft < right) Console.Write(s);
    }

    private static void SwapColors()
    {
        var color = Console.ForegroundColor;
        Console.ForegroundColor = Console.BackgroundColor;
        Console.BackgroundColor = color;
    }
}

//Run for recursively!
//
//
//         1
//      ┌─┘ └─┐
//      3     2
//   ┌─┘
//   5
//
//
//      2
//   ┌─┘ └─┐
//   1     3
//    └─┐   └─┐
//      4     7
//
//
//         3
//      ┌─┘ └─┐
//      4     5
//   ┌─┘ └─┐   └─┐
//   5     4     7
//Run for iteratively!
//
//
//         1
//      ┌─┘ └─┐
//      2     3
//   ┌─┘ └─┐   └─┐
//   4     5     6
//
//
//         4
//      ┌─┘ └─┐
//      1     7
//   ┌─┘   ┌─┘ └─┐
//   3     2     6
//
//
//           5
//      ┌───┘ └────┐
//      3         10
//   ┌─┘ └─┐   ┌─┘  └──┐
//   7     5   2      12
