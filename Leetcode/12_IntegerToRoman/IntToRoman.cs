/*
Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.

Symbol       Value
I             1
V             5
X             10
L             50
C             100
D             500
M             1000

For example, 2 is written as II in Roman numeral, just two one's added together.
 12 is written as XII, which is simply X + II. 
 The number 27 is written as XXVII, which is XX + V + II.

Roman numerals are usually written largest to smallest from left to right.
 However, the numeral for four is not IIII. Instead, the number four is written as IV.
  Because the one is before the five we subtract it making four.
   The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:

I can be placed before V (5) and X (10) to make 4 and 9. 
X can be placed before L (50) and C (100) to make 40 and 90. 
C can be placed before D (500) and M (1000) to make 400 and 900.
Given an integer, convert it to a roman numeral.
*/
using System;
using System.Text;

public class Solution {
    public static string IntToRoman(int num) {
        StringBuilder sb = new StringBuilder();
        while (num > 0) {
            if (num >= 1000) {
                sb.Append('M');
                num -= 1000;
            }
            else if (num >= 900) {
                sb.Append("CM");
                num -= 900;
            }
            else if (num >= 500) {
                sb.Append('D');
                num -= 500;
            }
            else if (num >= 400){
                sb.Append("CD");
                num -= 400;
            }
            else if (num >= 100) {
                sb.Append('C');
                num -= 100;
            }
            else if (num >= 90) {
                sb.Append("XC");
                num -= 90;
            }
            else if (num >= 50) {
                sb.Append('L');
                num -= 50;
            }
            else if (num >= 40) {
                sb.Append("XL");
                num -= 40;
            }
            else if (num >= 10){
                sb.Append('X');
                num -= 10;
            }
            else if (num >= 9) {
                sb.Append("IX");
                num -= 9;
            }
            else if (num >= 5) {
                sb.Append('V');
                num -= 5;
            }
            else if (num == 4) {
                sb.Append("IV");
                break;
            }
            else if (num == 3){
                sb.Append("III");
                break;
            }
            else if (num == 2) {
                sb.Append("II");
                break;
            }
            else{
                sb.Append("I");
                break;
            }
        }

        return sb.ToString();
    }

    public static void Main(string[] args){
        Console.WriteLine($"3 => {IntToRoman(3)}");
        Console.WriteLine($"4 => {IntToRoman(4)}");
        Console.WriteLine($"5 => {IntToRoman(5)}");
        Console.WriteLine($"6 => {IntToRoman(6)}");
        Console.WriteLine($"8 => {IntToRoman(8)}");
        Console.WriteLine($"9 => {IntToRoman(9)}");
        Console.WriteLine($"10 => {IntToRoman(10)}");
        Console.WriteLine($"11 => {IntToRoman(11)}");
        Console.WriteLine($"58 => {IntToRoman(58)}");
        Console.WriteLine($"1994 => {IntToRoman(1994)}");
    }
}