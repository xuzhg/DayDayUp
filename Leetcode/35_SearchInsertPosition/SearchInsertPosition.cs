/*
Given a sorted array of distinct integers and a target value,
return the index if the target is found.
If not, return the index where it would be if it were inserted in order.

You must write an algorithm with O(log n) runtime complexity.
*/
using System;
using System.Linq;
public class Solution {
    public static int SearchInsert(int[] nums, int target) {
        if (nums == null) return -1;

        int left = 0;
        int right = nums.Length - 1;
        while(left <= right){
            int mid = left + (right - left) / 2;
            if (nums[mid] == target)
              return mid;
            if (nums[mid] > target) {
                if (mid == 0) return 0;
                if (nums[mid - 1] < target) return mid;

                right = mid - 1;
            }
            else{
                left = mid + 1;
            }
        }

        return left;
    }

    public static void Main(string[] args)
    {
        int[] nums = {1, 3, 5, 7};
        for (int i = 0; i < nums.Length; i++) {
            Console.Write($"{nums[i]},");
        }
        Console.WriteLine();
        Console.WriteLine($"Search Insert Position of 5 is: {SearchInsert(nums, 5)}");

        Console.WriteLine($"Search Insert Position of 2 is: {SearchInsert(nums, 2)}");

        Console.WriteLine($"Search Insert Position of 0 is: {SearchInsert(nums, 0)}");
        
        Console.WriteLine($"Search Insert Position of 4 is: {SearchInsert(nums, 4)}");

        Console.WriteLine($"Search Insert Position of 8 is: {SearchInsert(nums, 8)}");

        Console.WriteLine($"Search Insert Position of 7 is: {SearchInsert(nums, 7)}");

        Console.WriteLine($"Search Insert Position of 6 is: {SearchInsert(nums, 6)}");

    }
}