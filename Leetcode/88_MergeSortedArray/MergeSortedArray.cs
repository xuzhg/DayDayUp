/*
You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, and two integers m and n, representing the number of elements in nums1 and nums2 respectively.

Merge nums1 and nums2 into a single array sorted in non-decreasing order.

The final sorted array should not be returned by the function,
 but instead be stored inside the array nums1.
  To accommodate this, nums1 has a length of m + n, where the first m elements denote the elements that should be merged,
   and the last n elements are set to 0 and should be ignored. nums2 has a length of n.
*/


/*----------------------------------------------------------------
nput: nums1 = [1,2,3,0,0,0], m = 3, nums2 = [2,5,6], n = 3
Output: [1,2,2,3,5,6]
Explanation: The arrays we are merging are [1,2,3] and [2,5,6].
The result of the merge is [1,2,2,3,5,6] with the underlined elements coming from nums1.
*/

using System;
public class Solution {
    public static void Merge(int[] nums1, int m, int[] nums2, int n) {
        if (nums1 == null || nums2 == null) return;
        if (n == 0) return;
        if (nums1.Length != (m + n)) return;

        int emptyIndex = m + n - 1;
        int i = m - 1;
        int j = n - 1;
        while (i >= 0 && j >= 0){
            if (nums1[i] > nums2[j]) {
                nums1[emptyIndex--] = nums1[i--];
            }
            else{
                nums1[emptyIndex--] = nums2[j--];
            }
        }

        while (j >=0){
            nums1[emptyIndex--] = nums2[j--];
        }
        
        // we don't need to do anything if nums1 still has the nums, because they are ordered, we don't need to move them.
    }

    public static void Main(string[] args)
    {
        {
            int[] nums1 = { 1,2,3,0,0,0 };
            int[] nums2 = { 2, 5, 6};
            Merge(nums1, 3, nums2, 3);

            Print(nums1);
        }

        {
            int[] nums1 = { 1 };
            int[] nums2 = Array.Empty<int>();
            Merge(nums1, 1, nums2, 0);

            Print(nums1);
        }

        {
            int[] nums1 = { 7,8,9, 10, 14, 19,0,0,0 };
            int[] nums2 = { 8, 11, 16};
            Merge(nums1, 6, nums2, 3);

            Print(nums1);
        }
    }

    private static void Print(int[] nums)
    {
        Console.Write("Array:");
        for (int i = 0; i < nums.Length; i++)
        {
            Console.Write(nums[i]);
            if (i != nums.Length - 1){
                Console.Write(",");
            }
        }

        Console.WriteLine();
    }
}