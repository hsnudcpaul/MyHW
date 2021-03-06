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
    public partial class Frm_Products : Form
    {
        public Frm_Products()
        {
            InitializeComponent();
            productsTableAdapter1.Fill(nwDataSet1.Products);
            bindingSource1.DataSource = nwDataSet1.Products;
            dataGridView1.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;
        }




        private void button1_Click(object sender, EventArgs e)
        {
            bindingSource1 .MoveFirst();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            bindingSource1.MovePrevious();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveNext();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveLast();
        }

        private void productsBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            label4.Text = $"{bindingSource1.Position + 1} / {bindingSource1.Count}";
            label5.Text = $"結果共{bindingSource1.Count}筆";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string s = textBox3.Text;
            productsTableAdapter1.FillBySearchProductName(nwDataSet1.Products,s);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            decimal max =decimal.Parse( textBox2.Text);
            decimal min =decimal.Parse( textBox1.Text);
            productsTableAdapter1.FillByUnipriceBetween(nwDataSet1.Products, min, max);
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            label4.Text = $"{bindingSource1.Position + 1} / {bindingSource1.Count}";
            label5.Text = $"結果共{bindingSource1.Count }筆";
        }
    }
}
