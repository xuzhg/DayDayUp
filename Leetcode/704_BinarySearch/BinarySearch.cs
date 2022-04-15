/*
Given an array of integers nums which is sorted in ascending order,
and an integer target, write a function to search target in nums. If target exists, then return its index. Otherwise, return -1.

You must write an algorithm with O(log n) runtime complexity.
*/
using System;

public class Solution {
    public static int Search(int[] nums, int target) {
        if (nums == null || nums.Length == 0) return -1;

        int start = 0;
        int end = nums.Length - 1;

        while (start <= end)
        {
            int mid = start + (end - start) / 2;

            if (target == nums[mid]){
                return mid;
            }
            else if (target > nums[mid]){
                start = mid + 1;
            }
            else{
                end = mid - 1;
            }
        }

        return -1;
    }

    public static void Main(string[] args){
        int[] nums = {-1,0,3,5,9,12};
        Console.WriteLine("Search 9 result is at: " + Search(nums, 9));

        Console.WriteLine("Search 2 result is at: " + Search(nums, 2));
    }
}