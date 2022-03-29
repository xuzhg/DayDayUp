//Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
//
//An input string is valid if:
//
//Open brackets must be closed by the same type of brackets.
//Open brackets must be closed in the correct order.
// It also be nested, for example: "{[]}"
using System;
using System.Collections.Generic;

public class Solution
{
    public static bool IsValid(string s){
        if (s == null) return false;

        IDictionary<char, char> map = new Dictionary<char, char>
        {
            { ')', '(' },
            { '}', '{' },
            { ']', '[' }
        };

        Stack<char> stack = new Stack<char>();
        int i = 0;
        for (; i < s.Length; ++i)
        {
            char ch = s[i];
            if (map.ContainsKey(ch))
            {
                if (stack.Count <= 0)
                {
                    return false;
                }

                if (stack.Pop() != map[ch])
                {
                    return false;
                }
            }
            else
            {
                // If we only push the open parenthese into the stack, 
                // Then, we can allow any character in the string.
                stack.Push(ch);
            }
        }

        return stack.Count == 0;
    }

    public static void Main(string[] args)
    {
        string s = "()";
        Console.WriteLine(s + " is " + (IsValid(s) ? "valid" : "invalid"));

        s = "()[]{}";
        Console.WriteLine(s + " is " + (IsValid(s) ? "valid" : "invalid"));

        s = "(}";
        Console.WriteLine(s + " is " + (IsValid(s) ? "valid" : "invalid"));

        s = "{[]}";
        Console.WriteLine(s + " is " + (IsValid(s) ? "valid" : "invalid"));

        s = "({[()]})";
        Console.WriteLine(s + " is " + (IsValid(s) ? "valid" : "invalid"));

        s = "({[(]]})";
        Console.WriteLine(s + " is " + (IsValid(s) ? "valid" : "invalid"));

        s = "(";
        Console.WriteLine(s + " is " + (IsValid(s) ? "valid" : "invalid"));
    }
}