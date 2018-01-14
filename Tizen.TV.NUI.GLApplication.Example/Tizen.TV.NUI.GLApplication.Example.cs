using System;
using System.Runtime.InteropServices;

namespace Tizen.TV.NUI.GLApplication.Example
{
    internal class Program : TVGLApplication
    {
        private const string glDemoLib = "libgles_sample.so"; // for x86
        // private const string glDemoLib = "libgles_sample_arm.so"; // for arm

        [DllImport(glDemoLib, EntryPoint = "Create")]
        public static extern void Create();

        [DllImport(glDemoLib, EntryPoint = "Draw")]
        public static extern void Draw(IntPtr eglDisplay, IntPtr eglSurface);

        [DllImport(glDemoLib, EntryPoint = "SetTriangleColor")]
        public static extern void SetTriangleColor(float red, float green, float blue);

        private Random myRandom = new Random();

        protected override void OnCreate()
        {
            Create();
        }

        protected override void OnKeyEvent(Key key)
        {
            if (key.State == Key.StateType.Down)
            {
                switch (key.KeyPressedName)
                {
                    case "Right":
                        float r = (float)myRandom.NextDouble();
                        float g = (float)myRandom.NextDouble();
                        float b = (float)myRandom.NextDouble();
                        SetTriangleColor(r, g, b);
                        break;
                    default:
                        break;
                }
            }
        }

        protected override void OnUpdate(IntPtr eglDisplay, IntPtr eglSurface)
        {
            Draw(eglDisplay, eglSurface);
        }

        private static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Run(args);
        }
    }
}