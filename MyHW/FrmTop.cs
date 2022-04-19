using MyHW;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace Form_Lab
{
    public partial class FrmTop : Form
    {
        public FrmTop()
        {
            InitializeComponent();
           
        }


     



        private void btnPos_Click_1(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            Frm標準練習 f1 = new Frm標準練習();
            f1.TopLevel = false;
            splitContainer2.Panel2.Controls.Add(f1);
            f1.Dock = DockStyle.Fill;
            f1.FormBorderStyle = FormBorderStyle.None;
            f1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            Frm_TreeView f1 = new Frm_TreeView();
            f1.TopLevel = false;
            splitContainer2.Panel2.Controls.Add(f1);
            f1.Dock = DockStyle.Fill;
            f1.FormBorderStyle = FormBorderStyle.None;
            f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            Frm_CategoryProduct f1 = new Frm_CategoryProduct();
            f1.TopLevel = false;
            splitContainer2.Panel2.Controls.Add(f1);
            f1.Dock = DockStyle.Fill;
            f1.FormBorderStyle = FormBorderStyle.None;
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            Frm_Products f1 = new Frm_Products();
            f1.TopLevel = false;
            splitContainer2.Panel2.Controls.Add(f1);
            f1.Dock = DockStyle.Fill;
            f1.FormBorderStyle = FormBorderStyle.None;
            f1.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            Frm0414_HW f1 = new  Frm0414_HW();
            f1.TopLevel = false;
            splitContainer2.Panel2.Controls.Add(f1);
            f1.Dock = DockStyle.Fill;
            f1.FormBorderStyle = FormBorderStyle.None;
            f1.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            Frm_MyAlbum_V2 f1 = new   Frm_MyAlbum_V2();
            f1.TopLevel = false;
            splitContainer2.Panel2.Controls.Add(f1);
            f1.Dock = DockStyle.Fill;
            f1.FormBorderStyle = FormBorderStyle.None;
            f1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
           Frm_Customers f1 = new  Frm_Customers();
            f1.TopLevel = false;
            splitContainer2.Panel2.Controls.Add(f1);
            f1.Dock = DockStyle.Fill;
            f1.FormBorderStyle = FormBorderStyle.None;
            f1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            Frm_LogOn f1 = new Frm_LogOn();
            f1.TopLevel = false;
            splitContainer2.Panel2.Controls.Add(f1);
            f1.Dock = DockStyle.Fill;
            f1.FormBorderStyle = FormBorderStyle.None;
            f1.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            FrmDataSet結構 f1 = new FrmDataSet結構();
            f1.TopLevel = false;
            splitContainer2.Panel2.Controls.Add(f1);
            f1.Dock = DockStyle.Fill;
            f1.FormBorderStyle = FormBorderStyle.None;
            f1.Show();
        }
    }
    }

