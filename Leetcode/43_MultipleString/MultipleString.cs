/*
Given two non-negative integers num1 and num2 represented as strings,
return the product of num1 and num2, also represented as a string.

Note: You must not use any built-in BigInteger library or convert the inputs to integer directly.
*/
using System;

public class Solution {
    public static string Multiply(string num1, string num2) {
        if (string.IsNullOrEmpty(num1)) return num2;
        if (string.IsNullOrEmpty(num2)) return num1;

        // non-negative & integer
        string result = "0";
        for (int i = num2.Length - 1; i >= 0; i--) {
            char c = num2[i];
            int pending = num2.Length - i - 1;
            string a = Multiply_One(num1, c, pending);
            result = Add(a, result);
        }
        return result;
    }

    private static string Add(string num1, string num2){
        int max = num1.Length > num2.Length ? num1.Length : num2.Length;

        char[] result = new char[max + 1]; // potential carry
        int i = 0;
        int carry = 0;
        int index = max; // because we have + 1 for the result.
        while (i < max){

            int a_index = num1.Length - 1 - i;
            int a = a_index >= 0 ? (int)(num1[a_index] - '0') : 0;

            int b_index = num2.Length - 1 - i;
            int b = b_index >= 0 ? (int)(num2[b_index] - '0') : 0;

            int sum = a + b + carry;
            carry = sum / 10;
            int c = sum % 10;
            char ch_c = (char)(c + (int)('0'));
            result[index--] = ch_c;
            ++i;
        }

        if (carry > 0) {
            char ch_c = (char)(carry + (int)('0'));
            result[index] = ch_c;
            return new string(result, 0, max + 1);
        }
        else
        {
            return new string(result, 1, max);
        }
    }

    private static string Multiply_One(string nums, char a, int pending)
    {
        // pending is how many zero to append
        // + 1 means potential carry
        int length = nums.Length + pending + 1;
        char[] result = new char[length];

        int index = length - 1;
        for (int i = 0; i < pending; i++){
            result[index--] = '0';
        }

        int a_num = (int)(a - '0');
        int carry = 0;
        for (int i = nums.Length - 1; i >= 0; i--){
            char b = nums[i];
            int b_num = (int)(b - '0');
            int c_num = a_num * b_num + carry;

            carry = c_num / 10;
            c_num = c_num % 10;
            char c = (char)(c_num + (int)('0'));
            result[index--] = c;
        }

        int k = 0;
        if (carry != 0) {
            char c = (char)(carry + (int)('0'));
            result[0] = c;
            k = 0;
        }
        else
        {
            k = 1;
        }

        while (k < length){
            if (result[k] != '0')
            {
                break;
            }
            ++k;
        }

        return new string(result, k, length - k);
    }

    public static void Main(string[] args){
        string nums1 = "123";
        string nums2 = "456";
        string result = Multiply(nums1, nums2);
        Console.WriteLine($"{nums1} * {nums2} = {result}");


        nums1 = "2";
        nums2 = "3";
        result = Multiply(nums1, nums2);
        Console.WriteLine($"{nums1} * {nums2} = {result}");

        nums1 = "102";
        nums2 = "9999999999";
        result = Multiply(nums1, nums2);
        Console.WriteLine($"{nums1} * {nums2} = {result}");

        nums1 = "0";
        nums2 = "9999999999";
        result = Multiply(nums1, nums2);
        Console.WriteLine($"{nums1} * {nums2} = {result}");
    }
}