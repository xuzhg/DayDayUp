// Given the head of a sorted linked list, delete all duplicates such that each element appears only once. Return the linked list sorted as well.
using System;
using System.Collections.Generic;

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

// Input: head = [1,1,2,3,3]
// Output: [1,2,3]
public class Solution
{
    public static ListNode DeleteDuplicates(ListNode head)
    {
        if (head == null) return head;

        ISet<int> visited = new HashSet<int>();
        visited.Add(head.val);

        ListNode pre = head;
        ListNode p = head.next;
        while(p != null){

            if (visited.Contains(p.val))
            {
                pre.next = p.next;
            }
            else
            {
                pre = p;
                visited.Add(p.val);
            }

            p = p.next;
        }

        return head;
    }
    public static void Main(string[] args){
        {
            ListNode head = new ListNode(1,
                new ListNode(1, new ListNode(2)));

            PrintList(head);
            Console.WriteLine("After remove duplicates");
            PrintList(DeleteDuplicates(head));
        }

        {
            ListNode head = new ListNode(1,
                new ListNode(1,
                 new ListNode(2,
                  new ListNode(3, new ListNode(3)))));

            PrintList(head);
            Console.WriteLine("After remove duplicates");
            PrintList(DeleteDuplicates(head));
        }
    }

    private static void PrintList(ListNode head)
    {
        Console.Write("List: [");
        while(head != null){
            Console.Write(head.val);

            head = head.next;

            if (head != null){
                Console.Write("->");
            }
        }

        Console.WriteLine("]");
    }
}