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
    public partial class Frm0412_HW : Form
    {
        public Frm0412_HW()
        {
            InitializeComponent();

        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.nWDataSet);

        }

        private void Frm0412_HW_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'nWDataSet.Products' 資料表。您可以視需要進行移動或移除。
            this.productsTableAdapter.Fill(this.nWDataSet.Products);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            productsBindingSource.MoveFirst();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            productsBindingSource.MovePrevious();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            productsBindingSource.MoveNext();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            productsBindingSource.MoveLast();
        }

        private void productsBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            label4.Text = $"{productsBindingSource.Position + 1} / {productsBindingSource.Count}";
            label5.Text = $"結果共{productsBindingSource.Count}筆";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string s = textBox3.Text;
            productsTableAdapter.FillBySearchProductName(nWDataSet.Products,s);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            decimal max =decimal.Parse( textBox2.Text);
            decimal min =decimal.Parse( textBox1.Text);
            productsTableAdapter.FillByUnipriceBetween(nWDataSet.Products, min, max);
        }
    }
}
