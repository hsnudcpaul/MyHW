﻿using System;
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
    public partial class FrmPhotoTool : Form
    {
        public FrmPhotoTool()
        {
            InitializeComponent();
        }

        private void photoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.photoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cityDataSet);

        }

        private void FrmPhotoTool_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'cityDataSet.Photo' 資料表。您可以視需要進行移動或移除。
            this.photoTableAdapter.Fill(this.cityDataSet.Photo);

        }

         private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
              
               photoPictureBox.Image = Image.FromFile(openFileDialog1.FileName);

            }
            else
            {
                MessageBox.Show("Cancel");
            }
        }
    }
}
