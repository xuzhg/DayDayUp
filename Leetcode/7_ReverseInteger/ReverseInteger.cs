// Given a signed 32-bit integer x,
// return x with its digits reversed. If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1], then return 0.
using System;

public class Solution
{
    public static int Reverse(int x)
    {
        // 123 -> 321
        // -123 -> -321
        bool positive = x >=0 ? true : false;
        int n = 0;
        while(x != 0)
        {
            int y = x / 10;
            int z = x - y * 10; // we cal also use x % 10 to get the last digit

            if (positive && n > (int.MaxValue - z) / 10)
            {               
                return 0;
            }
            else if (!positive && n < (int.MinValue - z ) / 10)
            {
                return 0;
            }

            n = n * 10 + z;
            x = y;
        }

        return n;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine($"123 revered as {Reverse(123)}");

        Console.WriteLine($"-123 revered as {Reverse(-123)}");

        Console.WriteLine($"120 revered as {Reverse(120)}");

        Console.WriteLine($"-12000100 revered as {Reverse(-12000100)}");

        Console.WriteLine($"{int.MinValue} revered as {Reverse(int.MinValue)}");
    }
}