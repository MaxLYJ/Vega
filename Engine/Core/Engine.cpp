#if !defined(SHIPPING)
#include "..\Content\ContentLoader.h"
#include "..\Components\Script.h"
#include <thread>

bool engine_initialize()
{
    bool result{ vega::content::load_game() };
    return true;
}

void engine_update()
{
    vega::script::update(10.f);
    std::this_thread::sleep_for(std::chrono::milliseconds(10));
}

void engine_shutdown()
{
    vega::content::unload_game();
}
#endif // !defined(SHIPPING)