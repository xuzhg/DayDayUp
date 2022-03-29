// Given the head of a sorted linked list,
// delete all nodes that have duplicate numbers, leaving only distinct numbers from the original list. Return the linked list sorted as well.
using System;
using System.Collections.Generic;

// Input: head = [1,2,3,3,4,4,5]
// Output: [1,2,5]
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
// Output: [2]
public class Solution
{
    // the list is sorted, so we can use the sorted feature
    public static ListNode DeleteDuplicates(ListNode head) {

        ListNode p = head;
        ListNode pre = null;
        head = null;
        while(p != null){

            ListNode q = p.next;
            if(q != null && q.val == p.val)
            {
                // duplicated, should remove all
                while (q != null && q.val == p.val)
                {
                    q = q.next;
                }

                p = q; // p now point to the end or the next number
            }
            else
            {
                if (pre == null)
                {                    
                    head = p;
                }
                else
                {
                    pre.next = p;
                }
                pre = p;
                p = p.next;
                pre.next = null;
            }

        }

        return head;
    }

    public static void Main(string[] args){
        {
            ListNode head = new ListNode(1,
                new ListNode(1,
                 new ListNode(2,
                  new ListNode(3,
                   new ListNode(3,
                    new ListNode(4,
                     new ListNode(4,
                      new ListNode(5))))))));


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