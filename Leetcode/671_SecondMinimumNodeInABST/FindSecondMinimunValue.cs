/*        
Given a non-empty special binary tree consisting of nodes with the non-negative value, 
where each node in this tree has exactly two or zero sub-node.
If the node has two sub-nodes, then this node's value is the smaller value among its two sub-nodes.

More formally, the property root.val = min(root.left.val, root.right.val) always holds.

Given such a binary tree, you need to output the second minimum value in the set made of all the nodes' value in the whole tree.

If no such second minimum value exists, output -1 instead.
*/
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
    public static int FindSecondMinValue(TreeNode root){
        // each node in this tree has exactly two or zero sub-node.
        if (root == null) return -1;

        if (root.left == null || root.right == null) return -1;

        if (root.left.val > root.right.val)
        {
            int secondMin = FindSecondMinValue(root.right);

            return secondMin == -1 || secondMin > root.left.val ? root.left.val : secondMin;

            //if (secondMin == -1)
            //    return root.left.val;
           // else
            //    return secondMin;
        }
        else if(root.left.val < root.right.val)
        {
            int secondMin = FindSecondMinValue(root.left);
            return secondMin == -1 || secondMin > root.right.val ? root.right.val : secondMin;

            //if (secondMin == -1)
             //   return root.right.val;
            //else
             //   return secondMin;
        }
        else
        {
            int leftSecondMin = FindSecondMinValue(root.left);
            int rightSecondMin = FindSecondMinValue(root.right);

            if (leftSecondMin == -1)
                 return rightSecondMin;

            if (rightSecondMin == -1)
                return leftSecondMin;

            if (leftSecondMin < rightSecondMin)
                return leftSecondMin;
            else
                return rightSecondMin;
        }

/*
        int leftSecondMin = FindSecondMinValue(root.left);

        int rightSecondMin = FindSecondMinValue(root.right);

        if (leftSecondMin == -1) return rightSecondMin;

        if (rightSecondMin == -1) return leftSecondMin;

        return leftSecondMin < rightSecondMin ? leftSecondMin : rightSecondMin;*/
    }

    public static void Main(string[] args){
        TreeNode root = new TreeNode(2,
            new TreeNode(2),
            new TreeNode(5, new TreeNode(5), new TreeNode(7)));

        Console.WriteLine("Second Min is " + FindSecondMinValue(root));

        root = new TreeNode(2,
            new TreeNode(2),
            new TreeNode(2));

        Console.WriteLine("Second Min is " + FindSecondMinValue(root));


        root = new TreeNode(2,
            new TreeNode(2, new TreeNode(2), new TreeNode(3)),
            new TreeNode(5, new TreeNode(5), new TreeNode(7)));

        Console.WriteLine("Second Min is " + FindSecondMinValue(root));

        root = new TreeNode(1,
            new TreeNode(1,
              new TreeNode(1, new TreeNode(1), new TreeNode(3)),
              new TreeNode(1, new TreeNode(1), new TreeNode(8))),
            new TreeNode(3, new TreeNode(3), new TreeNode(4)));

        Console.WriteLine("Second Min is " + FindSecondMinValue(root));

        root = new TreeNode(1,
            new TreeNode(1,
              new TreeNode(1, new TreeNode(3, new TreeNode(3), new TreeNode(3)), new TreeNode(1, new TreeNode(1), new TreeNode(6))),
              new TreeNode(1, new TreeNode(1, new TreeNode(2), new TreeNode(1)), new TreeNode(1))),
            new TreeNode(3, new TreeNode(3, new TreeNode(3), new TreeNode(8)), new TreeNode(4, new TreeNode(4), new TreeNode(8))));

        root.Print();
        Console.WriteLine("Second Min is " + FindSecondMinValue(root));
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