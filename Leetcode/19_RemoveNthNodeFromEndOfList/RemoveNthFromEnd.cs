/*
Given the head of a linked list, remove the nth node from the end of the list and return its head.
*/

using System;

public class ListNode{
    public int val;
    public ListNode next;
    public ListNode(int x, ListNode next = null) { val = x; this.next = next; }
}

public class Solution {
    public static ListNode RemoveNthFromEnd(ListNode head, int n) {
        if (head == null || n <= 0) return head;

        ListNode fast = head;
        int i  = 1;
        while (i < n && fast != null) {
            fast = fast.next;
            ++i;
        }

        // we don't have enough nodes
        if (fast == null) return head;

        if (fast.next == null) {
            head = head.next;
            return head;
        }

        fast = fast.next.next;
        ListNode slow = head;
        while (fast != null){
            fast = fast.next;
            slow = slow.next;
        }

        slow.next = slow.next.next;
        return head;
    }

    public static void Main(string[] args){
        {
            ListNode head = new ListNode(1,
                new ListNode(2,
                 new ListNode(3,
                  new ListNode(4,
                   new ListNode(5)))));

            Print(head);

            head = RemoveNthFromEnd(head, 2);

            Print(head);

            head = RemoveNthFromEnd(head, 4);

            Print(head);

            head = RemoveNthFromEnd(head, 1);

            Print(head);

            head = RemoveNthFromEnd(head, 2);

            Print(head);
        }

        {
            ListNode head = new ListNode(1);

            Print(head);

            head = RemoveNthFromEnd(head, 1);

            Print(head);
        }
    }

    public static void Print(ListNode head){

        Console.Write("List: ");
        while(head != null){ 
            Console.Write(head.val);

            if (head.next != null){
                Console.Write("->");
            }

            head = head.next;
        }

        Console.WriteLine();
    }
}