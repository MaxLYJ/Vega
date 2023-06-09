#pragma once
#include "ToolsCommon.h"

namespace vega::tools {
    enum primitive_mesh_type : u32
    {
        plane,
        cube,
        uv_sphere,
        ico_sphere,
        cylinder,
        capsule,

        count
    };

    struct primitive_init_info
    {
        primitive_mesh_type type;//What kind of mesh primitive 
        u32                 segments[3]{ 1,1,1 };//How they will be subdivided. For instance we need to plane, two of the components will be use because a plane is two dimensional obviously. Two of elements will be interpreted as segmentation in x and y direction. Where as for a cube, three of these components will be interpreted as segments along x, y and z diestions. For ecoshpere we only use one because that's just the number of subdivision.
        math::v3            size{ 1,1,1 };//Side is the initial size of the mesh that we generated.
        u32                 lod{ 0 };
    };
}