using FastWin32.Diagnostics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;


namespace jsmhToolChest.Netease
{
    internal class NeteaseClient
    {
        public static Process GetNeteaseClientProcess()
        {
            try
            {
                Process[] ProcessList = Process.GetProcesses();
                foreach (Process EachProcess in ProcessList)
                {
                    if (EachProcess.ProcessName.Equals("java") || EachProcess.ProcessName.Equals("javaw"))
                    {
                        string query = $"SELECT CommandLine FROM Win32_Process WHERE ProcessId = {EachProcess.Id}";
                        
                        using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
                        {
                            foreach (ManagementObject obj in searcher.Get())
                            {
                                if (obj["CommandLine"] != null)
                                {
                                    string CommandLine = obj["CommandLine"].ToString();
                                    if (CommandLine.Contains("-DlauncherControlPort"))
                                    {
                                        EachProcess.StartInfo.Arguments = CommandLine;
                                        return EachProcess;
                                    }
                                }
                                else
                                {
                                    return null;
                                }
                            }
                        }
                    }
                }
            }catch (Exception) { }
            
            return null;
        }
    }
}
