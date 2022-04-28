/*
Given a string s consisting of some words separated by some number of spaces, return the length of the last word in the string.

A word is a maximal substring consisting of non-space characters only.
*/
using System;

public class Solution {
    public static int LengthOfLastWord(string s) {
        if (string.IsNullOrEmpty(s)) return 0;

        int length = 0;
        int start = -1;
        for (int i = 0; i < s.Length; i++) {
            char c = s[i];

            if (c == ' '){
                if (start != -1){
                    // we hit the end of one word
                    length = i - start;
                    start = -1;
                }
            }
            else{
                if (start == -1) {
                    start = i;
                }
            }
        }

        if (start != -1) {
            length = s.Length - start;
        }

        return length;
    }

    public static void Main(string[] args) {
        string s = "Hello World";
        Console.WriteLine($"The length of last word in '{s}' is {LengthOfLastWord(s)}");

        s = "   fly me   to   the moon  ";
        Console.WriteLine($"The length of last word in '{s}' is {LengthOfLastWord(s)}");

        s = "luffy is still joyboy";
        Console.WriteLine($"The length of last word in '{s}' is {LengthOfLastWord(s)}");

        s = "a";
        Console.WriteLine($"The length of last word in '{s}' is {LengthOfLastWord(s)}");
    }
}