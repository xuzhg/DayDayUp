/*
ou are given a large integer represented as an integer array digits,
where each digits[i] is the ith digit of the integer.

The digits are ordered from most significant to least significant in left-to-right order.
The large integer does not contain any leading 0's.

Increment the large integer by one and return the resulting array of digits.
*/

public class Solution
{
     public static int[] PlusOne(int[] digits){
         
         int carry = 1;
         int i = digits.Length - 1;
         for (; i >= 0; --i){
             int sum = digits[i] + carry;
             carry = sum / 10;
             digits[i] = sum % 10;

             if (carry == 0){
                 break;
             }
         }

         if (i < 0 && carry == 1)
         {
             int[] newArray = new int[digits.Length + 1];
             newArray[0] = carry;
             for (int j = 0; j < digits.Length; ++j)
                newArray[j+1] = digits[j];
            
            return newArray;
         }

         return digits;
     }
}