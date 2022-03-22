using System;

namespace Any;

public class Program
{
    public static void Main(string[] args)
    {
        Test("0", "0");
        Test("0", "1");
        Test("1", "1");
        Test("11", "1");
        Test("1010", "1011");
        Test("1010", "10000001011");
        Test("1011101010101010101010101010011010", "10000001011");
    }

    public static void Test(string a, string b){
        Console.WriteLine($"{a} + {b} = {AddBinary(a, b)}");
    }

    public static string AddBinary(string a, string b) {
        int alen = a.Length;
        int blen = b.Length;
        int max = alen > blen ? alen : blen;
        //Console.WriteLine(max);
        int i = alen - 1;
        int j = blen - 1;
        char[] d = new char[max + 1]; // 1 is for the potential carry
        int carry = 0;
        int k = max;
        while(i >= 0 || j >= 0)
        {
            int ca = 0;
            if (i >= 0){
                ca = a[i--] - '0';
            }

            int cb = 0;
            if (j >= 0){
                cb = b[j--] - '0';
            }

            int sum = ca + cb + carry;
            d[k--] = sum % 2 == 0 ? '0' : '1';
            carry = sum / 2;
        }

        // Console.WriteLine(d);
        if (carry > 0){
            d[0] = '1';
            return new string(d);
        }
        else
            return new string(d, 1, max);
    }
}