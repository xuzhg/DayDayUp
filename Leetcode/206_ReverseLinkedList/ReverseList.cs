/*
Given the head of a singly linked list, reverse the list, and return the reversed list.
*/

using System;
using System.Collections.Generic;

public class ListNode{
    public int val;
    public ListNode next;
    public ListNode(int x, ListNode next = null) { val = x; this.next = next; }
}

public class Solution {
    public static ListNode ReverseList(ListNode head) {
        if (head == null) return null;

        ListNode newHead = null;
        while (head != null) { 
            ListNode p = head.next;
            head.next = newHead;
            newHead = head;
            head = p;
        }

        return newHead;
    }
}