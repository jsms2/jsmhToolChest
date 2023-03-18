using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace jsmhToolChest.Libraries.ProcessModules
{
    public struct LIST_ENTRY64
    {
        public ulong Flink;

        public ulong Blink;
    }

    public struct LDR_DATA_TABLE_ENTRY64
    {
        public LIST_ENTRY64 InLoadOrderLinks;

        public LIST_ENTRY64 InMemoryOrderLinks;

        public LIST_ENTRY64 InInitializationOrderLinks;

        public ulong DllBase;

        public ulong EntryPoint;

        public uint SizeOfImage;

        public UNICODE_STRING64 FullDllName;

        public UNICODE_STRING64 BaseDllName;

        public uint Flags;

        public ushort LoadCount;

        public ushort TlsIndex;

        public LIST_ENTRY64 HashLinks;

        public uint CheckSum;

        public ulong LoadedImports;

        public ulong EntryPointActivationContext;

        public ulong PatchInformation;
    }

    public struct PROCESS_BASIC_INFORMATION64
    {
        public uint NTSTATUS;

        public uint Reserved0;

        public ulong PebBaseAddress;

        public ulong AffinityMask;

        public uint BasePriority;

        public uint Reserved1;

        public ulong UniqueProcessId;

        public ulong InheritedFromUniqueProcessId;
    }

    public struct UNICODE_STRING64
    {
        public ushort Length;

        public ushort MaximumLength;

        public ulong Buffer;
    }

    public static class DLLTool
    {
        [DllImport("kernel32.dll")]
        public static extern int OpenProcess(uint dwDesiredAccess, bool bInheritHandle, uint dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool IsWow64Process(int hProcess, out bool Wow64Process);

        [DllImport("ntdll.dll")]
        public static extern int NtWow64QueryInformationProcess64(int hProcess, uint ProcessInfoclass, out PROCESS_BASIC_INFORMATION64 pBuffer, uint nSize, out uint nReturnSize);

        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(int hObject);

        [DllImport("ntdll.dll")]
        public unsafe static extern int NtWow64ReadVirtualMemory64(int hProcess, ulong pMemAddress, int* pBufferPtr, ulong nSize, out ulong nReturnSize);

        [DllImport("ntdll.dll")]
        public static extern int NtWow64ReadVirtualMemory64(int hProcess, ulong pMemAddress, out LDR_DATA_TABLE_ENTRY64 pBufferPtr, ulong nSize, out ulong nReturnSize);

        [DllImport("ntdll.dll")]
        public static extern int NtWow64ReadVirtualMemory64(int hProcess, ulong pMemAddress, out ulong pBufferPtr, ulong nSize, out ulong nReturnSize);

        [DllImport("ntdll.dll")]
        public static extern int NtWow64ReadVirtualMemory64(int hProcess, ulong pMemAddress, out LIST_ENTRY64 pBufferPtr, ulong nSize, out ulong nReturnSize);

        [DllImport("kernel32.dll", EntryPoint = "RtlMoveMemory")]
        public static extern int BinToLDR_DATA_TABLE_ENTRY64(LDR_DATA_TABLE_ENTRY64 lpDestination, byte[] lpSource, int Length);
    }

    public class ProcessModule64
    {
        public ProcessModule64(LDR_DATA_TABLE_ENTRY64 dllInfo, string dllpath)
        {
            try
            {
                FileName = dllpath;
                BaseAddress = (long)dllInfo.DllBase;
                ModuleMemorySize = dllInfo.SizeOfImage;
                EntryPointAddress = (long)dllInfo.EntryPoint;
                ModuleName = Path.GetFileName(dllpath);
            }
            catch
            {
            }
        }

        public string ModuleName { get; }

        public string FileName { get; }

        public long BaseAddress { get; }

        public long ModuleMemorySize { get; }

        public long EntryPointAddress { get; }
    }

    internal class ProcessModules
    {
        public unsafe static ProcessModule64[] getWOW64Modules(int PID)
        {
            uint nReturnSize = 0u;
            ulong nReturnSize2 = 0uL;
            ulong pBufferPtr = 0uL;
            _ = new byte[512];
            PROCESS_BASIC_INFORMATION64 pBuffer = default(PROCESS_BASIC_INFORMATION64);
            LIST_ENTRY64 pBufferPtr2 = default(LIST_ENTRY64);
            LDR_DATA_TABLE_ENTRY64 pBufferPtr3 = default(LDR_DATA_TABLE_ENTRY64);
            List<ProcessModule64> list = new List<ProcessModule64>();
            int num = DLLTool.OpenProcess(1040u, bInheritHandle: false, (uint)PID);
            if (num == 0)
            {
                return new ProcessModule64[0];
            }
            if (DLLTool.NtWow64QueryInformationProcess64(num, 0u, out pBuffer, 48u, out nReturnSize) < 0)
            {
                global::System.Diagnostics.Debug.Write("查询进程信息失败,如果一直出现可能无法获取进程模块");
                DLLTool.CloseHandle(num);
                return new ProcessModule64[0];
            }
            if (pBuffer.PebBaseAddress == 0L)
            {
                global::System.Diagnostics.Debug.Write("获取PEB64结构地址失败,如果一直出现可能无法获取进程模块");
                DLLTool.CloseHandle(num);
                return new ProcessModule64[0];
            }
            if (DLLTool.NtWow64ReadVirtualMemory64(num, pBuffer.PebBaseAddress + 24, out pBufferPtr, 8uL, out nReturnSize2) < 0)
            {
                global::System.Diagnostics.Debug.Write("获取Ldr64结构失败,如果一直出现可能无法获取进程模块");
                DLLTool.CloseHandle(num);
                return new ProcessModule64[0];
            }
            if (DLLTool.NtWow64ReadVirtualMemory64(num, pBufferPtr + 16, out pBufferPtr2, 16uL, out nReturnSize2) < 0)
            {
                global::System.Diagnostics.Debug.Write("获取Ldr64.InLoadOrderModuleList.Flink地址失败,如果一直出现可能无法获取进程模块");
                DLLTool.CloseHandle(num);
                return new ProcessModule64[0];
            }
            if (DLLTool.NtWow64ReadVirtualMemory64(num, pBufferPtr2.Flink, out pBufferPtr3, (ulong)Marshal.SizeOf((object)pBufferPtr3), out nReturnSize2) < 0)
            {
                global::System.Diagnostics.Debug.Write("获取LDTE64结构失败,如果一直出现可能无法获取进程模块");
                DLLTool.CloseHandle(num);
                return new ProcessModule64[0];
            }
            while (pBufferPtr3.InLoadOrderLinks.Flink != pBufferPtr2.Flink)
            {
                try
                {
                    IntPtr intPtr = Marshal.AllocHGlobal(pBufferPtr3.FullDllName.Length);
                    if (DLLTool.NtWow64ReadVirtualMemory64(num, pBufferPtr3.FullDllName.Buffer, (int*)(void*)intPtr, pBufferPtr3.FullDllName.Length, out nReturnSize2) >= 0)
                    {
                        ProcessModule64 item = new ProcessModule64(pBufferPtr3, Marshal.PtrToStringUni(intPtr, (int)pBufferPtr3.FullDllName.Length / 2));
                        Marshal.FreeHGlobal(intPtr);
                        list.Add(item);
                    }
                }
                catch { }
                if (DLLTool.NtWow64ReadVirtualMemory64(num, pBufferPtr3.InLoadOrderLinks.Flink, out pBufferPtr3, (ulong)Marshal.SizeOf((object)pBufferPtr3), out nReturnSize2) < 0)
                {
                    break;
                }
            }
            DLLTool.CloseHandle(num);
            return list.ToArray();
        }
    }
}