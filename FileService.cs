using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemUtilitySuite
{
    public class FileService
    {
        // TODO 3: Выполнить асинхронную файловую операцию.
        public async Task WriteAndReadAsync(string path, string content)
        {
            await File.WriteAllTextAsync(path, content);
            Console.WriteLine($"Файл {path} записан.");

            string readContent = await File.ReadAllTextAsync(path);
            Console.WriteLine($"Прочитано из файла: {readContent}");
        }
    }

}
