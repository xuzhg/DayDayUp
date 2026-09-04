/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode p = l1;
        ListNode q = l2;

        ListNode h = null;
        ListNode last = null;
        int carry = 0;
        while (true) {

            int pValue = p != null ? p.val : 0;
            int qValue = q != null ? q.val : 0;

            int sum = pValue + qValue + carry;
            if (sum >= 10) {
                sum = sum - 10;
                carry = 1;
            }
            else{
                carry = 0;
            }

            ListNode newNode = new ListNode(sum);
            if (h == null) {
                h = newNode;
            }
            else{
                last.next = newNode;
            }

            last = newNode;
            p = p != null ? p.next : null;
            q = q != null ? q.next : null;

            if (p == null && q == null && carry == 0)
            {
                break;
            }
        }

        return h;
    }
}
