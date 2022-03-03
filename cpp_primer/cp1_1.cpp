#include <iostream>
using namespace std;


void Cp_1()
{
    cout << "*******cp1-1*************************"<<endl;
    cout << "Enter two numbers:" << endl;
    int v1 = 0, v2 = 0;
    cin >> v1 >> v2;
    cout << "The sum of " << v1 << " and " << v2 << " is " << v1 + v2 << endl;
}

void Cp_2()
{
    cout << "*******cp1-2*************************"<<endl;
    int sum = 0, val = 1;

    while (val <= 10){
        sum += val;
        ++val;
    }

    cout << "Sum of 1 to 10 inclusive is " << sum << endl;
}

void Cp_3()
{
    cout << "******cp1-3**************************"<<endl;

    int sum = 0;
    for (int val = 1; val <=10; ++val){
        sum += val;
    }
    cout << "Sum of 1 to 10 inclusive is " << sum << endl;
}

int main()
{
    Cp_1();
    Cp_2();
    Cp_3();
    return 0;
}