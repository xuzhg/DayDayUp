// copyright @Sam Xu  3/15/2022
// Given a string, find the lenght of the longest substring without repeating characters.

#include <iostream>
#include <cstring>
using namespace std;

int LengthOfLongestSubstring(const char* str)
{
    if (str == nullptr){
        throw std::invalid_argument("invalid input string");
    }

    int max = -1;
    const char * start; // the max substring starting.
    const char * end; // the next of the max substring ending
    const char * h = str;
    const char * p;
    
    while(*h != '\0')
    {
        p = h;
        ++p; // 'p' points to the next character after 'h'
        for (; *p != '\0'; ++p)
        {
            const char * q = h;
            for (; q != p; ++q){
                if (*q == *p){
                    break;
                }
            }

            if (p != q) // found repeat
            {
                int length = (int)(p - h);
                if (length > max){
                    max = length;
                    start = h;
                    end = p;
                }

                // key point here: we iterate from the repeated position
                // then we will move backward using (++h) to start from the next position
                // of the first repeat character.
                h = q;
                break;
            }
        }

        if (*p == '\0'){
            int length = (int)(p - h);
            if (length > max){
                max = length;
                start = h;
                end = p;
            }
        }

        ++h;
    }

    cout << str << " has the max substring is: ";
    if (max == -1)
    {
        int length = strlen(str);
        cout<< str << " ( " << length << " )" << endl;
        return length;
    }
    else{
        for (; start != end; ++start)
        {
            cout << *start;
        }
        cout << " ( " << max << " ) " << endl;
        return max;
    }
}


int main(){
    {
        int max = LengthOfLongestSubstring("abcabcbb");
    }
    {
        int max = LengthOfLongestSubstring("pwwkew");
    }
    {
        int max = LengthOfLongestSubstring("abcdefgh");
    }
    {
        int max = LengthOfLongestSubstring("bbbbbbbbbbb");
    }
    {
        int max = LengthOfLongestSubstring("aab");
    }
    return 0;
}