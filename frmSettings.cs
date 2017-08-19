using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLDConfig1v1
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        public void setFormData(string comPort, int baudRate)
        {
            try
            {
                udComPort.Value = int.Parse(comPort);
                cbBaudRate.SelectedIndex = cbBaudRate.Items.IndexOf(baudRate.ToString());
            }
            catch (Exception) { }
        }

        public string getComPort()
        {
            return udComPort.Value.ToString();
        }

        public int getBaudRate()
        {
            return int.Parse(cbBaudRate.Items[cbBaudRate.SelectedIndex].ToString());
        }
    }
}
