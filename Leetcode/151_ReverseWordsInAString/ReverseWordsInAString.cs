

// Given an input string s, reverse the order of the words.
// A word is defined as a sequence of non-space characters. The words in s will be separated by at least one space.

// Return a string of the words in reverse order concatenated by a single space.

// Note that s may contain leading or trailing spaces or multiple spaces between two words. The returned string should only have a single space separating the words. Do not include any extra spaces.

using System;
using System.Text;
using System.Collections.Generic;

public class Solution {
    public static string ReverseWords(string s) {
        if (s == null) return null;

        // we can use the split, but here let me using my process
        IList<string> words = new List<string>();

        bool isWord = false;
        int endIndex = 0;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            char ch = s[i];
            if (ch == ' ')
            {
                if (isWord)
                {
                    isWord = false;
                    words.Add(s.Substring(i+1, endIndex - i));   
                }
            }
            else
            {
                if (!isWord)
                {
                    isWord = true;
                    endIndex = i;
                }
            }
        }

        if (isWord)
        {
            words.Add(s.Substring(0, endIndex + 1));  
        }

        return string.Join(" ", words);
    }

    public static void Main(string[] args) {
        string s = " the  sky  is blue  ";
        Console.WriteLine(ReverseWords(s));

        Console.WriteLine(ReverseWords("the sky is blue"));


        Console.WriteLine(ReverseWords("  hello world  "));
    }
}