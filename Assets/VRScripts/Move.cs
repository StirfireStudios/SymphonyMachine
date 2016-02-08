using UnityEngine;
using System.Collections.Generic;

namespace PS4Util
{   
    public class Move
    {
        public struct ButtonState
        {
            public float backButtonLevel;
            public Dictionary<Button, bool> digitalButtons;
        }

        public enum Button { BACK = 0, MIDDLE, START, TRIANGLE, CIRCLE, CROSS, SQUARE, NONE };
        private static readonly int[] BitmaskPosition = { 2, 4, 8, 16, 32, 64, 128, 0 };

        public static ButtonState currentButtonStates(int player, int controller)
        {
            var state = new ButtonState();
            state.backButtonLevel = UnityEngine.PS4.PS4Input.MoveGetAnalogButton(player, controller);
            var bitmask = UnityEngine.PS4.PS4Input.MoveGetButtons(player, controller);
            state.digitalButtons = new Dictionary<Button, bool>();
            for (int i = 0; i < BitmaskPosition.Length; i++)
            {
                state.digitalButtons[(Button)i] = (bitmask & BitmaskPosition[i]) != 0;
            }
            return state;
        }
    }
}