/*
Given the head of a singly linked list and two integers left and right where left <= right,
 reverse the nodes of the list from position left to position right, and return the reversed list.
*/

using System;
using System.Collections.Generic;

public class ListNode{
    public int val;
    public ListNode next;
    public ListNode(int x, ListNode next = null) { val = x; this.next = next; }
}


public class Solution {
    public static ListNode ReverseBetween(ListNode head, int left, int right) {
        if (head == null) return null;
        if (left >= right) return head;

        ListNode beforeLeft = null;
        int index = 1;
        while (index < left) {
            if (beforeLeft == null)
                beforeLeft = head;
            else
                beforeLeft = beforeLeft.next;

            ++index;
        }

        ListNode rightNode = beforeLeft == null ? head : beforeLeft.next;
        while(index < right) {
            rightNode = rightNode.next;
            ++index;
        }

        ListNode afterRight = rightNode.next;
        rightNode.next = null;

        ListNode needReverseHead = beforeLeft == null ? head : beforeLeft.next;
        ListNode revseredHead = Reverse(needReverseHead, out ListNode newTail);

        newTail.next = afterRight;

        if (beforeLeft == null) {
            return revseredHead;
        }
        else
        {
            beforeLeft.next = revseredHead;
            return head;
        }
    }

    private static ListNode Reverse(ListNode head, out ListNode tail){
        ListNode newHead = null;
        tail = null;
        while(head != null) {
            if (newHead == null) {
                tail = head;
            }

            ListNode p = head.next;
            head.next = newHead;
            newHead = head;
            head = p;
        }

        return newHead;
    }

    public static void Main(string[] args){
        {
            ListNode head = new ListNode(5);

            Print(head);
            head = ReverseBetween(head, 1, 1);
            Print(head);
        }
        {
            ListNode head = new ListNode(1, 
                new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, new ListNode(6, new ListNode(7)))))));

            Print(head);
            head = ReverseBetween(head, 2, 4);
            Print(head);
        }

        {
            ListNode head = new ListNode(1, 
                new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, new ListNode(6, new ListNode(7)))))));

            Print(head);
            head = ReverseBetween(head, 1, 7);
            Print(head);
        }


        {
            ListNode head = new ListNode(1, 
                new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, new ListNode(6, new ListNode(7)))))));

            Print(head);
            head = ReverseBetween(head, 1, 3);
            Print(head);
        }

        {
            ListNode head = new ListNode(1, 
                new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, new ListNode(6, new ListNode(7)))))));

            Print(head);
            head = ReverseBetween(head, 3, 7);
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