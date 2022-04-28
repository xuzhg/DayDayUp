/*
The count-and-say sequence is a sequence of digit strings defined by the recursive formula:

countAndSay(1) = "1"
countAndSay(n) is the way you would "say" the digit string from countAndSay(n-1), which is then converted into a different digit string.
To determine how you "say" a digit string, split it into the minimal number of groups so that each group is a contiguous section all of the same character. Then for each group, say the number of characters, then say the character. 
To convert the saying into a digit string, replace the counts with a number and concatenate every saying.
*/
using System;
using System.Text;

public class Solution {
    public static string CountAndSay(int n) {
        if (n == 1) return "1";

        string a = CountAndSay(n - 1);

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < a.Length; ) {
             
            char c = a[i];
            int j = i + 1;
            while (j < a.Length && a[j] == a[i]) ++j;

            int count = j - i;
            sb.Append(count.ToString());
            sb.Append(c);
            i = j;
        }
        
        return sb.ToString();
    }

    public static void Main(string[] args) {
        Console.WriteLine($"1  : {CountAndSay(1)}");
        Console.WriteLine($"2  : {CountAndSay(2)}");
        Console.WriteLine($"3  : {CountAndSay(3)}");
        Console.WriteLine($"4  : {CountAndSay(4)}");
        Console.WriteLine($"5  : {CountAndSay(5)}");
        Console.WriteLine($"6  : {CountAndSay(6)}");
        Console.WriteLine($"7  : {CountAndSay(7)}");
        Console.WriteLine($"8  : {CountAndSay(8)}");
        Console.WriteLine($"9  : {CountAndSay(9)}");
        Console.WriteLine($"10 : {CountAndSay(10)}");
    }
}