/*
Given an integer n, return true if it is a power of three. Otherwise, return false.

An integer n is a power of three, if there exists an integer x such that n == 3^x.
*/

public class Solution {
    public bool IsPowerOfThree(int n) {
        if (n < 1) return false;
        if (n == 1) return true; // 1 == 3^0

        while (n % 3 == 0) {
            n /= 3;
        }

        return n == 1;
    }
}