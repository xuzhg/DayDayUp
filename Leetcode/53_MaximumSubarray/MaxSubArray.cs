/*
Given an integer array nums, find the contiguous subarray (containing at least one number)
 which has the largest sum and return its sum.

A subarray is a contiguous part of an array.
*/

using System;
public class Solution {
    public static int MaxSubArray(int[] nums) {
        if (nums == null || nums.Length == 0) return 0;

        int maxSum = nums[0];
        int iteSum = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            if (iteSum < 0) {
                iteSum = nums[i];
            }
            else
            {
                iteSum += nums[i];
            }

            if (iteSum > maxSum) maxSum = iteSum;
        }

        return maxSum;
    }

    public static void Main(string[] args){
        {
            TestAndPrint(new int[] { -2, 1,-3, 4,-1, 2, 1, -5, 4 });

            TestAndPrint(new int[] { 1 });

            TestAndPrint(new int[] { 5,4,-1,7,8 });
        }
    }

    private static void TestAndPrint(int[] nums){

        int maxSub = MaxSubArray(nums);
        Console.Write($"The max sub is {maxSub} in array: ");
        for (int i = 0; i < nums.Length; ++i)
        {
             Console.Write($"{nums[i]}");
             if (i != nums.Length - 1){
                 Console.Write(",");
             }
        }

        Console.WriteLine();
    }
}