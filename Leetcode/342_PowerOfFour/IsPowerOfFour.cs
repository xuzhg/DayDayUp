/*
Given an integer n, return true if it is a power of four. Otherwise, return false.

An integer n is a power of four, if there exists an integer x such that n == 4^x.
*/


public class Solution {
    // 一个数如果是4的次方数，那么一定也是2的次方数，
    // 反之，则不是，比如2是2的1次方，但是不是4的次方数
    // 但是，我们看到，2的偶数次方数，就是4的次方数
    public bool IsPowerOfFour(int n) {
        if (n < 1) return false;
        if (n == 1) return true;

        bool isPowerOfTwo = (n & n - 1) == 0;
        if (!isPowerOfTwo)
        {
            return false;
        }

        int count = 0;
        while (n > 0) {
            ++count;
            n = n >> 1; // right shift 1
        }

        return (count % 2) == 1;
    }

    // 也可以不要上面的 右移，如果是4的次方数，那么就是2的偶数次方数。
    // 对应的二进制表示只有一个1，而且在奇数位置上。
    // 比如：4 ==> 100
    //      16 ==> 10000
    // 所以我们可以用  0x55555555 = 1010101010101010101010101010101（b) 作为掩码来和数做与，如果
    // 结果还是本身，就说明 唯一的1 在奇数位置上。就是4的次方数
}