/*

Implement strStr().

Given two strings needle and haystack, return the index of the first occurrence of needle in haystack,
 or -1 if needle is not part of haystack.

Clarification:

What should we return when needle is an empty string? This is a great question to ask during an interview.

For the purpose of this problem, we will return 0 when needle is an empty string. This is consistent to C's strstr() and Java's indexOf().
*/
using System;
public class Solution {
    public static int StrStr(string haystack, string needle) {
        if (string.IsNullOrEmpty(haystack)) return -1;
        if (string.IsNullOrEmpty(needle)) return 0;

        for (int i = 0; i < haystack.Length; i++)
        {
            if (haystack[i] != needle[0])
            {
                continue;
            }

            int j = 0;
            for (; j < needle.Length; j++){

                if (i + j > haystack.Length - 1) return -1;

                if (haystack[i + j] != needle[j]){
                    break;
                }
            }

            if (j == needle.Length) return i;
        }

        return -1;
    }
    public static void Main(string[] args){
        string haystack = "Hello";
        string needle = "ll";

        Console.WriteLine($"{needle} is at {StrStr(haystack, needle)} of {haystack} ");

        haystack = "Hello";
        needle = "lllo";
        Console.WriteLine($"{needle} is at {StrStr(haystack, needle)} of {haystack} ");

        haystack = "Helllo";
        needle = "lllo";
        Console.WriteLine($"{needle} is at {StrStr(haystack, needle)} of {haystack} ");
    }
}