/*
Write a function to delete a node in a singly-linked list. 
You will not be given access to the head of the list, instead you will be given access to the node to be deleted directly.

It is guaranteed that the node to be deleted is not a tail node in the list.
*/

using System;
public class ListNode{
    public int val;

    public ListNode next;
    public ListNode(int x, ListNode next = null) { val = x; this.next = next; }
}

public class Solution {
    public static void DeleteNode(ListNode node) {
        if (node == null) return;

        // since the node is not a tail node.
        if (node.next == null) return; // do nothing if it's tail

        ListNode next = node.next;
        node.val = next.val;
        node.next = next.next;
    }
    

    public static void Main(string[] args)
    {
        ListNode node = new ListNode(5, new ListNode(1, new ListNode(9)));
        ListNode head = new ListNode(4, node);

        Print(head);
        DeleteNode(node);
        Print(head);

    }

    public static void Print(ListNode node){
        Console.Write("List: ");
        while(node != null){ 
            Console.Write(node.val);

            if (node.next != null){
                Console.Write("->");
            }

            node = node.next;
        }

        Console.WriteLine();
    }
}