/*
Given the heads of two singly linked-lists headA and headB,
return the node at which the two lists intersect. If the two linked lists have no intersection at all, return null.
*/
using System;
using System.Collections.Generic;

public class ListNode{
    public int val;
    public ListNode next;
    public ListNode(int x, ListNode next = null) { val = x; this.next = next; }
}

public class Solution {
    public static ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        if (headA == null || headB == null) return null;

        Stack<ListNode> stackA = new Stack<ListNode>();
        ListNode p = headA;
        while(p != null){
            stackA.Push(p);
            p = p.next;
        }

        Stack<ListNode> stackB = new Stack<ListNode>();
        p = headB;
        while(p != null){
            stackB.Push(p);
            p = p.next;
        }

        ListNode pRet = null;
        while(stackA.Count > 0 && stackB.Count > 0) {
            ListNode aTop = stackA.Pop();
            ListNode bTop = stackB.Pop();

            if (aTop != bTop) {
                break;
            }
            else{
                pRet = aTop;
            }
        }

        return pRet;
    }

}