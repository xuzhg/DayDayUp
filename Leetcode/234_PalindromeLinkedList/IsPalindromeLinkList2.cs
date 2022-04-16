/*
Given the head of a singly linked list, return true if it is a palindrome.
*/

using System;
using System.Collections.Generic;

public class ListNode{
    public int val;
    public ListNode next;
    public ListNode(int x, ListNode next = null) { val = x; this.next = next; }
}

// Follow up: Could you do it in O(n) time and O(1) space?
public class Solution {
    public static bool IsPalindrome(ListNode head) {
        if (head == null) return false;

        // only one node, it's palindrome
        if (head.next == null) return true;

        ListNode fast = head;
        ListNode slow = head;
        while (fast.next != null && fast.next.next != null){
            slow = slow.next;
            fast = fast.next.next; 
        }

        ListNode halfHead = Reverse(slow.next);
        ListNode p = halfHead;
        ListNode q = head;

        bool result = true;
        while (p != null){
            
            if (p.val != q.val)
            {
                result = false;
                break;
            }

            p = p.next;
            q = q.next;
        }

        // retrieve the whole link
        halfHead = Reverse(halfHead);
        slow.next = halfHead;

        return result;
    }

    private static ListNode Reverse(ListNode head)
    {
        ListNode newHead = null;
        ListNode p = head;
        while (p != null) {
            ListNode q = p.next;
            p.next = newHead;
            newHead = p;
            p = q;
        }

        return newHead;
    }

    public static void Main(string[] args){
        ListNode head = new ListNode(1, 
            new ListNode(2, new ListNode(2, new ListNode(1))));
        TestAndPrint(head);

        head = new ListNode(1, 
            new ListNode(2, new ListNode(3, new ListNode(2, new ListNode(1)))));
        TestAndPrint(head);
        

        head = new ListNode(1, 
            new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(2, new ListNode(1))))));
        TestAndPrint(head);

        head = new ListNode(1, new ListNode(2));
        TestAndPrint(head);
    }

    public static void TestAndPrint(ListNode head){

        bool isPalindrome = IsPalindrome(head);
        Console.Write("List: ");
        while(head != null){ 
            Console.Write(head.val);

            if (head.next != null){
                Console.Write("->");
            }

            head = head.next;
        }


        Console.WriteLine((isPalindrome ? " is " : " is not ") + " a palindrom");
    }
}
