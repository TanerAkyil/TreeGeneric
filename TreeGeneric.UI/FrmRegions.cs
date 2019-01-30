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
using TreeGeneric.BussinessLogic;

namespace TreeGeneric.UI
{
    public partial class FrmRegions : Form
    {
        private readonly IRegionService regionService;
        private readonly ILifetimeScope scope;
        public FrmRegions(ILifetimeScope scope)
        {
            InitializeComponent();
            this.scope = scope;
            this.regionService = scope.Resolve<IRegionService>();
        }

        private void FrmRegions_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }
        public void RefreshGrid()
        {
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = regionService.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           FrmAddRegion frmAddRegion = new FrmAddRegion(regionService, this, null);
            frmAddRegion.ShowDialog();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                FrmAddRegion frmAddRegion = new FrmAddRegion(regionService, this, id);
                frmAddRegion.ShowDialog();
            }
            else
            {
                MessageBox.Show("Düzenlemek için bir kayıt giriniz");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                regionService.Delete(id);
                MessageBox.Show("Kayıt başarıyla silindi");
                RefreshGrid();
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir kayıt seçiniz");
            }
        }
    }
}
