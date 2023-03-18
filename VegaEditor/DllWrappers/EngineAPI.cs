using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using VegaEditor.Components;
using VegaEditor.EngineAPIStructs;
using VegaEditor.GameProject;
using VegaEditor.Utilities;

namespace VegaEditor.EngineAPIStructs
{
    [StructLayout(LayoutKind.Sequential)]
    class TransformComponent
    {
        public Vector3 Position;
        public Vector3 Rotation;
        public Vector3 Scale = new Vector3(1, 1, 1);
    }

    [StructLayout(LayoutKind.Sequential)]
    class ScriptComponent
    {
        public IntPtr ScriptCreator;
    }

    [StructLayout(LayoutKind.Sequential)]
    class GameEntityDescriptor
    {
        public TransformComponent Transform = new TransformComponent();
        public ScriptComponent Script = new ScriptComponent();
    }
}

namespace VegaEditor.DllWrappers
{
    static class EngineAPI
    {
        private const string _engineDll = "EngineDll.dll";
        [DllImport(_engineDll, CharSet = CharSet.Ansi)]
        public static extern int LoadGameCodeDll(string dllPath);
        [DllImport(_engineDll)]
        public static extern int UnloadGameCodeDll();
        [DllImport(_engineDll)]
        public static extern IntPtr GetScriptCreator(string name);
        [DllImport(_engineDll)]
        [return: MarshalAs(UnmanagedType.SafeArray)]
        public static extern string[] GetScriptNames();
        [DllImport(_engineDll)]
        public static extern int CreateRenderSurface(IntPtr host, int width, int height);
        [DllImport(_engineDll)]
        public static extern void RemoveRenderSurface(int surfaceId);
        [DllImport(_engineDll)]
        public static extern IntPtr GetWindowHandle(int surfaceId);

        internal static class EntityAPI
        {
            [DllImport(_engineDll)]
            private static extern int CreateGameEntity(GameEntityDescriptor desc);
            public static int CreateGameEntity(GameEntity entity)
            {
                GameEntityDescriptor desc = new GameEntityDescriptor();

                // transform
                {
                    var c = entity.GetComponent<Transform>();
                    desc.Transform.Position = c.Position;
                    desc.Transform.Rotation = c.Rotation;
                    desc.Transform.Scale = c.Scale;
                }
                // script
                {
                    var c = entity.GetComponent<Script>();
                    // Note here we also need to check if the current project is not null.
                    // In this case, that means the game code dll has not been loaded yet
                    // And then we deffer the creation of script entity, until the DLL is properly loaded
                    if(c != null && Project.Current != null)
                    {
                        if(Project.Current.AvailableScripts.Contains(c.Name))
                        {
                            desc.Script.ScriptCreator = GetScriptCreator(c.Name);
                        }
                        else
                        {
                            Logger.Log(MessageType.Error, $"Unable to find script with name {c.Name}. Game entity will be created without script component!");
                        }
                    }
                }
                return CreateGameEntity(desc);
            }

            [DllImport(_engineDll)]
            private static extern void RemoveGameEntity(int id);
            public static void RemoveGameEntity(GameEntity entity)
            {
                RemoveGameEntity(entity.EntityId);
            }
        }



    }
}
