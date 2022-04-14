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
    public partial class Frm0414_HW : Form
    {
        public Frm0414_HW()
        {
            InitializeComponent();

            productPhotoTableAdapter1.FillByGroupByYear(advDataSet1.ProductPhoto);
            bindingSource1.DataSource = advDataSet1.ProductPhoto;
            dataGridView1.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;
            //advDataSet1.ProductPhoto.Rows
            string year = "";
            string row = " ";
            for (int i = 0; i < advDataSet1.ProductPhoto.Rows.Count; i++)
                {
 
                        row= $"{(advDataSet1.ProductPhoto[i][5])}";
                year = row.Substring(0, 4);

                comboBox1.Items.Add(year);
                List<string> ylist = new List<string>();
                foreach(string s in comboBox1.Items)
                {
                    if (!ylist.Contains(s)) 
                    {
                        ylist.Add(s);
                    }
                }
                ylist.OrderBy(x => x);
                comboBox1.Items.Clear();
                foreach(string s in ylist)
                {
                    comboBox1.Items.Add(s);
                }
             

                }
                
            }
        

        private void button13_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveFirst();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            bindingSource1.MovePrevious();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveNext();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveLast();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            label4.Text = $"{bindingSource1.Position + 1}" + " / " + $"{ bindingSource1.Count}";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            decimal y = Convert.ToDecimal(comboBox1.SelectedItem);
            productPhotoTableAdapter1.FillByYearSearch(advDataSet1.ProductPhoto, y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime max =dateTimePicker2.Value ;
            DateTime min = dateTimePicker1.Value;

            productPhotoTableAdapter1.FillByDateBetween(advDataSet1.ProductPhoto, min, max);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //bindingSource1.DataSource() 
        }
    }
}
