#pragma once
#include "ComponentsCommon.h"

namespace vega::script {

    struct init_info
    {
        detail::script_creator script_creator;
    };

    component create(init_info info, game_entity::entity entityHandle);
    void remove(component componentHandle);
    void update(float dt);
}