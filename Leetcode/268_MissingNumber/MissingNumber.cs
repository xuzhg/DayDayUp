/*
Given an array nums containing n distinct numbers in the range [0, n],
 return the only number in the range that is missing from the array.
*/

public class Solution {
    public static int MissingNumber(int[] nums) {
        int n = nums.Length;
        int sum = n * (n + 1) / 2; // the sum from 0,1, 2,3,4,5,....,n 
        
        for (int i = 0; i < nums.Length; ++i){
            sum -= nums[i];
        }

        return sum;
    }
}