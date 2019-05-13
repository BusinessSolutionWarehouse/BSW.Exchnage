using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace BSW_ExchangeService
{
    public partial class MainService : ServiceBase
    {
        private ServiceManager _manager = new ServiceManager();

        public MainService()
        {
            InitializeComponent();
            //we need to set a few needed settings
            this.EventLog.Log = "Application";

            this.CanHandlePowerEvent = true;
            this.CanHandleSessionChangeEvent = true;
            this.CanPauseAndContinue = true;
            this.CanShutdown = true;
            this.CanStop = true;

        }

        protected override void OnStart(string[] args)
        {
            //We use the service manager - to manage all the different processes and adaptors that be be used
            _manager.Start();
        }

        protected override void OnStop()
        {
            _manager.Stop();
        }

        protected override void OnPause()
        {
            _manager.Stop();
            base.OnPause();
        }

        protected override void OnContinue()
        {
            _manager.Start();
            base.OnContinue();
        }
    
    }
}
