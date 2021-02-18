using Microsoft.Xna.Framework.Input;
using OpenKh.Engine.Input;
using System.Numerics;

namespace OpenKh.Game.Infrastructure
{
    public class InputKeyboard : IInputDevice
    {
        private static readonly Keys[] ButtonBindings = new Keys[]
        {
            Keys.Up,
            Keys.Down,
            Keys.Left,
            Keys.Right,
            Keys.L,             // Cross
            Keys.K,             // Circle
            Keys.O,             // Square
            Keys.P,             // Triangle
            Keys.Space,         // Select
            Keys.Enter,         // Start
            Keys.U,             // L1
            Keys.LeftShift,     // L2
            Keys.D8,            // L3
            Keys.I,             // R1
            Keys.Tab,           // R2
            Keys.D9,            // R3

        };
        private static readonly Keys[] AnalogBindings = new Keys[]
        {
            // Left
            Keys.W,
            Keys.S,
            Keys.A,
            Keys.D,
            
            // Right
            Keys.Up,
            Keys.Down,
            Keys.Left,
            Keys.Right,
        };

        public Vector3 AnalogLeft { get; private set; }
        public Vector3 AnalogRight { get; private set; }
        public bool Up { get; private set; }
        public bool Down { get; private set; }
        public bool Left { get; private set; }
        public bool Right { get; private set; }
        public bool Cross { get; private set; }
        public bool Circle { get; private set; }
        public bool Square { get; private set; }
        public bool Triangle { get; private set; }
        public bool Select { get; private set; }
        public bool Start { get; private set; }
        public bool L1 { get; private set; }
        public bool L2 { get; private set; }
        public bool L3 { get; private set; }
        public bool R1 { get; private set; }
        public bool R2 { get; private set; }
        public bool R3 { get; private set; }
        public bool Confirm => false;
        public bool Cancel => false;

        public void Update()
        {
            var state = Keyboard.GetState();
            Up = state.IsKeyDown(ButtonBindings[0]);
            Down = state.IsKeyDown(ButtonBindings[1]);
            Left = state.IsKeyDown(ButtonBindings[2]);
            Right = state.IsKeyDown(ButtonBindings[3]);
            Cross = state.IsKeyDown(ButtonBindings[4]);
            Circle = state.IsKeyDown(ButtonBindings[5]);
            Square = state.IsKeyDown(ButtonBindings[6]);
            Triangle = state.IsKeyDown(ButtonBindings[7]);
            Select = state.IsKeyDown(ButtonBindings[8]);
            Start = state.IsKeyDown(ButtonBindings[9]);
            L1 = state.IsKeyDown(ButtonBindings[10]);
            L2 = state.IsKeyDown(ButtonBindings[11]);
            L3 = state.IsKeyDown(ButtonBindings[12]);
            R1 = state.IsKeyDown(ButtonBindings[13]);
            R2 = state.IsKeyDown(ButtonBindings[14]);
            R3 = state.IsKeyDown(ButtonBindings[15]);

            float lx = 0f, ly = 0f, lz;
            float rx = 0f, ry = 0f, rz;
            if (state.IsKeyDown(AnalogBindings[0]))
                ly += 1;
            if (state.IsKeyDown(AnalogBindings[1]))
                ly -= 1;
            if (state.IsKeyDown(AnalogBindings[2]))
                lx += 1;
            if (state.IsKeyDown(AnalogBindings[3]))
                lx -= 1;
            lz = L2 ? 1f : 0f;
            if (state.IsKeyDown(AnalogBindings[4]))
                ry += 1;
            if (state.IsKeyDown(AnalogBindings[5]))
                ry -= 1;
            if (state.IsKeyDown(AnalogBindings[6]))
                rx += 1;
            if (state.IsKeyDown(AnalogBindings[7]))
                rx -= 1;
            rz = R2 ? 1f : 0f;

            AnalogLeft = new Vector3(lx, ly, lz);
            AnalogRight = new Vector3(rx, ry, rz);
        }
    }
}
