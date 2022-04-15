// Given an integer array nums and two integers k and t, 
// return true if there are two distinct indices i and j in the array such that abs(nums[i] - nums[j]) <= t and abs(i - j) <= k.

using System;
using System.Collections.Generic;

public class Solution
{
    // [-2147483648,2147483647] 1, 1
    public static bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
    {
        if (nums == null) return false;
        if (nums.Length <= 1) return false;
        if (t < 0) return false;

        // 如果数组很大，而且没有一个相等，此时如果t==0，就会很耗时
        // 此时可以退化到 219， ContainsDuplicate II的问题
        if (t == 0) {
            IDictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++){
                if (map.TryGetValue(nums[i], out int index))
                {
                    if (i - index <= k){
                        return true;
                    }
                }

                map[nums[i]] = i; // 如果之前添加过，会更新，因为之前添加的已经不能满足 k 这个条件了
            }

            return false;
        }

        for (int i = 0; i < nums.Length; ++i)
        {
            for (int j = i + 1; j <= i + k; ++j)
            {
                if (j >= nums.Length) {
                    break;
                }

                // overflow
                if (nums[i] > 0 && nums[j] < 0) {
                    if (nums[i] > int.MaxValue + nums[j])
                    {
                        continue;
                    }
                }

                if (nums[i] < 0 && nums[j] > 0) {
                    if (nums[i] < int.MinValue + nums[j]) {
                        continue;
                    }
                }

                int diff = nums[i] - nums[j];

                if (diff < 0) {

                    if (diff >= t * -1) {
                        return true;
                    }
                }
                else if (diff <= t) {
                    return true;
                }
            }
        }

        return false;
    }

    public static void Main(string[] args){

        int[] nums3 = {2147483647,-1,2147483647};
        Console.WriteLine(ContainsNearbyAlmostDuplicate(nums3, 1, 2147483647)); // false

        int[] nums = {-2147483648,2147483647};
        Console.WriteLine(ContainsNearbyAlmostDuplicate(nums, 1, 1)); // false

        int[] nums2 = {2147483647, -2147483648};
        Console.WriteLine(ContainsNearbyAlmostDuplicate(nums2, 1, 1)); // false
    }
}
