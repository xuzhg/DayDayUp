// Medium
// Given an integer array nums, 
// return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

// Notice that the solution set must not contain duplicate triplets.
using System;
using System.Collections.Generic;

public class Solution
{
    ///
    public static IList<IList<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);

        IList<IList<int>> list = new List<IList<int>>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (i != 0 && nums[i] == nums[i-1]){
                continue;
            }

            int k = nums.Length - 1;
            int target = -nums[i];
            for (int j = i + 1; j < nums.Length; ++j)
            {
                if (j != i + 1 && nums[j] == nums[j-1]){
                    continue;
                }

                while (j < k && nums[j] + nums[k] > target) {
                    --k;
                }

                if (j == k)
                    break;

                if (nums[j] + nums[k] == target) {
                    list.Add(new List<int>{ nums[i], nums[j], nums[k] });
                }
            }
        }

        return list;        
    }
    

    public static void Main(string[] args)
    {
        Test(new int[] {-1,0,1,2,-1,-4});

        Test(new int[] {});

        Test(new int[] {0});

    }

    private static void Test(int[] nums){
        Console.Write("List:[");
        for (int i = 0; i < nums.Length; ++i) {
            Console.Write($"{nums[i]}");
            if (i != nums.Length - 1) {
                Console.Write(",");
            }
        }
        Console.Write("]\n");

        var list = ThreeSum(nums);

        foreach(var subList in list){
            Console.Write("  (");
            foreach (var num in subList){
                Console.Write($"{num},");
            }
            Console.WriteLine("\b)");
        }
    }
}