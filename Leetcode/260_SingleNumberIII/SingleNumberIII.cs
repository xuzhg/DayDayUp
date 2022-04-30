/*
Given an integer array nums, in which exactly two elements appear only once and all the other elements appear exactly twice. Find the two elements that appear only once. You can return the answer in any order.

You must write an algorithm that runs in linear runtime complexity and uses only constant extra space.
*/
using System;
public class Solution {
    // 还是需要用异或
    // 如果两个相同的数异或，结果的所有二进制全0
    // 如果两个不相同的数a，b异或，结果C中必然有二进制位位1
    //  这个1是如何产生的呢？可以肯定a，b上对应的位一个是0，一个是1
    // 我们可以用这个数位做为掩码d，
    //   a:   xxxxxx0xxxx
    //   b:   xxxxxx1xxxx
    //   c:   xxxxxx1xxxx
    //   d：  00000010000
    // a & d  == 0000000000
    // b & d  == 00000010000

    public static int[] SingleNumber(int[] nums) {
        int c = nums[0];
        for (int i = 1; i < nums.Length; ++i){
            c ^= nums[i];
        }
        Console.WriteLine($"c = {c}");
        // C就是数组中两个不想当的数异或的结果
        int[] results = {0, 0};
        int d = c & (-c); 
        Console.WriteLine($"d = {d}");
        for (int i = 0; i < nums.Length; ++i){
            if ((nums[i] & d) == 0){
                results[0] ^= nums[i];
            }
            else
            {
                results[1] ^= nums[i];
            }
        }

        return results;
    }

    public static void Main(string[] args) {
        int[] nums = {1,2,1,3,2,5};
        int[] result = SingleNumber(nums);
        Console.WriteLine($"({result[0]},{result[1]})");
    }
}