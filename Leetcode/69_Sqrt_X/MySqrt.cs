/*
Given a non-negative integer x, compute and return the square root of x.

Since the return type is an integer, the decimal digits are truncated, and only the integer part of the result is returned.

Note: You are not allowed to use any built-in exponent function or operator, such as pow(x, 0.5) or x ** 0.5.
*/
using System;

public class Solution {
    public static int MySqrt(int x) {
        if (x == 0) return 0;
        if (x == 1) return 1;

        int left = 1;
        int right = x;
        int maxLeft = left;
        while (left <= right) {
            int mid = left + (right - left) / 2;

            int k = x / mid;

            if (k == mid) {
                return mid;
            }
            else if (k < mid) {
                maxLeft = mid -1;
                right = mid - 1;
            }
            else{
                left = mid + 1;
            }
        }

        return maxLeft;
    }

    // newton solution
    // Step 1: y = x^2 - C, if let y = 0,  x^2 = C, then x = sqrt(C), let x be positive
    // Step 2: let x0 = C, calculate y0 = x0^2 - C
    // Step 3: pass (x0, y0), form a line:   y = 2(x0)x + b, let's calculate b
    //    y0 = 2(x0)(x0) + b (y0=x0^2 - C)
    //   ==> b = x0^2 - C - 2x0^2
    //   ==> y = 2(x0)x + x0^2 - C - 2(x0)(x0) 
    // Let y = 0, we can get a new x, let this x is x1.
    //  0 = 2(x0)(x1) + x0^2 -C - 2x0^2
    //  2(x0)(x1) = x0^2 + C
    //     ==> x1 = (x0 + C/x0) / 2
    // Step 4: we get an algorithm:
    //      x(i+1) = (xi + C/xi) / 2
    public static int MySqrt_2(int C) {
        if (C == 0) return 0;
        if (C == 1) return 1;

        double x0 = C;
        double theald = 0.000000001;
        
        while(true)
        {
            double x1 = (x0 + C / x0) * 0.5;

            double v = x1 - x0;
            if (v < 0) v *= -1;
            if (v < theald) break;

            x0 = x1;
        }

        return (int)x0;
    }

    public static void Main(string[] args){
        Console.WriteLine($"Sqrt(4) = {MySqrt_2(4)}");

        Console.WriteLine($"Sqrt(8) = {MySqrt_2(8)}");

        Console.WriteLine($"Sqrt(2147483647) = {MySqrt_2(2147483647)}");
    }
}