#pragma once
#include "ToolsCommon.h"

namespace vega::tools {
    
    namespace packed_vertex {
        struct vertex_static
        {
            math::v3                        positions;
            u8                              reserved[3];
            u8                              t_sign; // bit 0; tangent handedness * (tangent.z sign), bit 1: normal.z sign (0 means -1, 1 means +1)
            u16                             normal[2];
            u16                             tangent[2];
            math::v2                        uv;
        };
    }

    struct vertex
    {
        math::v4                            tangent{};
        math::v3                            position{};
        math::v3                            normal{};
        math::v2                            uv{};
    };

    struct mesh
    {
        // initial data
        utl::vector<math::v3>               positions;
        utl::vector<math::v3>               normals;
        utl::vector<math::v3>               tangents;
        utl::vector<utl::vector<math::v2>>  uv_sets;

        utl::vector<u32>                    raw_indices;

        // intermediate data
        utl::vector<vertex>                 vertices;
        utl::vector<u32>                    indices;

        // output data
        std::string                         name;
        utl::vector<packed_vertex::vertex_static> packed_vertices_static;
        f32                                 lod_threshold{ -1.f };
        u32                                 lod_id{ u32_invalid_id };
    };

    struct lod_group
    {
        std::string                         name;
		utl::vector<mesh>                   meshes;//so this slot group contains a list of measures and these measures define what each level of detail of this object should look like.
    };

    struct scene
    {
        std::string                         name;
        utl::vector<lod_group>              lod_groups;//So a scene has a name and an array of lod groups, where represent and object and all the level of details in that object.
    };

    struct geometry_import_settings
    {
        u32                                 smoothing_angle;
        u8                                  calculate_normals;
        u8                                  calculate_tangents;
        u8                                  reverse_handedness;
        u8                                  import_embeded_textures;
        u8                                  import_animations;
    };
    
    struct scene_data
    {
        u8*                                 buffer;
        u32                                 buffer_size;
        geometry_import_settings            settings;
    };

    void process_scene(scene& scene, const geometry_import_settings& settings);
    void pack_data(const scene& scene, scene_data& data);
}