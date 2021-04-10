using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using StoreManagement.UTILITY;

namespace StoreManagement.UI
{
    public partial class ProcessFlowUI : Form
    {
        public ProcessFlowUI()
        {
            InitializeComponent();
        }

        private void ProcessFlowUI_Load(object sender, EventArgs e)
        {
            StatusForm.ShowInactiveTopmost(this, 200, 150, 476, 406);
        }
    }
}
