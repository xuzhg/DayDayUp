// copyright @Zhigang Xu  3/20/2022
// Given two binary strings a and b, return their sum as a binary string.
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <memory.h>

/* True value table
a | b | carry |=> sum | carry
0 | 0 |  0    |=> 0   |  0
0 | 0 |  1    |=> 1   |  0

0 | 1 |  0    |=> 1   |  0
0 | 1 |  1    |=> 0   |  1

1 | 0 |  0    |=> 1   |  0
1 | 0 |  1    |=> 0   |  1

1 | 1 |  0    |=> 0   |  1
1 | 1 |  1    |=> 1   |  1
*/
char getOneBitSum(char left, char right, char* carry)
{
    if (left == '0' && right == '0')
    {        
        if (*carry == '0')
        {      
            // the carry is '0', keep it     
            return '0';
        }
        else
        {
            *carry = '0'; // switch carry from '1' to '0'
            return '1';
        }
    }

    if ((left == '0' && right == '1') || 
        (left == '1' && right == '0'))
    {
        if (*carry == '0')
        { 
            // the carry is '0', keep it  
            return '1'; 
        }
        else
        {
            // the carry is '1', keep it 
            return '0';
        }        
    }

    if (left == '1' && right == '1')
    {
        if (*carry == '0')
        { 
            // switch carry to '1'
            *carry = '1';
            return '0'; 
        }
        else
        {
            // the carry is '1', keep it 
            return '1';
        }  
    }

    return '0'; 
}

char* AddBinaryString(const char* a, const char* b)
{
    if (a == NULL && b == NULL) return NULL;

    int n1 = a == NULL ? 0 : strlen(a);
    int n2 = b == NULL ? 0 : strlen(b);
    int max = n1 > n2 ? n1 : n2;
    
    // first loop to calculate the final carry
    int p = n1 - 1;
    int q = n2 - 1;
    char carry = '0';
    for (int i = max - 1; i >= 0; --i){
        // get the value from a
        char ca = '0';
        if (p >= 0){
            ca = a[p--];
        }

        // get the value from b
        char cb = '0';
        if (q >= 0){
            cb = b[q--];
        }

        getOneBitSum(ca, cb, &carry);
    }

    // we have the final carry, we can calculate the output length of the array
    int length;
    if (carry == '1'){
        length = max + 2;// 1 for the last '\0', the other one for potential carry
    }
    else
    {
        length = max + 1;
    }
    char* ret = (char *)(malloc(length)); 
    ret[length - 1] = '\0';

    p = n1 - 1;
    q = n2 - 1;
    carry = '0';
    int k = length - 2;
    for (int i = max - 1; i >= 0; --i){
        // get the value from a
        char ca = '0';
        if (p >= 0){
            ca = a[p--];
        }

        // get the value from b
        char cb = '0';
        if (q >= 0){
            cb = b[q--];
        }

        char c = getOneBitSum(ca, cb, &carry);
        ret[k--] = c;
    }
    
    if (carry == '1'){
        ret[0] = carry;
    }

    return ret; 
}



int main()
{
    {
        const char *a = "0";
        const char *b = "0";
        char* c = AddBinaryString(a, b);
        printf("%s + %s = %s\n", a, b, c);
        free(c);
    }

    {
        const char *a = "1";
        const char *b = "0";
        char* c = AddBinaryString(a, b);
        printf("%s + %s = %s\n", a, b, c);
        free(c);
    }

     {
        const char *a = "1";
        const char *b = "1";
        char* c = AddBinaryString(a, b);
        printf("%s + %s = %s\n", a, b, c);
        free(c);
    }

    {
        const char *a = "11";
        const char *b = "1";
        char* c = AddBinaryString(a, b);
        printf("%s + %s = %s\n", a, b, c);
        free(c);
    }

    {
        const char *a = "1010";
        const char *b = "1011";
        char* c = AddBinaryString(a, b);
        printf("%s + %s = %s\n", a, b, c);
        free(c);
    }

    {
        const char *a = NULL;
        const char *b = "1011";
        char* c = AddBinaryString(a, b);
        printf("%s + %s = %s\n", a, b, c);
        free(c);
    }

    {
        const char *a = "1010";
        const char *b = "10000001011";
        char* c = AddBinaryString(a, b);
        printf("%s + %s = %s\n", a, b, c);
        free(c);
    }

    return 0;
}