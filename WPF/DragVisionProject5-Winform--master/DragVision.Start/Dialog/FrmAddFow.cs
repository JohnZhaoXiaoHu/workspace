using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragVision.Start.Dialog
{
    public partial class FrmAddFow : Form
    {
        public FrmAddFow()
        {
            InitializeComponent();
        }

        private void FrmAddFow_Load(object sender, EventArgs e)
        {

        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            this.Tag = textFloName.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.Cancel;
        }
    }
}
