// Version 2.0:

//You are given the head of a singly linked-list. The list can be represented as:

//L0 → L1 → … → Ln - 1 → Ln
//Reorder the list to be on the following form:

//L0 → Ln → L1 → Ln - 1 → L2 → Ln - 2 → …
//You may not modify the values in the list's nodes. Only nodes themselves may be changed.
using System;
using System.Collections.Generic;

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int value, ListNode next = null) {
        this.val = value;
        this.next = next;
    }
}

public class Solution
{
    /// <summary>
    /// This version:
    /// I push the second half of nodes into a stack,
    //  and start from begin and also start from top of stack
    /// to link the nodes into a new list. Time complexity is O(n)
    /// </summary>
    public static ListNode ReorderList(ListNode head)
    {
        // If it's 'null' list
        // or only one or two nodes in the list, do nothing.
        if (head == null || head.next == null || head.next.next == null)
            return head;

        ListNode slow = head, fast = head;
        while (fast.next != null && fast.next.next != null){
            slow = slow.next;
            fast = fast.next.next;
        }

        Stack<ListNode> stack = new Stack<ListNode>();
        ListNode p = slow.next; // p now points to the head node of the second half
        while(p != null){
            stack.Push(p);
            p = p.next;
        }

        p = head;
        while (stack.Count > 0)
        {
            ListNode last = stack.Pop();
            last.next = p.next;
            p.next = last;
            p = last.next;
        }

        p.next = null;
        return head;
    }

    public static void Main(string[] args)
    {
        {
            ListNode head = new ListNode(1, 
                new ListNode(2,
                  new ListNode(3,
                    new ListNode(4))));

            PrintListNode(head);
            PrintListNode(ReorderList(head));
        }

        {
            ListNode head = new ListNode(1, 
                new ListNode(2,
                  new ListNode(3,
                    new ListNode(4,
                      new ListNode(5)))));

            PrintListNode(head);
            PrintListNode(ReorderList(head));
        }
    }

    private static void PrintListNode(ListNode head)
    {
        Console.Write("[");
        while(head != null){
            Console.Write($"{head.val}");
            head = head.next;
            if (head != null){
                Console.Write("->");
            }
        }
        Console.WriteLine("]");
    }
}