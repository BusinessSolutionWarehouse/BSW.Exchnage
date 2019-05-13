using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AZROEImports
{
    public abstract class ModelBase:IDisposable
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

        public ModelBase()
        {

        }

        #endregion
    }
}
