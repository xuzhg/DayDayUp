/*
Given a non-empty array of integers nums, every element appears twice except for one. Find that single one.

You must implement a solution with a linear runtime complexity and use only constant extra space.
*/

using System;

public class Solution {

    // 我们知道，一个数和自己异或后就是0
    // 另： 一个数和0 异或后还是自己
    // a ^ b ^ a ==> b
    public static int SingleNumber(int[] nums) {
        int a = nums[0];
        for (int i = 1; i < nums.Length; i++) {
            a ^= nums[i];
        }
        return a;
    }

    public static void Main(string[] args) {
        int[] nums = {2, 2, 1};
        Console.WriteLine($"{SingleNumber(nums)} == 1");

        int [] nums2 = {4, 1, 2, 1, 4};
        Console.WriteLine($"{SingleNumber(nums2)} == 2");
    }
}