// copyright @Zhigang Xu  3/18/2022
// Implement the myAtoi(string s) function, which converts a string to a 32-bit signed integer (similar to C/C++'s atoi function).
// The algorithm for myAtoi(string s) is as follows:

// 1.Read in and ignore any leading whitespace.
// 2.Check if the next character (if not already at the end of the string) is '-' or '+'. Read this character in if it is either. This determines if the final result is negative or positive respectively. Assume the result is positive if neither is present.
// 3.Read in next the characters until the next non-digit character or the end of the input is reached. The rest of the string is ignored.
// 4.Convert these digits into an integer (i.e. "123" -> 123, "0032" -> 32). If no digits were read, then the integer is 0. Change the sign as necessary (from step 2).
// 5.If the integer is out of the 32-bit signed integer range [-2^31, 2^31 - 1], then clamp the integer so that it remains in the range. Specifically, integers less than -2^31 should be clamped to -2^31, and integers greater than 2^31 - 1 should be clamped to 2^31 - 1.
// 6.Return the integer as the final result.
// Note:

// Only the space character ' ' is considered a whitespace character.
// Do not ignore any characters other than the leading whitespace or the rest of the string after the digits.

#include <iostream>
using namespace std;

int myAtoi(string s){
    int length = s.length();

    if (length == 0) throw std::invalid_argument("empty string input");

    // we can use the iterator to process, but i don't want to do it like this.
    // string::iterator it = s.begin();
    int index = 0;

    // ignore the leading whitespaces
    while(index < length && s[index] == ' '){
        ++index;
    }

    // make sure it's not an empty or whitespace only string
    if (index == length) throw std::invalid_argument("empty string input");

    // now we are at the first non-whitespace character
    bool positive = true;
    if (s[index] == '-') 
    {
        positive = false;
        ++index;
    }    
    else if (s[index] == '+')
    {
        ++index;
    }

    // make sure it's not an empty or whitespace only string
    if (index == length) throw std::invalid_argument("wrong input");

    const int MaxInt = 0x7FFFFFFF;
    const int MinInt = 0x80000000;
    int result = 0;
    while (index != length){
        char ch = s[index];
        ++index;
        if (ch >= '0' && ch <= '9')
        {
            int b = (int)(ch - '0');
            if (positive)
            {
                if (result > (MaxInt - b) / 10){
                    // throw std::invalid_argument("Overflow max integer input");
                    return MaxInt;
                }

                result = result * 10 + b;
            }
            else
            {
                if (result < (MinInt + b) / 10){
                    // throw std::invalid_argument("Overflow min integer input");

                    return MinInt;
                }

                 result = result * 10 - b; //
            }

            // 这里有个致命的错误，如果输入的是最大的负数："-2147483648"
            //                                         "-91283472332"
            // 那么由于result 表示的正数，当处理最后一个字符 8的时候，会导致溢出
            // 溢出的原因是我们做正数来表示负数，正数最大值是 2147483647
            // 214748364 * 10 + 8 来计算，并保存在result中，就会出错（如果result只有32位的话）
            // 但是在现在的64位机器上，这个又不会出错，因为它不会溢出64位
            // result = result * 10 + b;
        }
        else
        {
            // stop reading the remaining non-digit charactor
            break;
        }
    }

    return result;
}

int main(){
    cout << "\"42\" = " << myAtoi("42")<< endl;
    cout << "\"    -42\" = " << myAtoi("   -42")<< endl;

    cout << "\" 4193 with words\" = " << myAtoi(" 4193 with words")<< endl;

    // Max integer
    cout << "\"2147483646\" = " << myAtoi("2147483646")<< endl;
    cout << "\"2147483647\" = " << myAtoi("2147483647")<< endl;
    cout << "\"2147483648\" = " << myAtoi("2147483648")<< endl;
    cout << "\"91283472332\" = " << myAtoi("91283472332")<< endl;

    // Minimun integer
    cout << "\"-2147483647\" = " << myAtoi("-2147483647")<< endl;
    cout << "\"-2147483648\" = " << myAtoi("-2147483648")<< endl;
    cout << "\"-2147483649\" = " << myAtoi("-2147483649")<< endl;
    cout << "\"-91283472332\" = " << myAtoi("-91283472332")<< endl;
    
    return 0;
}