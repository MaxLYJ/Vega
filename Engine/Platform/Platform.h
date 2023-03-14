#pragma once
#include "CommonHeaders.h"
#include "Window.h"

namespace vega::platform {

    struct window_init_info;

    window create_window(const window_init_info* const init_info = nullptr);
    void remove_window(window_id id);

    void set_fullscreen(bool is_fullscreen) const;
    bool is_fullscreen() const;
    void* handle() const;
    void set_caption(const wchar_t* caption) const;
    const math::u32v4 size() const;
    void resize(u32 width, u32 height) const;
    const u32 width() const;
    const u32 height() const;
    bool is_closed() const;
}