/*
Given an integer array nums, return the greatest common divisor of the smallest number and largest number in nums.

The greatest common divisor of two numbers is the largest positive integer that evenly divides both numbers.
*/
using System;

public class Solution {
    public static int FindGCD(int[] nums) {
        if (nums.Length == 0) return 0;

        int min = int.MaxValue;
        int max = int.MinValue;

        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] > max) max = nums[i];
            if (nums[i] < min) min = nums[i];
        }

        int gcd = min;
        while(gcd >= 1){
            if (max % gcd == 0 && min % gcd == 0) {
                return gcd;
            }
            --gcd;
        }

        return 1;
    }

    public static void Main(string[] args){
        int[] nums = {2,5,6,9,10};
        Console.WriteLine($"GCD = {FindGCD(nums)}, expected = 2");

        int[] nums2 = {7,5,6,8,3};
        Console.WriteLine($"GCD = {FindGCD(nums2)}, expected = 1");
    }
}