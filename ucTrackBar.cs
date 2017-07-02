using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace config1v1
{
    public partial class ucTrackBar : UserControl
    {
        public ucTrackBar()
        {
            InitializeComponent();
        }

        [
        Category("CustomStuff"),
        //Description("")
        ]
        public event EventHandler TrackbarChanged;

        // Design time properties
        [
        Category("CustomStuff"),
        //Description("")
        ]
        public int Minimum
        {
            get
            {
                return tb.Minimum;
            }
            set
            {
                tb.Minimum = value;
            }
        }

        [
        Category("CustomStuff"),
        //Description("")
        ]
        public int Maximum
        {
            get
            {
                return tb.Maximum;
            }
            set
            {
                tb.Maximum = value;
                lbl.Text = tb.Value + "/" + tb.Maximum;
            }
        }

        [
        Category("CustomStuff"),
        //Description("")
        ]
        public int TickFrequency
        {
            get
            {
                return tb.TickFrequency;
            }
            set
            {
                tb.TickFrequency = value;
            }
        }

        [
        Category("CustomStuff"),
        //Description("")
        ]
        public int SmallChange
        {
            get
            {
                return tb.SmallChange;
            }
            set
            {
                tb.SmallChange = value;
            }
        }

        [
        Category("CustomStuff"),
        //Description("")
        ]
        public int LargeChange
        {
            get
            {
                return tb.LargeChange;
            }
            set
            {
                tb.LargeChange = value;
            }
        }

        [
        Category("CustomStuff"),
        //Description("")
        ]
        public int Value
        {
            get
            {
                return tb.Value;
            }
            set
            {
                tb.Value = value;
                lbl.Text = tb.Value + "/" + tb.Maximum;
            }
        }

        public void TriggerChange(object sender, EventArgs e)
        {
            if (TrackbarChanged != null)
            {
                TrackbarChanged(sender, e);
            }
        }

        private void tb_Scroll(object sender, EventArgs e)
        {
            lbl.Text = tb.Value + "/" + tb.Maximum;
            if (TrackbarChanged != null)
            {
                TrackbarChanged(sender, e);
            }
        }
    }
}
