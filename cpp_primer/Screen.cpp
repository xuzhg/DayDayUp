#include <iostream>
#include "Screen.h"

inline Screen& Screen::move(pos r, pos c)
{
    pos row = r * width + c;
    cursor = row + c;
    return *this;
}

char Screen::get(pos r, pos c) const
{
    pos row = r * width ;
    return contents[row + c];
}

Screen& Screen::set(char c)
{
    contents[cursor] = c;
    return *this;
}

Screen& Screen::set(pos r, pos c, char ch)
{
    contents[r*width + c] = ch;
    return *this;
}
