using System.Runtime.InteropServices;

namespace SharpKeys.SDK
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void KeyCallback(int iRow, int iColumn, bool bPressed);
}
