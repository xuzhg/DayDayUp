// copyright @Sam Xu  3/15/2022
// Given a string, find the lenght of the longest substring without repeating characters.

#include <iostream>
#include <string>
using namespace std;

int LengthOfLongestSubstring(string str)
{
    int length = str.length(); // total length
    int max = -1;
    int max_start;
    int max_end;
    int start = 0;
    
    for (; start < length; ++start)
    {
        int move = start + 1;
        for (; move < length; ++move)
        {
            int index = start;
            for (; index != move; ++index){
                if (str[move] == str[index]){ 
                    break; // found a repeat
                }
            }

            if (index != move) // found repeat
            {
                int length = (int)(move - start);
                if (length > max){
                    max = length;
                    max_start = start;
                    max_end = move; // end is the next of the last character
                }

                // key point here: we iterate from the repeated position
                // then we will move backward using (++h) to start from the next position
                // of the first repeat character.
                start = index;
                break;
            }
        }

        if (move == length) {
            int length = (int)(move - start);
            if (length > max){
                max = length;
                max_start = start;
                max_end = move; // end is the next of the last character
            }
        }
    }

    cout << str << " has the max substring is: ";
    if (max == -1)
    {
        cout<< str << " ( " << length << " )" << endl;
        return length;
    }
    else{
        string sub = str.substr(max_start, max);
        cout << sub << " ( " << max << " ) " << endl;
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