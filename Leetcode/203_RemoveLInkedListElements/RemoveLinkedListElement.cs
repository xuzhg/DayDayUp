// Given the head of a linked list and an integer val,
// remove all the nodes of the linked list that has Node.val == val, and return the new head.
using System;

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val, ListNode next = null) {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public static ListNode RemoveElements(ListNode head, int val)
    {
        ListNode p = head;
        ListNode q = null;
        while (p != null)
        {
            if (p.val == val){
                if (q == null){
                    head = p.next;
                    p = p.next;
                }
                else
                {
                    q.next = p.next;
                    p = p.next;
                }
            }
            else
            {
                q = p;
                p = p.next;
            }
        }

        return head;
    }

    public static void Main(string[] args)
    {
        int[] data = {1,2,6,3,4,5,6};
        ListNode root = null;
        for (int i = data.Length - 1; i >=0; --i)
        {
            root = new ListNode(data[i], root);
        }

        Console.Write("Original ");
        PrintList(root);

        Console.Write("Remove 6 ");
        root = RemoveElements(root, 6);
        PrintList(root);

        Console.Write("Remove 1 ");
        root = RemoveElements(root, 1);
        PrintList(root);

        Console.Write("Remove 5 ");
        root = RemoveElements(root, 5);
        PrintList(root);

        Console.Write("Remove 4 ");
        root = RemoveElements(root, 4);
        PrintList(root);

        Console.Write("Remove 14 ");
        root = RemoveElements(root, 14);
        PrintList(root);

        Console.Write("Remove 3 ");
        root = RemoveElements(root, 3);
        PrintList(root);

        Console.Write("Remove 2 ");
        root = RemoveElements(root, 2);
        PrintList(root);
    }

    private static void PrintList(ListNode list)
    {
        Console.Write("List: [");
        while(list != null){
            Console.Write(list.val);
            list = list.next;
            if (list != null){
                Console.Write("->");
            }
        }

        Console.WriteLine("]");
    }
}