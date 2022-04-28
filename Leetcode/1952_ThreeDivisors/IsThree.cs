/*
Given an integer n, return true if n has exactly three positive divisors. Otherwise, return false.

An integer m is a divisor of n if there exists an integer k such that n = k * m.
*/

using System;
public class Solution {
    // 如果一个整数只有3个因子，那么这个数一定是一个平方数
    // 而且它的平方跟是素数.
    // 所以，比较简单的方式就是 看看这个数是不是一个素数的平方数。
    // 如果没有办法确定是不是一个素数的平方数，我们就循环来测试
    public static bool IsThree(int n) {
        if (n <= 3) return false;

        int c = 2; // 1 & n 是因子，我们直接跳过
        // 此外，如果存在因子，一定介于 [2, n/2] 之间
        for (int i = 2; i <= n / 2; ++i) {
            if (n % i == 0) {
                ++c;

                if (c > 3) return false;
            }
        }

        return c == 3;
    }

    public static void Main(string[] args){
        Console.WriteLine($"3 is {IsThree(3)}  == false");

        Console.WriteLine($"4 is {IsThree(4)}  == true");
    }
}