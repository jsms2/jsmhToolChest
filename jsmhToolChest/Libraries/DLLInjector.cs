using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;


namespace jsmhToolChest.Libraries
{
    internal class DLLInjector
    {
        public static void InjectDLL(string Filename, byte[] DLL, Process TargetProcess)
        {
            try
            {
                System.IO.File.WriteAllBytes(Config.Config_folder + "\\DLLInjector.exe", Resource1.Injector);
                System.IO.File.WriteAllBytes(Config.Config_folder + "\\" + Filename, DLL);
                
            }
            catch (Exception e)
            {
                throw new Exception("文件写出失败，详细信息:" + e.Message);
            }
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = Config.Config_folder + "\\DLLInjector.exe";
                process.StartInfo.Arguments = $"{TargetProcess.Id} {Filename}";
                process.StartInfo.WorkingDirectory = Config.Config_folder;
                process.Start();
            } catch (Exception e)
            {
                throw new Exception("注入器进程创建失败: " + e.Message);
            }

        }
    }
}
