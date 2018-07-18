using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace SharpKeys
{
    public static class Utils
    {
        private static Action<IntPtr, byte, int> MemsetDelegate { get; }

        static Utils()
        {
            var dynamicMethod = new DynamicMethod("Memset", MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard,
                null, new[] { typeof(IntPtr), typeof(byte), typeof(int) }, typeof(Utils), true);

            var generator = dynamicMethod.GetILGenerator();
            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Ldarg_1);
            generator.Emit(OpCodes.Ldarg_2);
            generator.Emit(OpCodes.Initblk);
            generator.Emit(OpCodes.Ret);

            MemsetDelegate = (Action<IntPtr, byte, int>)dynamicMethod.CreateDelegate(typeof(Action<IntPtr, byte, int>));
        }

        public static void Memset<T>(T[] array, byte what)
        {
            var gcHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
            Memset(gcHandle.AddrOfPinnedObject(), what, Marshal.SizeOf<T>() * array.Length);
            gcHandle.Free();
        }

        public static void Memset(byte[] array, byte what, int length)
        {
            var gcHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
            Memset(gcHandle.AddrOfPinnedObject(), what, length);
            gcHandle.Free();
        }

        public static void Memset(IntPtr pBuf, byte what, int length)
        {
            MemsetDelegate(pBuf, what, length);
        }

        public static unsafe void Memset(void * pBuf, byte what, int length)
        {
            MemsetDelegate(new IntPtr(pBuf), what, length);
        }

        public static void ForMemset(byte[] array, byte what, int length)
        {
            for (var i = 0; i < length; i++)
            {
                array[i] = what;
            }
        }

    }
}
