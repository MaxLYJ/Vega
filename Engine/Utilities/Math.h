#pragma once
#include "CommonHeaders.h"
#include "MathTypes.h"

namespace vega::math {
    template<typename T>
    constexpr T clamp(T value, T min, T max)
    {
        return (value < min) ? min : (value > max) ? max : value;
    }
}