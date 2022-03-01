#include <iostream>
using namespace std;

// Reorder an array of integer, put all odd number at the first part of array and 
// move all even number at the second part of array
void ReorderOddEven(int* data, int n){
    if (data == nullptr || n <= 1) return;

    int i = 0;
    int j = n - 1;

    for(;i < j;){

        for(; i < j ; i++){
            if ((data[i] & 1) == 0){ // () is required, otherwise the priority of == is higher than &
                break;
            }
        }

        for(; i < j; j--){
            if ((data[j] & 1) != 0){
                break;
            }
        }

        if (i < j){
            int temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }
    }
}

void Reorder(int* data, int n, bool (*func)(int)){
    if (data == nullptr || n <= 1) return;

    int i = 0;
    int j = n - 1;
    while (i < j){
        while(i < j && !func(data[i])) i++;
        while(i < j && func(data[j])) j--;

        if (i < j){
            int temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }
    }
}

void PrintData(int* data, int n){
    cout<<"Data: ";
    for(int i = 0; i < n; i++){
        cout << data[i] << ",";
    }

    cout << endl;
}

bool ReorderByEven(int d) {
    return (d & 1) == 0;
}

bool ReorderByOdd(int d) {
    return (d & 1) != 0;
}

int main(){
    
    {
        int data[] = {2, 3, 4, 1, 6, 9, 8};
        int n = sizeof(data) /sizeof(data[0]);
        ReorderOddEven(data, n);
        PrintData(data, n);
    }

    {
        int data[] = {8,6,4};
        int n = sizeof(data) /sizeof(data[0]);
        ReorderOddEven(data, n);
        PrintData(data, n);
    }

    {
        int data[] = {2, 3, 4, 1, 6, 9, 8};
        int n = sizeof(data) /sizeof(data[0]);
        Reorder(data, n, ReorderByEven);
        PrintData(data, n);
    }

    {
        int data[] = {2, 3, 4, 1, 6, 9, 8};
        int n = sizeof(data) /sizeof(data[0]);
        Reorder(data, n, ReorderByOdd); // even at begin, odd at the end
        PrintData(data, n);
    }

    {
        int data[] = {8,6,4};
        int n = sizeof(data) /sizeof(data[0]);
        Reorder(data, n, ReorderByEven);
        PrintData(data, n);
    }
}