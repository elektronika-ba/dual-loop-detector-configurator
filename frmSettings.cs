using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace config1v1
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        public void setFormData(string comPort)
        {
            try
            {
                udComPort.Value = int.Parse(comPort);
            }
            catch (Exception) { }
        }

        public string getFormData()
        {
            return udComPort.Value.ToString();
        }
    }
}
