// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
// You may assume that each input would have exactly one solution, and you may not use the same element twice.
// You can return the answer in any order.

// Solution 1: 
// two for loops, it's O(n^2)

// Solution 2: 
// use a dictionary
using System;
using System.Collections.Generic;

namespace TwoSumNs;

public class Solution
{
    public static int[] TwoSum(int[] nums, int target)
    {
        // a map used to map a value and it's position index
        IDictionary<int, int> map = new Dictionary<int, int>();
        int[] ret = new int[2];

        for (int i = 0; i < nums.Length; ++i)
        {
            if (map.ContainsKey(target - nums[i]))
            {
                ret[0] = map[target - nums[i]];
                ret[1] = i;
                break;
            }

            map[nums[i]] = i;
        }

        return ret;
    }

    public static void Main(string[] args)
    {
        int[] data = { 2,7,11,15 };
        int[] ret = TwoSum(data, 9);
        Console.WriteLine($"{ret[0]}, {ret[1]}");
    }
}