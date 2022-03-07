// copyright @Sam Xu  3/3/2022
// Print a matrix on clockwise direction
#include <iostream>
using namespace std;


void PrintMatrixClockwise(int* data, int row, int col)
{
    if (data == nullptr || row <= 0 || col <= 0) return;

    // define every iterator's "min-row, max-row, min-column, max-column"
    int min_r = 0, max_r = row - 1;
    int min_c = 0, max_c = col - 1;

    while(min_r <= max_r && min_c <= max_c) {

        for (int j = min_c; j < max_c; ++j){
            cout << *(data + min_r * col + j) << ", ";
        }
        for (int i = min_r; i < max_r; ++i){
            cout << *(data + i * col + max_c) << ", ";
        }

        
            for (int j = max_c ; j > min_c; --j){
                cout << *(data + max_r * col + j) << ", ";
            }

        
            for (int i = max_r; i > min_r; --i){
                cout << *(data + i * col + min_c) << ", ";
            }

        ++min_r;
        --max_r;
        ++min_c;
        --max_c;
    }

    cout << endl;
}

void PrintMatrix(int* data, int row, int col)
{
    cout <<"\nMatrix ("<< row <<" x " << col << "):\n";

    for (int i =0; i < row; ++i)
    {
        for(int j = 0; j < col; ++j)
        {
            int index = i * col + j;
            cout << *(data + index) << "\t";
        }
        cout << "\n";
    }
    cout << endl;
}

int main(){
    {
        int data[][4] = { 
            {1,  2,  3,  4},
            {5,  6,  7,  8},
            {9, 10, 11, 12},
            {13,14, 15, 16}
        };
        
        PrintMatrix((int*)data, 4, 4);
        PrintMatrixClockwise((int*)data, 4, 4);
    }

    {
        int data[][5] = { 
            {1,  2,  3,  4,  20},
            {5,  6,  7,  8,  21},
            {9, 10, 11, 12, 22},
            {13,14, 15, 16, 23}
        };
        
        PrintMatrix((int*)data, 4, 5);
        PrintMatrixClockwise((int*)data, 4, 5);
    }

    {
        int data[][3] = { 
            {1,  2,  3 },
            {5,  6,  7 },
            {9,  10, 11 },
            {13, 14, 15 },
            {16, 17, 18 }
        };
        
        PrintMatrix((int*)data, 5, 3);
        PrintMatrixClockwise((int*)data, 5, 3);
    }

    {
        int data[][4] = { 
            {1,  2,  3, 4 },
            {5,  6,  7, 8 },
            {9,  10, 11, 12 },
          
        };
        
        PrintMatrix((int*)data, 3, 4);
        PrintMatrixClockwise((int*)data, 3, 4);
    }

        {
        int data[][11] = { 
            {1,  2,  3,  4,   5,  6,   7,   8,   9,   10, 11 },
            {15,  16,  17,  18,   19,   20,   21,  22,   23,  24, 25 },
            {31,  32, 33, 34,  35,  36,  37,  38,  39,  40, 41 },
          
        };
        
        PrintMatrix((int*)data, 3, 11);
        PrintMatrixClockwise((int*)data, 3, 11);
    }
    return 0;
}