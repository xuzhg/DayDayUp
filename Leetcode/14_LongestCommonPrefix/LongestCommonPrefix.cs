// Write a function to find the longest common prefix string amongst an array of strings.
// If there is no common prefix, return an empty string "".

using System;

namespace LongestCommonPrefixNs;

public class Solution
{
    public static string LongestCommonPrefix(string[] strs)
    {
        if (strs == null || strs.Length == 0) return string.Empty;

        if (strs.Length == 1) return strs[0];

        int i = 0;
        while(true)
        {
            if (i >= strs[0].Length)
            {
                break;
            }

            char ch = strs[0][i];
            int j = 1;
            for (; j < strs.Length; ++j)
            {
                if (i >= strs[j].Length || ch != strs[j][i])
                {
                    break;
                }
            }

            if (j != strs.Length)
            {
                break;
            }

            ++i;
        }

        return strs[0].Substring(0, i);
    }

    public static void Main(string[] args)
    {
        string[] strs = {"flower","flow","flight"};
        Console.WriteLine(LongestCommonPrefix(strs));

        string[] strs1 = {"dog","racecar","car"};
        Console.WriteLine(LongestCommonPrefix(strs1));

        string[] strs2 = {"dog","dogg","dogdog"};
        Console.WriteLine(LongestCommonPrefix(strs2));
    }
}