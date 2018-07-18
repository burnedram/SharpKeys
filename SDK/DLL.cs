using System;
using System.Runtime.InteropServices;

namespace SharpKeys.SDK
{
    public class DLL
    {
        [DllImport("SDKDLL.dll", EntryPoint = "GetCM_SDK_DllVer", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetVersion();

        #region System data related function

        [DllImport("SDKDLL.dll", EntryPoint = "GetNowTime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr _GetNowTime();
        public static string GetNowTime()
        {
            return Marshal.PtrToStringUni(_GetNowTime());
        }

        #endregion

        #region Device operation function

        [DllImport("SDKDLL.dll", EntryPoint = "SetControlDevice", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetControlDevice(DeviceIndex devIndex);

        [DllImport("SDKDLL.dll", EntryPoint = "IsDevicePlug", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool IsDevicePlug(DeviceIndex devIndex = DeviceIndex.DEV_DEFAULT);

        [DllImport("SDKDLL.dll", EntryPoint = "GetDeviceLayout", CallingConvention = CallingConvention.Cdecl)]
        internal static extern LayoutKeyboard GetDeviceLayout(DeviceIndex devIndex = DeviceIndex.DEV_DEFAULT);

        [DllImport("SDKDLL.dll", EntryPoint = "EnableLedControl", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool EnableLedControl([MarshalAs(UnmanagedType.I1)] bool bEnable, DeviceIndex devIndex = DeviceIndex.DEV_DEFAULT);

        [DllImport("SDKDLL.dll", EntryPoint = "RefreshLed", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool RefreshLed([MarshalAs(UnmanagedType.I1)]bool bAuto = false, DeviceIndex devIndex = DeviceIndex.DEV_DEFAULT);

        [DllImport("SDKDLL.dll", EntryPoint = "SetFullLedColor", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool SetFullLedColor(byte r, byte g, byte b, DeviceIndex devIndex = DeviceIndex.DEV_DEFAULT);

        [DllImport("SDKDLL.dll", EntryPoint = "SetAllLedColor", CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool SetAllLedColor(ColorMatrix colorMatrix, DeviceIndex devIndex = DeviceIndex.DEV_DEFAULT);
        
        [DllImport("SDKDLL.dll", EntryPoint = "SetLedColor", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool SetLedColor(int iRow, int iColumn, byte r, byte g, byte b, DeviceIndex devIndex = DeviceIndex.DEV_DEFAULT);

        [DllImport("SDKDLL.dll", EntryPoint = "EnableKeyInterrupt", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool EnableKeyInterrupt(bool bEnable, DeviceIndex devIndex = DeviceIndex.DEV_DEFAULT);

        [DllImport("SDKDLL.dll", EntryPoint = "SetKeyCallBack", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void SetKeyCallBack(KeyCallback callback, DeviceIndex devINdex = DeviceIndex.DEV_DEFAULT);

        #endregion
    }
}
