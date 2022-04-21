/*
The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)

P   A   H   N
A P L S I I G
Y   I   R
And then read line by line: "PAHNAPLSIIGYIR"

Write the code that will take a string and make this conversion given a number of rows:

string convert(string s, int numRows);
*/


/*
如果输入： PAYPALISHIRING， 是4行
那么可以是如下的zigzag：
P     I    N
A   L S  I G
Y A   H R
P     I


‘PAYP’ AL ‘ISHI’ RI ‘NG’
竖行：zig，如PAYP
斜行：zag，如 AL

*/

using System;
using System.Text;

public class Solution {
    public static string Convert(string s, int numRows) {
        if (s == null || numRows <= 1) return s;
                
        StringBuilder sb = new StringBuilder();
        int iter = 2 * (numRows - 1);
        int length = s.Length;
        for (int i = 0; i < numRows; i++)
        {
            int zig = i;
            int zag;
            if (i == 0 || i == numRows - 1)
            {
                zag = length;
            }
            else
            {
                zag = numRows + numRows - 2 - i;
            }

            while (zig < length || zag < length)
            {

                if (zig < length)
                {
                    sb.Append(s[zig]);
                    zig += iter;
                }

                if (zag < length)
                {
                    sb.Append(s[zag]);
                    zag += iter;
                }
            }
        }

        return sb.ToString();
    }

    public static void Main(string[] args) {

        string s = Convert("A", 1);
        Console.WriteLine($"A as 1 is: => {s}");

        s = Convert("PAYPALISHIRING", 2);
        Console.WriteLine($"PAYPALISHIRING as 2 is: => {s}");

        s = Convert("PAYPALISHIRING", 3);
        Console.WriteLine($"PAYPALISHIRING as 3 is: => {s}");

        s = Convert("PAYPALISHIRING", 4);
        Console.WriteLine($"PAYPALISHIRING as 4 is: => {s}");

        s = Convert("PAYPALISHIRING", 5);
        Console.WriteLine($"PAYPALISHIRING as 5 is: => {s}");
    }
}