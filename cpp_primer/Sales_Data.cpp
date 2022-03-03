#include <iostream>
#include "Sales_Data.h"
using namespace std;

int main()
{
    Sales_Data data1, data2;

    double price = 0.0;
    // read first data
    cin >> data1.boolNo >> data1.units_sold >> price;
    data1.revenue = data1.units_sold * price;

    // read second data
    cin >> data2.boolNo >> data2.units_sold >> price;
    data2.revenue = data2.units_sold * price;

    if (data1.boolNo == data2.boolNo)
    {
        unsigned totalCnt = data1.units_sold + data2.units_sold;
        double totalRevenue = data1.revenue + data2.revenue;

        cout << data1.boolNo << " " << totalCnt << " " << totalRevenue << " ";
        if (totalCnt != 0){
            cout << totalRevenue / totalCnt << endl;
        }
        else{
            cout << "(no sales)" << endl;
        }

        return 0;
    }
    else{
        cerr << "Data must refer to the same ISBN" << endl;
        return 0;
    }
}