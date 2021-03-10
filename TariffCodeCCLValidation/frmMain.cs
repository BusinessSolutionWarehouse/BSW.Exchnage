using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PurchaseOrder.Data;

using System.Data.OleDb;
using System.Data.SqlClient;

namespace TariffCodeCCLValidation
{
    public partial class frmMain : Form
    {
        private byte _ProfileID = 0;
        private Timer _timer = null;
        private bool hadError = false;

        public frmMain(string profileID)
        {
            InitializeComponent();
            
            this.Text = "TariffCode Validation - Profile (Unknown)";
            try
            {
                //this line is only used for debugging - must be commented out - for full test cycle
                profileID = "2"; 

                this.Text = "TariffCode Validation - Profile ( " + profileID + ")";

                //try to parse the prfile id string to byte
                _ProfileID = byte.Parse(profileID);

                


            }
            catch (Exception exp)
            {
                lstInfo.Items.Add(exp.Message);
                //no need to do any error handeling at this point
               
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

            //string msg = string.Empty;
            //try
            //{
            //    List<ProductModel> products = new List<ProductModel>();
            //    using (ProductController controller = new ProductController())
            //    {
            //        if (controller.GetAll(ref msg))
            //        {
            //            products.AddRange(controller);
            //        }
            //        else
            //            MessageBox.Show(msg);
            //    }

            //    var service = new Service.ProgramCallService();
            //    var request = new Service.ccl9010();
            //    request.AUTHDATA = new Service.authenticationData { agent = "101566", key = "285A5HW295E", password = null, user = null };
            //    request.BEDATA = new Service.dccl9010V();

            //    List<string> doneCodes = new List<string>();
            //    bool validatecode = true;

            //    //Tariff Code: 848410101
            //    //EU: 0.0%
            //    //EFTA: 0.0%
            //    //GEN: 10.0%
            //    //SADC: 0.0%


            //    //validate each tariffcode
            //    foreach (ProductModel prod in products)
            //    {
            //        Application.DoEvents();

            //        if (!string.IsNullOrEmpty(prod.TariffCode) && prod.TariffCode != "0")
            //        {
            //            using (TariffBookController controller = new TariffBookController())
            //            {

            //                validatecode = true;

            //                if (doneCodes.Count > 0)
            //                {
            //                    foreach (string s in doneCodes)
            //                    {
            //                        if (s.Equals(prod.TariffCode, StringComparison.CurrentCultureIgnoreCase))
            //                        {
            //                            validatecode = false;
            //                            break;
            //                        }
            //                    }
            //                }

            //                if (validatecode)
            //                {
            //                    doneCodes.Add(prod.TariffCode);

            //                    request.DATA = new Service.dccl9010 { TARIFF = prod.TariffCode };
                                

            //                    var result = service.callCCL9010(request);

            //                    if (result.RETURNDTA.SUCCES.Equals("Y", StringComparison.CurrentCultureIgnoreCase))
            //                    {
            //                        TariffBookModel book = new TariffBookModel
            //                        {
            //                            TariffCode = prod.TariffCode,
            //                            s1P1Duty = decimal.Parse(result.RETURNDTA.s1P1DUTY),
            //                            s1P2ACode = result.RETURNDTA.s1P2ACODE,
            //                            s1P2ADuty = decimal.Parse(result.RETURNDTA.s1P2ADUTY),
            //                            s1P2BDuty = decimal.Parse(result.RETURNDTA.s1P2BDUTY),
            //                            s1P3ACode = result.RETURNDTA.s1P3ACODE,
            //                            s1P3ADuty = decimal.Parse(result.RETURNDTA.s1P3ADUTY),
            //                            s1P3BCode = result.RETURNDTA.s1P3BCODE,
            //                            s1P3BDuty = decimal.Parse(result.RETURNDTA.s1P3BDUTY),
            //                            s1P3CCode = result.RETURNDTA.s1P3CCODE,
            //                            s1P3CDuty = decimal.Parse(result.RETURNDTA.s1P3CDUTY),
            //                            s1P3DCode = result.RETURNDTA.s1P3DCODE,
            //                            s1P3DDuty = decimal.Parse(result.RETURNDTA.s1P3DDUTY),
            //                            s1P5ADuty = decimal.Parse(result.RETURNDTA.s1P5ADUTY),
            //                            s1P5BDuty = decimal.Parse(result.RETURNDTA.s1P5BDUTY),
            //                            s2P1Duty = decimal.Parse(result.RETURNDTA.s2P1DUTY),
            //                            s2P1DutyCode = result.RETURNDTA.s2P1DUTYCODE,
            //                            s2P2Duty = decimal.Parse(result.RETURNDTA.s2P2DUTY),
            //                            s2P2DutyCode = result.RETURNDTA.s2P2DUTYCODE,
            //                            s2P3Duty = decimal.Parse(result.RETURNDTA.s2P3DUTY),
            //                            s2P3DutyCode = result.RETURNDTA.s2P3DUTYCODE,
            //                            TotalDue = decimal.Parse(result.RETURNDTA.TOTALDUE),
            //                            TotalDuties = decimal.Parse(result.RETURNDTA.TOTALDUTIES),
            //                            VatValue = decimal.Parse(result.RETURNDTA.VATVALUE),
            //                            TariffStatusID = 1,
            //                            LastUpdateDT = DateTime.Now,
            //                            UpdatedBy = 3

            //                        };

            //                        controller.Get(new TariffBookModel { TariffCode = book.TariffCode }, ref msg);

            //                        if (controller.Count > 0)
            //                        {

            //                            if (!controller.Update(book, true, ref msg))
            //                                MessageBox.Show(msg);
            //                        }
            //                        else
            //                        {

            //                            if (!controller.Insert(book, ref msg))
            //                                MessageBox.Show(msg);
            //                        }

            //                    }
            //                }
            //            }
            //        }
            //    }
            //    MessageBox.Show("Klaaaaar");

            //}
            //catch (Exception exp)
            //{
            //    MessageBox.Show(exp.Message);
            //    hadError = true;
            //    EventLog.LogProfileEvent(_ProfileID, exp.Message, EventLogType.Error);
            //}
            //if (hadError)
            //    EventLog.LogProfileEvent(_ProfileID, "Process Failed - view history for detail", EventLogType.ProcessFailed);
            //else
            //    EventLog.LogProfileEvent(_ProfileID, "Process Successfully complete", EventLogType.ProcessComplete);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //lets get all the 8 digit t-codes
            string sql = "select Tariffcode from Product where DATALENGTH(Tariffcode) = 8 Group By Tariffcode";
            string sqlConn = "Persist Security Info=False;Initial Catalog=SupplyChainSolution;Data Source=CARLO-NB;UID=sa;PWD=W13l13w4l13;Packet Size=32767;Pooling=true;Max Pool Size=100;Min Pool Size=0;";
            //Impson
            string cclConn = "Provider=IBMDA400;Data Source=196.213.66.115;User Id=BUSPART;Password=BP2589#";

            string result = "AutoZone Code|CCL Lookup Code" + Environment.NewLine;

            using (DataTable dtCodes = new DataTable())
            {
                using (SqlConnection sConn = new SqlConnection(sqlConn))
                {
                    sConn.Open();
                    if (sConn.State == ConnectionState.Open)
                    {
                        using (SqlCommand comm = new SqlCommand(sql, sConn))
                        {
                            using (SqlDataAdapter da = new SqlDataAdapter(comm))
                            {
                                da.Fill(dtCodes);
                            }
                        }
                    }
                }

                //open ccl connection
                using (OleDbConnection cConn = new OleDbConnection(cclConn))
                {
                    cConn.Open();
                    if (cConn.State == ConnectionState.Open)
                    {
                        foreach (DataRow dr in dtCodes.Rows)
                        {
                            Application.DoEvents();

                            string select = "select TFCODE FROM QS36F.\"AG.TARNT\" \"AG.TARNT\" Where TFCODE LIKE '" + dr[0].ToString() + "%'";
                            using (OleDbCommand comm = new OleDbCommand(select, cConn))
                            {
                                using (OleDbDataReader reader = comm.ExecuteReader())
                                {
                                    if (reader != null)
                                    {
                                        using (DataTable dtR = new DataTable())
                                        {
                                            dtR.Load(reader);
                                            if (dtR.Rows.Count > 0)
                                            {
                                                result = result + dr[0].ToString() + "|" + dtR.Rows[0][0].ToString() + Environment.NewLine;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }


            }

            tBox.Text = result;

            MessageBox.Show("Klaaaaar");



        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            var service = new Service.ProgramCallService();
            var request = new Service.ccl9010();

            //set the authentication - we will read this from a config table at a later stage
            request.AUTHDATA = new Service.authenticationData { agent = "101566", key = "285A5HW295E", password = null, user = null };

            request.BEDATA = new Service.dccl9010V();

            //set the ratiff code to be validatted
            request.DATA = new Service.dccl9010 { TARIFF = "961700003", TARTYPE = textBox1.Text };//{ TARIFF = "848410101" };
            //request.DATA.TARTYPE = textBox1.Text;
                //S - SADC
                //E - EU
                //B - General
                //F - EFTA


            //do the call to the service
            var result = service.callCCL9010(request);


            //set pass the results of the service back to the data rows we will return
            if (result.RETURNDTA.SUCCES.Equals("Y", StringComparison.CurrentCultureIgnoreCase))
            {

                tBox.Text = textBox1.Text + " : " + result.DATA.DUTYPERC;
            }
            else
            {
                tBox.Text = "Oeps";
                tBox.Text += result.RETURNDTA.AMSG[0];
            }
        }
    }
}
