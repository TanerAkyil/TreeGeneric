using Autofac;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeGeneric.UI
{
    public partial class FrmMain : Form
    {
        private readonly ILifetimeScope scope;
        public FrmMain(ILifetimeScope scope)
        {
            InitializeComponent();
            this.scope = scope;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            pnlHome.Visible = true;
            pnlDonate.Visible = false;
            pnlUser.Visible = false;
            pnlDikim.Visible = false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            pnlHome.Visible = true;
            pnlDonate.Visible = false;
            pnlUser.Visible = false;
            pnlDikim.Visible = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            pnlHome.Visible = false;
            pnlDonate.Visible = true;
            pnlUser.Visible = false;
            pnlDikim.Visible = false;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            pnlHome.Visible = false;
            pnlDonate.Visible = false;
            pnlUser.Visible = false;
            pnlDikim.Visible = true;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            pnlHome.Visible = false;
            pnlDonate.Visible = false;
            pnlUser.Visible = true;
            pnlDikim.Visible = false;
        }

        private void bölgelerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frm = new FrmRegions(scope);
            frm.ShowDialog();
        }
    }
}
