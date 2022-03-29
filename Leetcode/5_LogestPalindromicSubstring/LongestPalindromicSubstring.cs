// Given a string s, return the longest palindromic substring in s.
using System;

public class Solution
{
    public static string LongestPalindrome(string s){
        if (s == null) return null;

        int start = -1;
        int maxLength = -1;
        for (int i = 0; i < s.Length - 1; ++i)
        {
            int j = s.Length - 1;
            while(true)
            {
                // reverse find the first character equals to the s[i]
                while(j > i && s[j] != s[i])
                {
                    --j;
                }

                // if we can't find a charactor same as s[i], stop it and move i to next position.
                if (j <= i) break;

                // Let's compare one by one between [i+1, j-1].
                int p = i + 1;
                int q = j - 1;

                while (p < q){
                    if (s[p] == s[q]){
                        ++p;
                        --q;
                    }
                    else
                    {
                        break;
                    }
                }

                if (p >= q)
                {
                    // find a max
                    int length = j - i + 1;
                    if (length > maxLength)
                    {
                        start = i;
                        maxLength = length;
                        break;
                    }
                }
                
                // let's continue to look the next palindromic string
                // "abaea" ==> s[4] = 'a', but, it can't be part of palindromic
                // we should continue to search the next palindromic as "aba"
                --j;
            }
        }

        if (start < 0) {
            return s.Substring(0, 1);
        }

        return s.Substring(start, maxLength);
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("babad = " + LongestPalindrome("babad"));

        Console.WriteLine("s = " + LongestPalindrome("s"));

        Console.WriteLine("ac = " + LongestPalindrome("ac"));

        Console.WriteLine("cbbd = " + LongestPalindrome("cbbd"));

        Console.WriteLine("cabacad = " + LongestPalindrome("cabacad"));

        Console.WriteLine("efaabccbaabb = " + LongestPalindrome("efaabccbaabb"));
    }
}