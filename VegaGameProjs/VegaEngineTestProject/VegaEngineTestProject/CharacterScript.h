#pragma once

namespace vega_test_project
{
    REGISTER_SCRIPT(character_script)

    class character_script : public vega::script::entity_script
    {
    public:
        constexpr explicit character_script(vega::game_entity::entity entity)
            : vega::script::entity_script(entity) {}

        void update(float dt) override;
    };

}


