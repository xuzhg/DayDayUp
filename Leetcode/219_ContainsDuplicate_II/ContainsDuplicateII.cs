// Given an integer array nums and an integer k,
// return true if there are two distinct indices i and j in the array such that nums[i] == nums[j] and abs(i - j) <= k.
using System;
using System.Collections.Generic;

public class Solution
{
    public static bool ContainsNearbyDuplicate(int[] nums, int k) {

        // key is the int value, value is the index
        IDictionary<int, int> map = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; ++i)
        {
            if (map.TryGetValue(nums[i], out int index))
            {
                if ((i - index) <= k)
                {
                    return true;
                }
            }

            map[nums[i]] = i;
        }

        return false;
    }
}