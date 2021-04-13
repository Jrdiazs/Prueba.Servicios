using Microsoft.Win32;
using Prueba.Servicios.StringTools;
using Quartz;
using System;

namespace Prueba.Servicios
{
    public class MyJob : IJob
    {
        private static readonly object _lock = new object();

        public void Execute(IJobExecutionContext context)
        {
            try
            {
                lock (_lock)
                {
                    string valueKey = "valorKey".ReadAppConfig();
                    Logger.Info("Prueba de servicio");
                    Logger.Info("JR");
                    using (RegistryKey regKey = Registry.LocalMachine)
                    {
                        RegistryKey key = regKey.OpenSubKey(@"SOFTWARE\\AppJRServices", true);

                        if (key != null)
                        {
                            RegistryKey subkey = key.CreateSubKey("LlaveJr",permissionCheck: RegistryKeyPermissionCheck.ReadWriteSubTree);
                            if (subkey == null) 
                            {
                                Logger.Info($"{nameof(subkey)} is null");
                            }

                            subkey.SetValue("PR", valueKey);
                            subkey.Close();
                            key.Close();
                        }
                        else
                        {
                            Logger.Info($"{nameof(key)} is null");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorFatal("Error in MyJob", ex);
            }
        }
    }
}