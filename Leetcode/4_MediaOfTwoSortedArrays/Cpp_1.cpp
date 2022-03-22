// copyright @Zhigang Xu  3/17/2022
// 4- Median of two sorted arrays
// Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
// The overall run time complexity should be O(log (m+n)).

#include <iostream>
#include <vector>
using namespace std;

double findMedianSortedArrays(vector<int>& nums1, vector<int>& nums2) {
    int num1 = nums1.size();
    int num2 = nums2.size();
    int num = num1 + num2;

    if (num <= 0)
    {
        return 0.0;
    }

    vector<int>::const_iterator it1 = nums1.begin();
    vector<int>::const_iterator it2 = nums2.begin();

    bool even = (num & 0x1) == 0;
    int threshold = num / 2;
    if (!even)
    {
        ++threshold;
    }

    int index = 0;
    double ret = 0.0;
    while (index < threshold) 
    {
       ++index;

        if (it1 == nums1.end()) {
            int diff = threshold - index;
            ret = *(it2 + diff);
            it2 += (diff + 1);
            break;
        }
        else if (it2 == nums2.end()) {
            int diff = threshold - index;
            ret = *(it1 + diff);
            it1 += (diff + 1);
            break;
        }
        else
        {
            if (*it1 < *it2){
                if (index == threshold)
                {
                    ret = *it1;
                }
                ++it1;
            }
            else {
                if (index == threshold)
                {
                    ret = *it2;
                }
                ++it2;
            }
        }
    }

    if((num & 0x1) == 0) // even
    {
        int next;
        if (it1 == nums1.end()){
            next = *it2;
        }
        else if (it2 == nums2.end()){
            next = *it1;
        }
        else
        {
            if (*it1 < *it2){
                next = *it1;
            }
            else
            {
                next = *it2;
            }
        }

        return (ret + next)/2.0;
    }
    else{
        return ret;
    }

}

void Print(vector<int>& nums1)
{
    cout << "[";
    for (int i = 0 ; i < nums1.size() ; i++)
    {
        cout << nums1[i];
        if (i != nums1.size() - 1){
            cout <<", ";
        }
    }
    cout << "]";
}

void FindMediaAndPrint(vector<int>& nums1, vector<int>& nums2)
{
    cout << "The media of ";
    Print(nums1);
    cout <<" and ";
    Print(nums2);
    cout <<" is < " << findMedianSortedArrays(nums1, nums2) << " > " << endl;
}


int main(){

    vector<int> nums1 = {};
    vector<int> nums2 = {};
    FindMediaAndPrint(nums1, nums2);

    nums1 = {1};
    nums2 = {};
    FindMediaAndPrint(nums1, nums2);

    nums1 = {1};
    nums2 = {3};
    FindMediaAndPrint(nums1, nums2);

    nums1 = {1, 4, 5, 7};
    nums2 = {2, 3, 6, 8};
    FindMediaAndPrint(nums1, nums2);
    
   
    nums1 = {};
    nums2 = {1,2,3,4,5};
    FindMediaAndPrint(nums1, nums2);

    nums1 = {1,2,3,4,5,6};
    nums2 = {};
    FindMediaAndPrint(nums1, nums2);

    nums1 = {1, 3};
    nums2 = {2};
    FindMediaAndPrint(nums1, nums2);

    nums1 = {1, 3, 4, 5, 6, 7, 8};
    nums2 = {2};
    FindMediaAndPrint(nums1, nums2);

    nums1 = {1, 3, 4, 5, 6, 7, 8, 9};
    nums2 = {2};
    FindMediaAndPrint(nums1, nums2);
    
    return 0;
}