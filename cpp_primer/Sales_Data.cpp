#include <iostream>
#include "Sales_Data.h"
using namespace std;


Sales_Data::Sales_Data(istream& is)
{
    read(is, *this);
}

double Sales_Data::avg_price() const
{
    if (units_sold)
        return revenue / units_sold;
    else
        return 0;
}

Sales_Data& Sales_Data::combine(const Sales_Data& rhs)
{
    units_sold += rhs.units_sold;
    revenue += rhs.revenue;
    return *this;
}

istream &read(istream &is, Sales_Data& item)
{
    double price = 0;
    is >> item.bookNo >> item.units_sold >> price;

    item.revenue = item.units_sold * price;
    return is;
}

ostream& print(ostream& os, const Sales_Data& item)
{
    os << item.isbn() << " " 
       << item.units_sold << " " 
       << item.revenue << " " 
       << item.avg_price();
    return os;
}

Sales_Data add(const Sales_Data& lhs, const Sales_Data& rhs)
{
    Sales_Data sum = lhs;
    sum.combine(rhs);
    return sum;
}

int main()
{
    Sales_Data data1, data2;

    double price = 0.0;
    // read first data
    // cin >> data1.bookNo >> data1.units_sold >> price;
    // data1.revenue = data1.units_sold * price;
    read(cin, data1);

    // read second data
    // cin >> data2.bookNo >> data2.units_sold >> price;
    // data2.revenue = data2.units_sold * price;
    read(cin, data2);

    //if (data1.i == data2.bookNo)
    if (data1.isbn() == data2.isbn())
    {
       // unsigned totalCnt = data1.units_sold + data2.units_sold;
        //double totalRevenue = data1.revenue + data2.revenue;
        data1.combine(data2);

        //cout << data1.bookNo << " " << totalCnt << " " << totalRevenue << " ";
        //if (totalCnt != 0){
        //    cout << totalRevenue / totalCnt << endl;
        //}
        //else{
        //    cout << "(no sales)" << endl;
       // }
       print(cout, data1);

        return 0;
    }
    else{
        cerr << "Data must refer to the same ISBN" << endl;
        return 0;
    }
}