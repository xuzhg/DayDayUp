// copyright @Zhigang Xu  3/17/2022
// 4- Median of two sorted arrays
// Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
// The overall run time complexity should be O(log (m+n)).

#include <iostream>
#include <vector>
using namespace std;

double getMedian(vector<int>& nums, int a, int b){
    int n = b - a;
    if (n & 0x1 == 0) // even
    {
        return (nums[n/2 - 1] + nums[n/2]) / 2.0;
    }
    else{
        return nums[n/2];
    }
}

double findMedianSortedArrays(vector<int>& nums1, int a1, int b1, vector<int>& nums2, int a2, int b2)
{
    int n1 = b1 - a1;
    if (n1 == 0) {
        return getMedian(nums2, a2, b2);
    }

    int n2 = b2 - a2;
    if (n2 == 0) {
        return getMedian(nums1, a1, b1);
    }

    if (n1 == n2 && n1 == 1)

    int m1 = (int)getMedian(nums1, a1, b1); // why can we use int?
    int m2 = (int)getMedian(nums2, a2, b2);

    if (m1 == m2)
    {
        return m1;
    }

    int d1 = (b1 - a1) / 2;
    int d2 = (b2 - a2) / 2;
    int min = (d1 > d2) ? d2 : d1;

    if (m1 < m2) {
        return findMedianSortedArrays(nums1, a1 + min, b1, nums2, a2, b2 - min);
    }
    else
    {
        return findMedianSortedArrays(nums1, a1, b1 - min, nums2, a2 + min, b2);
    }
}

double findMedianSortedArrays(vector<int>& nums1, vector<int>& nums2) {

    int num1 = nums1.size();
    int num2 = nums2.size();
    int num = num1 + num2;

    if (num <= 0)
    {
        return 0.0;
    }

   return findMedianSortedArrays(nums1, 0, num1, nums2, 0, num2);
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