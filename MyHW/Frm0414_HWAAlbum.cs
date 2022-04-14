using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHW
{
    public partial class Frm0414_HWAAlbum : Form
    {
        public Frm0414_HWAAlbum()
        {
            InitializeComponent();
            cityTableAdapter1.Fill(cityDataSet1.City);
            for(int i = 0; i < cityDataSet1.City.Rows.Count; i++)
            {
                LinkLabel lKl = new LinkLabel();
                lKl.Text =$"{cityDataSet1.City[i][1]}";
                lKl.Top = i * 40 + 20;
                lKl.Left = 10;
                lKl.Click += LKl_Click;
                lKl.Tag = i + 1;
                splitContainer2.Panel1.Controls.Add(lKl);
            }
        }

        private void LKl_Click(object sender, EventArgs e)
        {
            LinkLabel x = (LinkLabel)sender;
            string s = x.Text;
            photoTableAdapter1.FillByCitySearch(cityDataSet1.Photo, s);
            dataGridView1.DataSource = cityDataSet1.Photo;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmPhotoTool photo = new FrmPhotoTool();
            photo.Show();
        }
    }
}
