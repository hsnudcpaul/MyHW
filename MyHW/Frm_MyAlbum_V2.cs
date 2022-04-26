using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MyHW.Properties;
using System.IO;

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
                comboBox2.Items.Add($"{cityDataSet1.City[i][0]}");
                string city = cityNameTextBox.Text;
                photoTableAdapter1.FillByCitySearch(cityDataSet1.Photo, city);
                photoDataGridView.DataSource = cityDataSet1.Photo;
            }
        }

        private void FlowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {



            if (comboBox1.SelectedItem != null)
            {
                string city = comboBox1.SelectedItem.ToString();
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

                    using (SqlConnection conn = new SqlConnection(Settings.Default.CityPhConnectionString))
                    {
                        SqlCommand command = new SqlCommand();
                        command.Connection = conn;
                        command.CommandText = $"insert into Photo (City,Photo) values (@city,@photo)";
                        command.Parameters.Add("@city", SqlDbType.Int).Value = comboBox2.Items[comboBox1.SelectedIndex];
                        command.Parameters.Add("@photo", SqlDbType.Image).Value = bytes;
                        conn.Open();
                        command.ExecuteNonQuery();
                    }
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
            photoTableAdapter1.FillByCitySearch(cityDataSet1.Photo, s);
            flowLayoutPanel3.Controls.Clear();
            for (int i = 0; i < cityDataSet1.Photo.Rows.Count; i++)
            {
                byte[] bytes = (byte[])cityDataSet1.Photo[i]["Photo"];
                System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                PictureBox pic = new PictureBox();
                pic.Image = Image.FromStream(ms);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Width = 200;
                pic.Height = 160;
                flowLayoutPanel3.Controls.Add(pic);

                pic.Click += Pic_Click;
            }

        }

        private void Pic_Click(object sender, EventArgs e)
        {
            Image bim = ((PictureBox)sender).Image;
            Frm_OpenPic opPic = new Frm_OpenPic();
            opPic.BackgroundImage = bim;
            opPic.BackgroundImageLayout = ImageLayout.Stretch;
            opPic.Show();

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

            string s = comboBox1.SelectedItem.ToString();
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

            }
        }

        private void cityNameTextBox_TextChanged(object sender, EventArgs e)
        {
            string city = cityNameTextBox.Text;
            photoTableAdapter1.FillByCitySearch(cityDataSet1.Photo, city);
            photoDataGridView.DataSource = cityDataSet1.Photo;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.Description = "請選擇Txt所在資料夾";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                string path = dialog.SelectedPath;
                DirectoryInfo di = new DirectoryInfo(path);
                FileInfo[] fi = di.GetFiles("*.jpg");
                foreach (FileInfo file in fi)
                {
                    PictureBox pic = new PictureBox();
                    pic.Image = Image.FromFile(file.FullName);
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Width = 200;
                    pic.Height = 160;
                    flowLayoutPanel1.Controls.Add(pic);

                    byte[] bytes;
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    pic.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    bytes = ms.GetBuffer();

                    using (SqlConnection conn = new SqlConnection(Settings.Default.CityPhConnectionString))
                    {
                        SqlCommand command = new SqlCommand();
                        command.Connection = conn;
                        command.CommandText = $"insert into Photo (City,Photo) values (@city,@photo)";
                        command.Parameters.Add("@city", SqlDbType.Int).Value = comboBox2.Items[comboBox1.SelectedIndex];
                        command.Parameters.Add("@photo", SqlDbType.Image).Value = bytes;
                        conn.Open();
                        command.ExecuteNonQuery();
                    }
                }

            }
        }


    }
}
