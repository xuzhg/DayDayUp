//Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
//
//An input string is valid if:
//
//Open brackets must be closed by the same type of brackets.
//Open brackets must be closed in the correct order.
using System;

public class Solution
{
    public static bool IsValid(string s){
        if (s == null) return false;

        int i = 0;
        for (; i < s.Length; ++i)
        {
            char ch = s[i];
            char nt;
            if (ch == '(') {
                nt = ')';
            }
            else if (ch == '{'){
                nt = '}';
            }
            else if (ch == '['){
                nt = ']';
            }
            else
            {
                return false;
            }

            ++i;
            if (i >= s.Length || s[i] != nt){
                return false;
            }
        }

        return true;
    }

    public static void Main(string[] args)
    {
        string s = "()";
        Console.WriteLine(s + " is " + (IsValid(s) ? "valid" : "invalid"));

        s = "()[]{}";
        Console.WriteLine(s + " is " + (IsValid(s) ? "valid" : "invalid"));

        s = "(}";
        Console.WriteLine(s + " is " + (IsValid(s) ? "valid" : "invalid"));
    }
}