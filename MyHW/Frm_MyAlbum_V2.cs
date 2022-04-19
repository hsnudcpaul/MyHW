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
    public partial class Frm_MyAlbum_V2 : Form
    {
        public Frm_MyAlbum_V2()
        {
            InitializeComponent();
        
            cityTableAdapter1.Fill(cityDataSet1.City);
            for (int i = 0; i < cityDataSet1.City.Rows.Count; i++)
            {
                LinkLabel lKl = new LinkLabel();
                lKl.Text = $"{cityDataSet1.City[i][1]}";
                lKl.Top = i * 40 + 70;
                lKl.Left = 10;
                lKl.Click += LKl_Click;
                lKl.Tag = i + 1;
               flowLayoutPanel2.Controls.Add(lKl);
            }
        }

        private void LKl_Click(object sender, EventArgs e)
        {
            LinkLabel x = (LinkLabel)sender;
            string s = x.Text;
            photoTableAdapter1.FillByCitySearch(cityDataSet1.Photo, s);
            //dataGridView1.DataSource = cityDataSet1.Photo;

        }
    }
}
