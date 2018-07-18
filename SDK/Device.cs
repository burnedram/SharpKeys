namespace SharpKeys.SDK
{
    public class Device
    {
        public DeviceIndex DeviceIndex { get; }

        public Device(DeviceIndex deviceIndex)
        {
            this.DeviceIndex = deviceIndex;
        }

        public bool IsDevicePlug()
        {
            return DLL.IsDevicePlug(DeviceIndex);
        }

        public LayoutKeyboard GetDeviceLayout()
        {
            return DLL.GetDeviceLayout(DeviceIndex);
        }

        public bool EnableLedControl(bool bEnable)
        {
            return DLL.EnableLedControl(bEnable, DeviceIndex);
        }

        public bool RefreshLed(bool bAuto = false)
        {
            return DLL.RefreshLed(bAuto, DeviceIndex);
        }
        
        public bool SetFullLedColor(KeyColor keyColor)
        {
            return DLL.SetFullLedColor(keyColor.r, keyColor.g, keyColor.b, DeviceIndex);
        }

        public bool SetFullLedColor(byte r, byte g, byte b)
        {
            return DLL.SetFullLedColor(r, g, b, DeviceIndex);
        }

        public bool SetAllLedColor(ColorMatrix colorMatrix)
        {
            return DLL.SetAllLedColor(colorMatrix, DeviceIndex);
        }
        
        public bool SetLedColor(int iRow, int iColumn, KeyColor keyColor)
        {
            return DLL.SetLedColor(iRow, iColumn, keyColor.r, keyColor.g, keyColor.b, DeviceIndex);
        }

        public bool SetLedColor(int iRow, int iColumn, byte r, byte g, byte b)
        {
            return DLL.SetLedColor(iRow, iColumn, r, g, b, DeviceIndex);
        }

        public bool EnableKeyInterrupt(bool bEnable)
        {
            return DLL.EnableKeyInterrupt(bEnable, DeviceIndex);
        }

        public void SetKeyCallBack(KeyCallback callback)
        {
            DLL.SetKeyCallBack(callback, DeviceIndex);
        }
    }
}
