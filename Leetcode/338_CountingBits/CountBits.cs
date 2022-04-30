/*
Given an integer n, return an array ans of length n + 1 such that for each i (0 <= i <= n),
 ans[i] is the number of 1's in the binary representation of i.
*/

public class Solution {
    public int[] CountBits(int n) {
        if (n < 0) return Array.Empty<int>();

        int[] ans = new int[n+1];
        for (int i = 0; i <= n; ++i){
            ans[i] = Numberof1Bits(i);
        }   

        return ans;
    }

    private static int Numberof1Bits(int n) {
        int c = 0;
        while (n != 0) {
            ++c;
            n = n & (n - 1);            
        }

        return c;
    }

    // 改进：
    // 我们注意到上面 NumberOf1Bits的计算，计算n中含有1的个数是把n和n-1做与（&）运算，然后每次+1
    // 也就是n上1的个数，应该 【n & （n-1）】上的1的个数+1.
    public int[] CountBits2(int n) {
        if (n < 0) return Array.Empty<int>();

        int[] ans = new int[n+1];
        ans[0] = 0;
        for (int i = 1; i <= n; ++i){
            ans[i] = ans[i & (i-1)] + 1;
        }   

        return ans;
    }
}