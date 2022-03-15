#pragma once
#include <vector>
#include "Screen.h"

class Window_mgr
{
    friend class Screen;
public:
    using ScreenIndex = std::vector<Screen>::size_type;

    void clear(ScreenIndex);

private:
    std::vector<Screen> screens { Screen(24, 90, ' ')};
};