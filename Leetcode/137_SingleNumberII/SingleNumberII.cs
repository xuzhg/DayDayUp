/*
Given an integer array nums where every element appears three times except for one, which appears exactly once. Find the single element and return it.

You must implement a solution with a linear runtime complexity and use only constant extra space.
*/

public class Solution {
    // 每个数在计算机里表示成二进制，就是0，1
    // 比如： 5 ==> 101
    // 那么如果有3个5相加，其实就是对应位相加3次。
    // 5 + 5 + 5 =>  （1+1+1）（0+0+0）（1+1+1)
    //   如果我们对每一个位（是二进制位，但是位上数字不是二进制0，1）对3取余，结果就是一个0
    // 此时如果有另一个数，比如 6 ==》 110
    // 5 + 5 + 5 + 6 => (1+1+1+1)（0+0+0+1）（1+1+1+0）
    // 如果我们对每一位对3取余，
    //       从右数第一位： （1+1+1+0）% 3 = 0
    //       从右数第二位： （0+0+0+1）% 3 = 1
    //       从右数第三位： （1+1+1+1）% 3 = 1
    // 最后的结果就是 110,也就是 数字6
    // 如果二进制的每一位表示三中状态，我们就可以解决这个问题。
    // 但是二进制中的每一位只能表示0，1两种状态
    // 如果处理呢？
    // 我们看： 每个二进制位的出现的累加数字是：0->1->2->0 (对3取余）
    // 也就是二进制： 00， 01， 10， 00 
    // 如果我们用ab来表示这个二进制：
    // a: 0   0  1  0 
    // b: 0   1  0  0
    // 如果我们可以构建两个掩码：一个表示原来每个二进制位的累加后对应二进制的各位 --> bbbbbb
    //                       另一个表示原来每个二进制位的累加后对应二进制的十位 --> aaaaaa

    // 来看b掩码中每一位的变化规律：（我们只考虑新进来的位上1的情况，0可以不用考虑，需要保持a，b不会改变
    // 1） 如果新进的数对应位是0，我们需要保持a，b不变
    //        b = (b ^ number) & ~a
    //       ab == 00 => b = (0 ^ 0) & ~0 = 0 保持b不变还是0
    //       ab == 01 => b = (1 ^ 0) & ~1 = 1 保持b不变还是1
    //       ab == 10 => b = (0 ^ 0) & ~1 = 0 保持b不变还是0
  
    // 2） 如果新进的数对应位是1，此时需要ab做变化： 00 -> 01 -> 10 -> 00
    //  b = (b ^ number) & ~a
    //       ab == 00 => b = (0 ^ 1) & ~0 = 1   b变成1
    //       ab == 01 => b = (1 ^ 1) & ~0 = 0   b变成0
    //       ab == 10 => b = (0 ^ 1) & ~1 = 0   保持b不变还是0
    //
    // 类似a的变化是 a = (a ^ numnber) & ~b    

    public int SingleNumber(int[] nums) {
        int a = 0, b = 0;
        for (int i = 0; i < nums.Length; i++){
            b = (b ^ nums[i]) & ~a;
            a = (a ^ nums[i]) & ~b;
        }

        return b;
    }
}