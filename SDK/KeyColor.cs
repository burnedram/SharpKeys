using System.Runtime.InteropServices;

namespace SharpKeys.SDK
{
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public struct KeyColor
    {
        public byte r, g, b;

        public KeyColor(byte r, byte g, byte b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public override string ToString()
        {
            return $"[{r}, {g}, {b}]";
        }
    }
}
