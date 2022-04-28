/*
Given an integer n, return true if it is a power of two. Otherwise, return false.

An integer n is a power of two, if there exists an integer x such that n == 2x.
*/

public class Solution {
    public bool IsPowerOfTwo1(int n) {
        if (n < 1) return false;
        if (n == 1) return true; // 1 == 2 ^ 0

        if (n % 2 == 1) return false; // any odd number is not a power of two

        while (n % 2 == 0) {
            n /= 2;
        }

        return n == 1;
    }


    // if a number is 2^n, then the binary of this number looks like "1000000...0".
    // There are only one '1' in the binary representation.
    // So, we can calculate the number of `1` in the binary of this number.
    // or, we can do as follows:
    public bool IsPowerOfTwo2(int n) {
        if (n < 1) return false;
        if (n == 1) return true; // 1 == 2 ^ 0

        return (n & (n - 1)) == 0;
    }

    public static void Main(string[] args){}
}