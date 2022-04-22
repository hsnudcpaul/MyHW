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

            flowLayoutPanel1.AllowDrop = true;
            flowLayoutPanel1.DragEnter += FlowLayoutPanel1_DragEnter;
            flowLayoutPanel1.DragDrop += FlowLayoutPanel1_DragDrop;

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
                comboBox1.Text = "請選擇城市";
                comboBox1.Items.Add($"{cityDataSet1.City[i][1]}");
            }
        }

        private void FlowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            string city = comboBox1.SelectedItem.ToString();
       
            
            //if (comboBox1.h) 
            { 
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                for (int i = 0; i < files.Length; i++)
                {
                    
                    PictureBox pic = new PictureBox();
                    pic.Image = Image.FromFile(files[i]);
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Width = 200;
                    pic.Height = 160;
                    flowLayoutPanel1.Controls.Add(pic);
                    byte[] bytes;
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    pic.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    bytes = ms.GetBuffer();
                    CityDataSet.PhotoRow photoRow = cityDataSet1.Photo.NewPhotoRow();
                    photoRow.Photo = bytes;
                    photoRow.City = (int)cityDataSet1.City[0][0];
cityTableAdapter1.FillByGetCity(cityDataSet1.City, city);
                    cityDataSet1.Photo.AddPhotoRow(photoRow);
                            }
            }
        }

        private void FlowLayoutPanel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void LKl_Click(object sender, EventArgs e)
        {
            LinkLabel x = (LinkLabel)sender;
            string s = x.Text;
            
            flowLayoutPanel3.Controls.Clear();
            for (int i = 0; i < cityDataSet1.Photo.Rows.Count; i++)
            {
                byte[] bytes=(byte[])cityDataSet1.Photo[i]["Photo"];
                System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                PictureBox pic = new PictureBox();
                pic.Image = Image.FromStream(ms);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Width = 200;
                pic.Height = 160;
                flowLayoutPanel3.Controls.Add(pic);

                ////pic.Click += Pic_Click;
            }

        }

        private void photoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.photoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cityDataSet1);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {

                photoPictureBox.Image = Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void Frm_MyAlbum_V2_Load(object sender, EventArgs e)
        {
         
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string s = comboBox1.SelectedItem.ToString ();
            photoTableAdapter1.FillByCitySearch(cityDataSet1.Photo, s);

            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < cityDataSet1.Photo.Rows.Count; i++)
            {
                byte[] bytes = (byte[])cityDataSet1.Photo[i]["Photo"];
                System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                PictureBox pic = new PictureBox();
                pic.Image = Image.FromStream(ms);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Width = 200;
                pic.Height = 160;
                flowLayoutPanel1.Controls.Add(pic);
                //pic.Click += Pic_Click;
            }
        }
    }
}
