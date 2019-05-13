using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using BSW_ExchangeData;
using BSW_ExchangeShared;

namespace BSW_ExchangeService
{
    /// <summary>
    /// Service Manager - management class of all teh mail processing threads
    /// </summary>
    public class ServiceManager:IDisposable
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

        public ServiceManager()
        {

        }

        #endregion

        #region - Private Members -

        private List<AdatorThread> _activeProcesses = new List<AdatorThread>();

        #endregion

        #region - Public Methods -

        /// <summary>
        /// Start the manager
        /// </summary>
        public void Start()
        {
            try
            {
                _activeProcesses = new List<AdatorThread>();
                EventLog.LogEvent("BSWExchangeService","Service-Start", EventLogType.Information);
                string msg = string.Empty;
                //We need to get all the configured profiles - we will start a new thread for each profile
                using (ProfileController controller = new ProfileController())
                {
                    if (controller.Get(new ProfileModel { IsActive = true }, ref msg))
                    {
                        foreach (ProfileModel model in controller)
                        {
                            //start a new thread for each profile
                            AdatorThread _process = new AdatorThread();
                            _process.WorkerSupportsCancellation = true;
                            _process.WorkerReportsProgress = true;

                            _process.Profile = model;

                            _process.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(_process_RunWorkerCompleted);

                            _activeProcesses.Add(_process);

                            _process.RunWorkerAsync();
                        }
                    }
                    else
                    {
                        EventLog.LogEvent("BSWExchangeService", msg, EventLogType.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                EventLog.LogEvent("BSWExchangeService", exp.Message, EventLogType.Error);
            }
        }

        private void _process_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            
        }

        /// <summary>
        /// Stop all the active processes/threads
        /// </summary>
        public void Stop()
        {
            if (_activeProcesses != null)
            {
                //we neet o stop all the threads
                foreach (AdatorThread _running in _activeProcesses)
                {
                    try
                    {
                        _running.CloseProcess();
                    }
                    catch (Exception exp)
                    {
                        EventLog.LogEvent("BSWExchangeService", exp.Message, EventLogType.Error);
                    }
                }
                _activeProcesses.Clear();
                _activeProcesses = new List<AdatorThread>();
            }
        }

        #endregion
    }
}
