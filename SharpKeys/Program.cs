using System;
using System.Threading;
using SharpKeys.SDK;

namespace SharpKeys
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"[{DLL.GetNowTime()}] SDK version: {DLL.GetVersion()}");
            Console.WriteLine();

            Device dev = new Device(DeviceIndex.DEV_MKeys_S);
            ColorMatrix matrix = new ColorMatrix();
            Color startColor = new Color().Hsv(0, 1, 1);
            UpdateColor(ref matrix, startColor);

            Console.WriteLine("IsDevicePlug: " + dev.IsDevicePlug());
            Console.WriteLine("GetDeviceLayout: " + Enum.GetName(typeof(LayoutKeyboard), dev.GetDeviceLayout()));
            Console.WriteLine();

            Console.WriteLine("EnableLedControl: " + dev.EnableLedControl(true));
            Console.WriteLine("SetAllLedColor: " + dev.SetAllLedColor(matrix));
            Console.WriteLine("RefreshLed: " + dev.RefreshLed(true));
            dev.SetKeyCallBack((iRow, iCol, bPressed) =>
            {
                Console.WriteLine(iRow + ", " + iCol + ", " + bPressed);
                startColor.H += 0.025f;
                UpdateColor(ref matrix, startColor);
                dev.SetAllLedColor(matrix);
            });
            Console.WriteLine("EnableKeyInterrupt: " + dev.EnableKeyInterrupt(true));
            Console.WriteLine();

            Thread.Sleep(Timeout.Infinite);
        }

        public static void UpdateColor(ref ColorMatrix matrix, Color startColor)
        {
            Color color = startColor.Clone();
            for (int iRow = 0; iRow < Constants.MAX_LED_ROW; iRow++)
            {
                for (int iCol = 0; iCol < Constants.MAX_LED_COLUMN; iCol++)
                {
                    matrix[iRow, iCol] = color;
                    color.H += 0.025f;
                }
            }
        }
    }
}
