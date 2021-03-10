using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BSW_FTP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openF = new OpenFileDialog())
            {
                if (openF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    using (BSWFTPClient.FTP ftp = new BSWFTPClient.FTP())
                    {
                        ftp.Host = txtServer.Text;
                        ftp.UserName = txtUser.Text;
                        ftp.Password = txtPwd.Text;
                        ftp.FileProgressChanged += new BSWFTPClient.FTP.FileProgressChangedDelegate(ftp_FileProgressChanged);
                        ftp.ExceptionRaised += new BSWFTPClient.FTP.ExceptionRaisedDelegate(ftp_ExceptionRaised);
                        ftp.UploadFile(txtPath.Text + @"\" +  Path.GetFileName(openF.FileName), openF.FileName);

                    }
                }
            }

            MessageBox.Show("Done");
        }

        private void ftp_ExceptionRaised(string errorMsg)
        {
            MessageBox.Show(errorMsg,"FTP Error");
        }

        private void ftp_FileProgressChanged(long totalSoze, long sizedone)
        {
            progressBar1.Maximum = (int)totalSoze;
            progressBar1.Value = (int)sizedone;
            Application.DoEvents();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (BSWFTPClient.FTP ftp = new BSWFTPClient.FTP())
            {
                ftp.Host = "41.66.157.112";
                ftp.UserName = "AutoZone";
                ftp.Password = "Aut0zone@RG2013";
                ftp.FileProgressChanged += new BSWFTPClient.FTP.FileProgressChangedDelegate(ftp_FileProgressChanged);
                MessageBox.Show(ftp.GetFileSize("airwaybill.pdf").ToString());

            }

            MessageBox.Show("Done");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveF = new SaveFileDialog())
            {
                if (saveF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    using (BSWFTPClient.FTP ftp = new BSWFTPClient.FTP())
                    {
                        ftp.Host = txtServer.Text;
                        ftp.UserName = txtUser.Text;
                        ftp.Password = txtPwd.Text;
                        ftp.FileProgressChanged += new BSWFTPClient.FTP.FileProgressChangedDelegate(ftp_FileProgressChanged);
                        ftp.ExceptionRaised += new BSWFTPClient.FTP.ExceptionRaisedDelegate(ftp_ExceptionRaised);
                        ftp.DownloadFile(txtPath.Text + @"\" + txtFileName.Text, saveF.FileName);

                    }
                }
            }

            MessageBox.Show("Done");
        }

        
    }
}
