using System;
using System.Runtime.InteropServices;


namespace jsmhToolChest.Libraries.ProcessPatch
{
    internal class DLLTool
    {
        [DllImport("kernel32.dll")]
        public static extern int OpenProcess(int a_, int Handle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(int hObject);
        [DllImport("ntdll.dll")]
        public static extern bool ZwWow64ReadVirtualMemory64(int hProcess, ulong pMemAddress, byte[] Buffer, ulong nSize, out ulong nReturnSize);

        [DllImport("ntdll.dll")]
        public static extern int ZwWow64WriteVirtualMemory64(int hProcess, ulong pMemAddress, byte[] Buffer, ulong nSize, out ulong nReturnSize);
    }

    internal class ProcessPatch
    {
        public static int WriteProcessMemory(int processId, ulong address, byte[] buffer, ulong size)
        {
            int num = DLLTool.OpenProcess(2035711, 0, processId);
            int retn = DLLTool.ZwWow64WriteVirtualMemory64(num, address, buffer, size, out ulong ret);
            DLLTool.CloseHandle(num);
            return retn;
        }

        public static byte[] ReadProcessMemory(int processId, ulong address, ulong size)
        {
            int num = DLLTool.OpenProcess(2035711, 0, processId);
            byte[] buffer = new byte[size];
            bool retn = DLLTool.ZwWow64ReadVirtualMemory64(num, address, buffer, size, out ulong ret);
            DLLTool.CloseHandle(num);
            return buffer;
        }
    }
}