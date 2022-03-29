// Medium
// Given an integer array nums, 
// return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

// Notice that the solution set must not contain duplicate triplets.
using System;
using System.Collections.Generic;

public class Solution
{
    // Bad performance and not delete the duplicated
    public static async IList<IList<int>> ThreeSum1(int[] nums)
    {
        IList<IList<int>> ret = new List<IList<int>>();

        for (int i = 0; i < nums.Length - 2; ++i)
        {
            for (int j = i + 1; j < nums.Length - 1; ++j)
            {
                int sum = (nums[i] + nums[j]) * -1;

                for (int k = j + 1; k < nums.Length; ++k)
                {
                    if (nums[k] == sum)
                    {
                        ret.Add(new List<int>
                        {
                            nums[i], nums[j], nums[k]
                        });

                        break;
                    }
                }
            }
        }

        return ret;
    }

    public static async IList<IList<int>> ThreeSum1(int[] nums)
    {
        IList<IList<int>> ret = new List<IList<int>>();

        for (int i = 0; i < nums.Length - 2; ++i)
        {
            for (int j = i + 1; j < nums.Length - 1; ++j)
            {
                int sum = (nums[i] + nums[j]) * -1;

                for (int k = j + 1; k < nums.Length; ++k)
                {
                    if (nums[k] == sum)
                    {
                        ret.Add(new List<int>
                        {
                            nums[i], nums[j], nums[k]
                        });

                        break;
                    }
                }
            }
        }

        return ret;
    }

    public static void Main(string[] args)
    {

    }
}