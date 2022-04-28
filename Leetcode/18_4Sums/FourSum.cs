/*
Given an array nums of n integers, return an array of all the unique quadruplets [nums[a], nums[b], nums[c], nums[d]] such that:

0 <= a, b, c, d < n
a, b, c, and d are distinct.
nums[a] + nums[b] + nums[c] + nums[d] == target
You may return the answer in any order.
*/
using System;
using System.Collections.Generic;
public class Solution {
    public static IList<IList<int>> FourSum(int[] nums, int target) {
        Array.Sort(nums);

        IList<IList<int>> list = new List<IList<int>>();
        for (int i = 0; i < nums.Length; ++i) {
            if (i != 0 && nums[i] == nums[i - 1]) continue;

            for (int j = i + 1; j < nums.Length; ++j) {
                if (j != i + 1 && nums[j] == nums[j - 1]) continue;

                int q = nums.Length - 1;
                int test = target - nums[i] - nums[j];
                for (int p= j + 1; p < nums.Length; ++p){
                    if (p != j + 1 && nums[p] == nums[p - 1]) continue;

                    while (p < q && nums[p] + nums[q] > test)
                        --q;

                    if (p == q) break;

                    if (nums[p] + nums[q] == test){
                        list.Add(new List<int>{ nums[i], nums[j], nums[p], nums[q]});
                    }
                }
            }
        }

        return list;
    }

     public static void Main(string[] args)
    {
        Test(new int[] {1,0,-1,0,-2,2}, 0);

        Test(new int[] {}, 0);

        Test(new int[] {0}, 0);

         Test(new int[] {2, 2, 2, 2, 2}, 8);

    }

    private static void Test(int[] nums, int target){
        Console.Write("List:[");
        for (int i = 0; i < nums.Length; ++i) {
            Console.Write($"{nums[i]}");
            if (i != nums.Length - 1) {
                Console.Write(",");
            }
        }
        Console.Write("]\n");

        var list = FourSum(nums, target);

        foreach(var subList in list){
            Console.Write("  (");
            foreach (var num in subList){
                Console.Write($"{num},");
            }
            Console.WriteLine("\b)");
        }
    }
}