using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderImportService
{
    public class Response:IDisposable
    {
        #region IDisposable/Construction Members

        private bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {

                }
            }
            _disposed = true;
        }

        #endregion

        public bool WasSuccessFull { get; set; }

        public string ResponseMsg { get; set; }

    }
}
