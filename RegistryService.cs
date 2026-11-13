using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace SystemUtilitySuite
{
    public class RegistryService
    {
        private const string AppName = "SystemUtilitySuite_Variant24";

        // TODO 7: Сохранить пользовательскую настройку в HKCU.
        public void SaveSetting(string key, string value)
        {
            using var regKey = Registry.CurrentUser.CreateSubKey($@"Software\{AppName}");
            regKey.SetValue(key, value);
            Console.WriteLine($"Настройка {key} = {value} сохранена в реестр.");
        }

        public string? ReadSetting(string key)
        {
            using var regKey = Registry.CurrentUser.OpenSubKey($@"Software\{AppName}");
            return regKey?.GetValue(key) as string;
        }
    }
}
