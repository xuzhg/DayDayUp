/*
Write a function that takes an unsigned integer and returns the number of '1' bits it has (also known as the Hamming weight).

Note:

Note that in some languages, such as Java, there is no unsigned integer type. In this case, the input will be given as a signed integer type. It should not affect your implementation, as the integer's internal binary representation is the same, whether it is signed or unsigned.
In Java, the compiler represents the signed integers using 2's complement notation. Therefore, in Example 3, the input represents the signed integer. -3.
*/

public class Solution {
    public int HammingWeight(uint n) {
        int k = 0;
        while (n != 0) {
            if ((n & 0x1) == 0x1){
                ++k;
            }

            n >>= 1;
        }

        return k;
    }

    // Good Solution: 
    // 思路：一个数减去1和自身与，相当于把自身最右边一个1变成0.
    //   比如： 11001， 减去1，变成 11000， （11001 & 11000）就等于11000
    //   在比如： 111000， 减去1， 变成 110111， 则（111000 & 110111） == 110000，原来最后一个1变成0
    //   如果，可以有如下的代码：
    public int HammingWeight2(uint n) {
        int k = 0;
        while (n != 0) {
            ++k;
            n = n & (n - 1);
        }

        return k;
    }
}