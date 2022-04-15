// Given an integer array nums, return true if any value appears at least twice in the array,
// and return false if every element is distinct.

using System;
using System.Collections.Generic;

public class Solution
{
    public static bool ContainsDuplicate(int[] nums){
        ISet<int> set = new HashSet<int>();
        for (int i = 0; i < nums.Length; ++i) {
            if (set.Contains(nums[i])) {
                return true;
            }

            set.Add(nums[i]);
        }

        return false;
    }

    public static void Main(string[] args)
    {
        int[] nums = {1,2,3,1};
        Console.WriteLine(ContainsDuplicate(nums));

        int[] nums2 = {3,3};
        Console.WriteLine(ContainsDuplicate(nums2));
    }
}