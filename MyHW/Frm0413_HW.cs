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
    public partial class Frm0413_HW : Form
    {
        public Frm0413_HW()
        {
            InitializeComponent();
      
        }

        private void button15_Click(object sender, EventArgs e)
        {
            categoriesTableAdapter1.Fill(nwDataSet1.Categories);
            productsTableAdapter1.Fill(nwDataSet1.Products);
            customersTableAdapter1.Fill(nwDataSet1.Customers);

            dataGridView4.DataSource = nwDataSet1.Categories;
            dataGridView5.DataSource = nwDataSet1.Products;
            dataGridView6.DataSource = nwDataSet1.Customers;

            listBox2.Items.Clear();
            for (int i = 0; i <= nwDataSet1.Tables.Count - 1; i++)
            {
                DataTable table = nwDataSet1.Tables[i];
                listBox2.Items.Add(table.TableName);
                string tablecolumns = "";
                for (int columns = 0; columns < table.Columns.Count; columns++)
                {
                    tablecolumns += $"{table.Columns[columns],-60}";
                }
                listBox2.Items.Add($"{tablecolumns}");
                for (int row = 0; row < table.Rows.Count; row++)
                {
                    string rowcol = " ";
                    for (int a = 0; a < table.Columns.Count; a++)
                    {
                        rowcol += $"{table.Rows[row][a],-60}";
                    }
                    listBox2.Items.Add($"{rowcol}");
                }
                listBox2.Items.Add("==========================================================");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            MessageBox.Show(nwDataSet1.Products.Rows[0]["ProductName"].ToString());
            MessageBox.Show(nwDataSet1.Products.Rows[0][1].ToString());
            MessageBox.Show(nwDataSet1.Products[0].ProductName.ToString());
        }

        private void button17_Click(object sender, EventArgs e)
        {
            nwDataSet1.Products.ReadXml("Products.xml");
            dataGridView4.DataSource = nwDataSet1.Products;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            nwDataSet1.Products.ReadXml("Products.xml");
            dataGridView4.DataSource = nwDataSet1.Products;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel1Collapsed = !splitContainer2.Panel1Collapsed;
        }
    }
}
