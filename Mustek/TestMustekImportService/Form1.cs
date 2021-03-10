using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestMustekImportService
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string xmlToSend = string.Empty;

            using(MustekOrders.OrdersClient client = new MustekOrders.OrdersClient())
            {
                string fileName = @"D:\LPS\Change Requests\Mustek\2015\XML_F52E2B61-18A1-11d1-B105-00805F49916B1.xml";

                xmlToSend = System.IO.File.ReadAllText(fileName);

                MustekOrders.Response result = client.PostOrder(xmlToSend);

                MessageBox.Show(result.ResponseMsg);
            }
        }
    }
}
