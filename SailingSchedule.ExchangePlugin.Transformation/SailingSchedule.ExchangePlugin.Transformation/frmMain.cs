using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using BSW_ExchangeShared;
using BSW_ExchangeData;
using System.Data.SqlClient;
using System.Configuration;

namespace SailingSchedule.ExchangePlugin.Transformation
{
    public partial class frmMain : Form
    {
        private byte _ProfileID = 0;
        private Timer _timer = null;

        public frmMain(string profileID)
        {
            InitializeComponent();

            try
            {
                //this line is only used for debugging - must be commented out - for full test cycle
                profileID = "3";

                this.Text = "Running data conversion profile - " + profileID;

                //try to parse the profile id string to byte
                _ProfileID = byte.Parse(profileID);

                //lest start the timer - we use this only to give the application some time to load first
                _timer = new Timer();
                _timer.Tick += new EventHandler(_timer_Tick);
                _timer.Interval = 100;
                _timer.Enabled = true;
                _timer.Start();
            }
            catch (Exception exp)
            {
                lstInfo.Items.Add(exp.Message);
                //no need to do any error handling at this point
                this.Dispose();
            }
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            //stop and disable the timer
            _timer.Stop();
            _timer.Enabled = false;
            _timer.Dispose();

            bool hadError = false;

            try
            {
                if (!ProcessData())
                {
                    hadError = true;
                }
            }
            catch (Exception exp)
            {
                hadError = true;
                EventLog.LogProfileEvent(_ProfileID, exp.Message, EventLogType.Error);
            }
            if (hadError)
                EventLog.LogProfileEvent(_ProfileID, "Process Failed - view history for detail", EventLogType.ProcessFailed);
            else
                EventLog.LogProfileEvent(_ProfileID, "Process Successfully complete", EventLogType.ProcessComplete);

            //we close the application
            this.Dispose();
        }

        /// <summary>
        /// Load all unprocessed import messages and process them
        /// </summary>
        /// <returns></returns>
        private bool ProcessData()
        {
            bool result = true;
            try
            {
                string msg = string.Empty;
                List<ValidationError> valErrors = new List<ValidationError>();

                // first get all unprocessed import messages
                using (ImportMessageModel model = new ImportMessageModel())
                {
                    // move to web config
                    model.ProfileID = Convert.ToByte(ConfigurationManager.AppSettings["XMLProfileID"]);
                    model.MessageStatus = 1;
                    model.MessageTypeID = Convert.ToByte(ConfigurationManager.AppSettings["ImportMessageTypeID"]);

                    List<SqlParameter> listParameters = new List<SqlParameter>();

                    using (ImportMessageController controller = new ImportMessageController())
                    {
                        if (controller.Get(model, ref msg))
                        {
                            if (controller.Count > 0)
                            {
                                // sort by MessageDt field ... by default sorts by MessageID
                                var sortedController = controller.OrderBy(c => c.MessageDt);

                                foreach (ImportMessageModel con in sortedController)
                                {
                                    // execute SP using message ID
                                    listParameters.Add(ControllerManager.CreateParameter("@ImportMessageID", con.MessageID, SqlDbType.BigInt));
                                    ControllerManager.ExecuteSP("dbo.SS_XMLDataConversion", listParameters, ref msg);
                                    listParameters.Clear();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                result = false;
                EventLog.LogProfileEvent(_ProfileID, exp.Message, EventLogType.Error);
            }
            return result;
        }
    }
}