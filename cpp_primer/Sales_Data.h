#ifndef SALES_DATA_H
#define SALES_DATA_H
#pragma once

#include <string>

class Sales_Data
{
    friend Sales_Data add(const Sales_Data&, const Sales_Data&);
    friend std::ostream& print(std::ostream&, const Sales_Data&);
    friend std::istream& read(std::istream&, Sales_Data&);

public:
    Sales_Data() = default;
    Sales_Data(const std::string &s) : bookNo(s) {}
    Sales_Data(const std::string &s, unsigned n, double p):
        bookNo(s), units_sold(n), revenue(p*n) {}
    Sales_Data(std::istream& );

    std::string isbn() const { return bookNo; }
    Sales_Data& combine(const Sales_Data&);
    double avg_price() const;

private:
    std::string bookNo;
    unsigned units_sold = 0;
    double revenue = 0.0;
};

Sales_Data add(const Sales_Data&, const Sales_Data&);
std::ostream& print(std::ostream&, const Sales_Data&);
std::istream& read(std::istream&, Sales_Data&);

#endif