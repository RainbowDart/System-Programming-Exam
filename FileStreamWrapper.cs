using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemUtilitySuite
{
    public class FileStreamWrapper : IDisposable
    {
        private readonly FileStream _fileStream;
        private bool _disposed = false;

        public FileStreamWrapper(string path)
        {
            _fileStream = new FileStream(path, FileMode.Create);
        }

        public void WriteByte(byte value)
        {
            if (_disposed) throw new ObjectDisposedException(nameof(FileStreamWrapper));
            _fileStream.WriteByte(value);
        }

        // TODO 6: Создать IDisposable-обёртку над FileStream.
        public void Dispose()
        {
            if (!_disposed)
            {
                _fileStream?.Dispose();
                _disposed = true;
            }
            GC.SuppressFinalize(this);
        }
    }
}
