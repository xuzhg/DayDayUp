#pragma once
#include <string>

class Screen {

    friend void Window_mgr::clear(ScreenIndex);
public:

    typedef std::string::size_type pos;
    Screen() = default;

    Screen(pos ht, pos wd, char c) : height(ht), width(wd), contents(ht*wd, c) {}

    char get() const { return contents[cursor];}
    inline char get(pos ht, pos wd) const;
    Screen &move(pos r, pos c);

    Screen& set(char);
    Screen& set(pos, pos, char);

    Screen& display(std::ostream& os) { do_display(os); return *this; }
    const Screen& display(std::ostream& os) const { do_display(os); return *this;}

private:
    pos cursor = 0;
    pos height = 0, width = 0;
    std::string contents;

    void do_display(const std::ostream& os) const
    { os << contents; }
};
