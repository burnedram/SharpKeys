using System;
using System.Runtime.InteropServices;

namespace SharpKeys.SDK
{
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public unsafe struct ColorMatrix
    {
        public fixed byte _buffer[Constants.SIZE_OF_COLOR_MATRIX];

        public KeyColor this[int iRow, int iCol]
        {
            get
            {
                if (iRow < 0 || iRow >= Constants.MAX_LED_ROW || iCol < 0 || iCol >= Constants.MAX_LED_COLUMN)
                    throw new IndexOutOfRangeException();
                fixed (byte *pBuf = _buffer)
                {
                    KeyColor* pMatrix = (KeyColor*)pBuf;
                    return pMatrix[iRow * Constants.MAX_LED_COLUMN + iCol];
                }
            }
            set
            {
                if (iRow < 0 || iRow >= Constants.MAX_LED_ROW || iCol < 0 || iCol >= Constants.MAX_LED_COLUMN)
                    throw new IndexOutOfRangeException();
                fixed (byte *pBuf = _buffer)
                {
                    KeyColor* pMatrix = (KeyColor*)pBuf;
                    pMatrix[iRow * Constants.MAX_LED_COLUMN + iCol] = value;
                }
            }
        }

        public void Memset(byte b)
        {
            fixed (byte *pBuf = _buffer)
            {
                Utils.Memset(pBuf, b, Constants.SIZE_OF_COLOR_MATRIX);
            }
        }
    }
}
