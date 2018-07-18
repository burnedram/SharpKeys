using System;
using System.Runtime.InteropServices;

namespace SharpKeys.SDK
{
    public class Constants
    {
        public const int MAX_LED_ROW = 7;
        public const int MAX_LED_COLUMN = 24;
        public const int SIZE_OF_KEY_COLOR = 3;
        public const int SIZE_OF_COLOR_MATRIX = MAX_LED_ROW * MAX_LED_COLUMN * SIZE_OF_KEY_COLOR;

        static Constants() {
            if (SIZE_OF_KEY_COLOR != Marshal.SizeOf<KeyColor>())
                throw new Exception($"Size of KEY_COLOR is {Marshal.SizeOf<KeyColor>()}, expected {SIZE_OF_KEY_COLOR}");
        }
    }
}
