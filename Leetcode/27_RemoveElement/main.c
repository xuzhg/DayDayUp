// copyright @Zhigang Xu  3/19/2022
// Given an integer array nums and an integer val,
// remove all occurrences of val in nums in-place.
// The relative order of the elements may be changed.
/*
Since it is impossible to change the length of the array in some languages, you must instead have the result be placed in the first part of the array nums. More formally, if there are k elements after removing the duplicates, then the first k elements of nums should hold the final result. It does not matter what you leave beyond the first k elements.

Return k after placing the final result in the first k slots of nums.

Do not allocate extra space for another array. You must do this by modifying the input array in-place with O(1) extra memory.
*/
#include <stdio.h>

int removeElement(int* p, int n, int val)
{
    if (p == NULL || n <= 0)
        return 0;

    int i = 0; 
    int j = n - 1; // the last valid position

    while (i <= j)
    {
        if (p[i] == val){
            p[i] = p[j];
            --j;
        }
        else
        {
            ++i;
        }
    }

    return j + 1;
}

void Print(int* p, int n){
    printf("Array: [");
    for(int i = 0 ; i < n; ++i){
        printf("%d", p[i]);

        if (i + 1 != n){
            printf(", ");
        }
    }

    printf("]");
}

void test(int* data, int n, int val){
     Print(data, n);
     int m = removeElement(data, n , val);
     printf(" << Deleted %d >> ", n - m);
     Print(data, m);
     printf("\n");
}

int main()
{
    {
        int data[0];
        test(data, 1, 3);
    }

    {
        int data[] = { 3};
        test(data, 1, 3);
    }
    {
        int data[] = { 3,2,2,3};
        test(data, 4, 3);
    }
    {
        int data[] = { 0,1,2,2,3,0,4,2};
        test(data, 8, 2);
    }
    return 0;
}