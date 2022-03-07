#include <string>
#include <iostream>
#include <cctype>
#include <vector>
using namespace std;

void Cp3_1()
{
    string s("Hello world!!!");

    decltype(s.size()) punct_cnt = 0;
    for (auto c : s)
    {
        if (ispunct(c))
            ++punct_cnt;
    }

    cout <<punct_cnt
        << " punctuation characters in " << s << endl;
}

void Cp3_2()
{
    vector<string> svec(10, "abc");
    vector<string> svec2(svec);

    svec.cbegin();
    svec.cend(); // const iterator

    for (vector<string>::iterator it = svec.begin();
        it != svec.end(); ++it)
        {
            cout<<*it<<", ";
        }

    cout << endl;
}

bool Cp3_3(vector<int> data, int sought)
{
    // Binary search
    vector<int>::iterator begin = data.begin();
    vector<int>::iterator end = data.end();

    auto mid = begin + (end - begin) / 2; // middle

    while(mid != end){
        if (*mid == sought)
        {
            return true;
        }

        if(sought < *mid){
            end = mid;
        }
        else
        {
            begin = mid + 1; // move to the next of mid
        }

        mid = begin +  (end -begin) /2;
    }

    return false;
}

int main(){

    Cp3_1();
    Cp3_2();

    vector<int> ivec {1, 2, 3, 4, 5, 6, 7, 8, 9};
    cout << "vector has 3? " << (Cp3_3(ivec, 3) ? "yes" : "no") << endl;
    cout << "vector has 11? " << (Cp3_3(ivec, 11) ? "yes" : "no") << endl;


    return 0;
}