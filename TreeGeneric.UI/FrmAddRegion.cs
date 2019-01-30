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
    public partial class FrmAddRegion : Form
    {
       
        private readonly IRegionService regionService;
        private readonly FrmRegions frmRegions;
        public int? SelectedId;
        public FrmAddRegion(IRegionService regionService, FrmRegions frmRegions, int? id)
        
        {
            InitializeComponent();
            this.regionService = regionService;
            this.frmRegions = frmRegions;
            this.SelectedId = id;
        }

        private void FrmAddRegion_Load(object sender, EventArgs e)
        {
            if (SelectedId != null)
            {
                var region = regionService.Find(p => p.Id == SelectedId);
                textBox1.Text = region.Name;
                textBox2.Text = region.Description;
                textBox3.Text = region.Photo;
                textBox4.Text = region.Lat;
                textBox5.Text = region.Long;
                textBox6.Text = region.Capacity.ToString();
                if (region.IsActive)
                {
                    rbActive.Checked = true;
                }
                else
                {
                    rbActive.Checked = false;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SelectedId != null)
            {
                UpdateRegion();
            }
            else
            {
                AddRegion();
            }
        }
        private void AddRegion()
        {
            if (rbActive.Checked == false && rbPassive.Checked == false)
            {
                MessageBox.Show("Lütfen aktiflik durumunu seçiniz");
            }
            else
            {
                var region = new TreeGeneric.Model.Region();
                region.Name = textBox1.Text;
                region.Description = textBox2.Text;
                region.Capacity = int.Parse(textBox6.Text);
                region.Photo = textBox3.Text;
                region.Lat = textBox4.Text;
                region.Long = textBox5.Text;
                if (rbActive.Checked)
                {
                    region.IsActive = true;
                }
                else if (rbPassive.Checked)
                {
                    region.IsActive = false;
                }
                regionService.Insert(region);
                this.Close();
                frmRegions.RefreshGrid();
            }

        }
        private void UpdateRegion()
        {
            var region = regionService.Find(f => f.Id == SelectedId);
            region.Name = textBox1.Text;
            region.Description = textBox2.Text;
            region.Capacity = int.Parse(textBox6.Text);
            region.Photo = textBox3.Text;
            region.Lat = textBox4.Text;
            region.Long = textBox5.Text;

            if (rbActive.Checked)
            {
                region.IsActive = true;
            }
            else
            {
                region.IsActive = false;
            }

            regionService.Update(region);
            this.Close();
            frmRegions.RefreshGrid();
        }
    }
}

